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

        public List<User> GetAll()
        {
            IEnumerable<User> users = _userRepo.GetAll()
                .Select(user => MapModel<User, DALM.User>(user)
                );

            List<User> mappedUsers = new List<User>();

            foreach (User user in users)
            {
                user.Roles = _userRoleRepo.GetRolesByUser(user.Id)
                    .Select(role => MapModel<Role, DALM.Role>(role));
                mappedUsers.Add(user);
            }

            return mappedUsers;
        }

        public User GetOne(int idUser)
        {
            User user = MapModel<User, DALM.User>(_userRepo.GetOne(idUser));

            user.Roles = _userRoleRepo.GetRolesByUser(user.Id)
                .Select(role => MapModel<Role, DALM.Role>(role));

            return user;
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
        ///  Passer du status de baker a owner et inversement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool swapUserStatus(int id)
            {
            bool is_owner = false;
            IEnumerable<Role> roles = _userRoleRepo.GetRolesByUser(id).Select(role => MapModel<Role, DALM.Role>(role));
            foreach (Role role in roles) if (role.Name == "Owner") is_owner = true;
            Console.WriteLine("Owner existe ? : "+is_owner);
            if (is_owner)
                {
                _userRoleRepo.removeOwner(id);
                Console.WriteLine("Owner supprimer");
                }
            else 
                {
                _userRoleRepo.addOwner(id);
                Console.WriteLine("owner ajouter");
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
