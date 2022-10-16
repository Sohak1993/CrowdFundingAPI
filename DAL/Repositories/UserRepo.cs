using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using ToolBox.Mapper;
using ToolBox.Models;

namespace DAL.Repositories
{
    public class UserRepo : Connection, IUserService
    {
        public UserRepo(IConfiguration config) : base(config)
        {

        }
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Login(string email, string password)
        {
            Command cmd = new Command("Login", true);
            cmd.AddParameter("email", email);
            cmd.AddParameter("password", password);

            IEnumerable<User> users = ExecuteReader<User>(cmd);

            return users.First();
        }

        public bool RegisterUser(string nickname, string email, string password, DateOnly birthdate)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
