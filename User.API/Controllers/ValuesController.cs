using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.API.Data;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly UserContext _UserContext;
        public ValuesController(UserContext UserContext)
        {
            _UserContext = UserContext;
        }

        // GET api/values
        [HttpGet]
        public  async Task<Models.AppUser> Get()
        {
            return await _UserContext.Users.SingleOrDefaultAsync(u => u.Name == "jesse");
        }

    }
}
