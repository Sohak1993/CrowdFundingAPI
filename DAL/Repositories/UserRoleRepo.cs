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
        private readonly string _connectionString;
        public UserRoleRepo(IConfiguration config) : base(config)
        {        
        }
        public IEnumerable<Role> GetRolesByUser(int userId)
        {
            List<Role> Roles = new List<Role>();
            Command cmd = new Command("Login", true);
            cmd.AddParameter("userId", userId);
            IEnumerable<Role> roles = ExecuteReader<Role>(cmd);
            return roles;    
        }
    }
}
