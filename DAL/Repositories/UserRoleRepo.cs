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
            Command cmd = new Command("Role_User", true);
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

            cmd.AddParameter("email", email);
            cmd.AddParameter("idRole", idRole);
                    cmd.Parameters.AddWithValue("idUser", id);

            return ExecuteNonQuery(cmd) == 1;
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