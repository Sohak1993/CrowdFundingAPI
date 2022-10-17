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
            Command cmd = new Command("SELECT * FROM V_Users");
            return ExecuteReader<User>(cmd);
        }

        public User GetOne(int idUser)
        {
            Command cmd = new Command("GetUser", true);
            cmd.AddParameter("idUser", idUser);

            return ExecuteReader<User>(cmd).First();
        }

        public User Login(string email, string password)
        {
            Command cmd = new Command("Login", true);
            cmd.AddParameter("email", email);
            cmd.AddParameter("password", password);

            return ExecuteReader<User>(cmd).First();
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
