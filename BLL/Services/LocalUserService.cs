using BLL.Interface;
using BLL.Models;
using DAL.Interface;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Mapper;
using DALM = DAL.Models;

namespace BLL.Services
{
    public class LocalUserService : ObjectMapper, ILocalUserService
    {
        private readonly IUserService _userRepo;
        private readonly IUserRoleService _userRoleRepo;

        public LocalUserService(IUserService userRepo, IUserRoleService userRoleRepo)
        {
            _userRepo = userRepo;
            _userRoleRepo = userRoleRepo;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetAll().Select(user => 
                MapModel<User, DALM.User>(user)
            ); 
        }

        public User GetOne(int idUser)
        {
            return MapModel<User, DALM.User>(_userRepo.GetOne(idUser));
        }

        public User Login(string email, string password)
        {
            User user = MapModel<User, DALM.User>(_userRepo.Login(email, password));

            user.Roles = _userRoleRepo.GetRolesByUser(user.Id).Select(role => 
                MapModel<Role, DALM.Role>(role)
            );
            return user;
        }

        public bool RegisterUser(string nickname, string email, string password, DateOnly birthdate, int idRole)
        {
            bool isRegister = _userRepo.RegisterUser(nickname, email, password, birthdate);
            bool isRegisterRole = _userRoleRepo.RegisterRoleUser(email, idRole);
            return (isRegister && isRegisterRole);
        }
        /// <summary>
        /// Passer du status de baker a owner et inversement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool swapUserStatus(int id)
        {
            IEnumerable<Role> roles = _userRoleRepo.GetRolesByUser(id).Select(role => MapModel<Role, DALM.Role>(role));
            foreach (Role role in roles)
            {
                if (role.Name == "Owner") _userRoleRepo.addOwner(id);
                else _userRoleRepo.removeOwner(id); 
            }
            return false;
        }

        public bool UpdateUser(int idUser, string nickname, string email, DateOnly birthdate)
        {
            bool isRegister = _userRepo.UpdateUser(idUser, nickname, email, birthdate);
            return isRegister;
        }

        public bool DeleteUser(int idUser)
        {
            return false; 
        }
    }
}
