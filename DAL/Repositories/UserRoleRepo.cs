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
using ToolBox.Mapper;

namespace DAL.Repositories
{
    public class UserRoleRepo : DataToModel, IUserRoleService
    {
        private readonly string _connectionString;
        public UserRoleRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }
        public IEnumerable<Role> GetRolesByUser(int userId)
        {
            List<Role> Roles = new List<Role>();
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Role_User";

                    cmd.Parameters.AddWithValue("userId", userId);

                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return GetList<Role>(reader);
                    }
                }
            }
        }
    }
}
