CREATE USER 'jun'@'localhost' IDENTIFIED BY '123456';
GRANT ALL PRIVILEGES ON *.* TO 'jun'@'localhost' WITH GRANT OPTION;

CREATE USER 'jun'@'%' IDENTIFIED BY '123456';
GRANT ALL PRIVILEGES ON *.* TO 'jun'@'%' WITH GRANT OPTION;

ALTER USER 'jun'@'localhost' IDENTIFIED WITH mysql_native_password BY '123456'; 
alter user 'jun'@'%' identified with mysql_native_password by '123456';
FLUSH PRIVILEGES;