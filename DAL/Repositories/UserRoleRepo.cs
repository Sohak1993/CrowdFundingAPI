using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using ToolBox.Mapper;
using ToolBox.Models;

namespace DAL.Repositories
{
    public class UserRoleRepo : Connection, IUserRoleService
    {
        public UserRoleRepo(IConfiguration config) : base(config)
        {        
        }

        public IEnumerable<Role> GetRolesByUser(int userId)
        {
            Command cmd = new Command("Login", true);
            cmd.AddParameter("userId", userId);

            return ExecuteReader<Role>(cmd);    
        }

        public bool RegisterRoleUser(string email, int idRole)
        {
            Command cmd = new Command("UserRoleRegister", true);

            cmd.AddParameter("email", email);
            cmd.AddParameter("idRole", idRole);

            return ExecuteNonQuery(cmd) == 1;
        }
    }
}
