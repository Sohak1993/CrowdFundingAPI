using BLL.Interface;
using BLL.Models;
using DAL.Interface;
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

        public bool RegisterUser(string nickname, string email, string password, DateOnly birthdate)
        {
            return _userRepo.RegisterUser(nickname, email, password, birthdate);
        }

        public bool UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
