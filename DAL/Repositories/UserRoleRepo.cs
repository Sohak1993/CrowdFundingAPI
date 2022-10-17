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
        public UserRoleRepo(IConfiguration config) : base(config) { }
       
        public IEnumerable<Role> GetRolesByUser(int userId)
        {
            List<Role> Roles = new List<Role>();
            Command cmd = new Command("Login", true);
            cmd.AddParameter("userId", userId);
            IEnumerable<Role> roles = ExecuteReader<Role>(cmd);
            return roles;
        }
        /// <summary>
        /// Ajoute le role Owner a l user 
        /// </summary>
        /// <returns></returns>
        public bool addOwner(int id)
        {
            Command cmd = new Command("insert into User_Role (idRole IdUser)values (3,@idUser);");
            cmd.AddParameter("idUser", id);
            

            /*
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText ="insert into User_Role (idRole IdUser)values (3,@idUser);";

                    cmd.Parameters.AddWithValue("idUser", id);

                    cnx.Open();
                    cmd.ExecuteNonQuery
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return GetList<Role>(reader);
                    }
                    
                
            */
            return false;
        }










          
        
        /// <summary>
        /// Retire le role owner a l user 
        /// </summary>
        /// <returns></returns>
        public bool removeOwner(int id)
        {

            return false;
        }
    }
}