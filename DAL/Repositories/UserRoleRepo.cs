﻿using DAL.Interface;
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
        /// <param name="id"></param>
        /// <returns></returns>
        public bool addOwner(int id)
        {
            Command cmd = new Command("UserRoleAddOwner", true);
            cmd.AddParameter("idUser", id);
            return true;
        }
        /// <summary>
        /// Retirer le role de owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool removeOwner(int id)
        {
            Command cmd = new Command("UserRoleRemoveOwner", true);
            cmd.AddParameter("idUser", id);
            return true;
        }
    }
}