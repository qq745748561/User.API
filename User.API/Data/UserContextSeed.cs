using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Models;

namespace User.API.Data
{
    public class UserContextSeed
    {
        public static  async Task SeedAsyns(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory,int? retry=1)
        {
            var retryForAvaiability = retry;
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                try
                {
                    var userContext = (UserContext)scope.ServiceProvider.GetService(typeof(UserContext));
                    var logger = (ILogger<UserContextSeed>)scope.ServiceProvider.GetService(typeof(ILogger<UserContextSeed>));
                    logger.LogDebug("Begin UserContextSeed SeedAsync");

                    userContext.Database.Migrate(); //初始化代码库
                    if (!userContext.Users.Any())
                    {
                        userContext.Users.Add(new AppUser()
                        {
                            Name = "jesse"
                        });
                        userContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    if(retryForAvaiability<10)
                    {
                        retryForAvaiability++;
                        var logger = loggerFactory.CreateLogger(typeof(UserContextSeed));
                        logger.LogError(ex.Message);

                        await SeedAsyns(applicationBuilder, loggerFactory, retryForAvaiability);
                    }
                }
            }
        }
    }
}
