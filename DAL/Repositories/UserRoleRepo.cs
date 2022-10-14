using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRoleRepo : IUserRoleService
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
                    cmd.CommandText = "SELECT * FROM V_Role_User";

                    cmd.Parameters.AddWithValue("userId", userId);

                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Roles.Add((Role)reader["Name"]);
                        }
                    }
                }
            }
            return Roles;
        }
    }
}
