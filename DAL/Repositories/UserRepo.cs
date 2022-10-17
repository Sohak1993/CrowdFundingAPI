﻿using DAL.Interface;
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
        public UserRepo(IConfiguration config) : base(config){}

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

        public bool RegisterUser(string nickName, string email, string password, DateOnly birthdate)
        {
            Command cmd = new Command("UserRegister", true);
            cmd.AddParameter("nickName", nickName);
            cmd.AddParameter("email", email);
            cmd.AddParameter("password", password);
            cmd.AddParameter("birthdate", birthdate);

            return ExecuteNonQuery(cmd) == 1;
        }

        public bool UpdateUser(int id, string nickName, string email, DateOnly birthdate)
        {
            Command cmd = new Command("UpdateUser", true);
            cmd.AddParameter("id", id);
            cmd.AddParameter("nickName", nickName);
            cmd.AddParameter("email", email);
            cmd.AddParameter("birthdate", birthdate);

            return ExecuteNonQuery(cmd) == 1;
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
