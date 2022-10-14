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
    public class UserRepo : IUserService
    {
        private readonly string _connectionString;
        public UserRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Login(string email, string password)
        {
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "Login";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("password", password);
                    cmd.Parameters.AddWithValue("email", email);

                    cnx.Open();
                    return (User)cmd.ExecuteScalar();
                }
            }
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
