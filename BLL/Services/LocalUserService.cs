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
            //return _userRepo.GetAll().Select(x => x.ToBll());
            return null;
        }

        public User Login(string email, string password)
        {
            User user = MapModel<User, DALM.User>(_userRepo.Login(email, password));

            user.Roles = _userRoleRepo.GetRolesByUser(user.Id).Select(role => 
                MapModel<Role, DALM.Role>(role)
            );
        return user;
        }

        public bool RegisterUser(string nickname, string email, string password, DateOnly birthdate)
        {
            return _userRepo.RegisterUser(nickname, email, password, birthdate);
        }
        /// <summary>
        /// Passer du status de baker a owner et inversement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UserSwapStatus(int id)
        {
            IEnumerable<Role> roles = _userRoleRepo.GetRolesByUser(id).Select(role => MapModel<Role, DALM.Role>(role));
            foreach (Role role in roles)
            {
                if (role.Name == "Owner") _userRoleRepo.UserRoleAddOwner(id);
                else _userRoleRepo.UserRoleRemoveOwner(id); 
            }
            return true;
        }
    }
}
