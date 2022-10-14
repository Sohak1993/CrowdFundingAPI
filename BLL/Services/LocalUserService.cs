using BLL.Interface;
using BLL.Models;
using DLL.Models;
using DAL.Interface;
using BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LocalUserService : ILocalUserService
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
            return _userRepo.GetAll().Select(x => x.ToBll());
        }

        public User Login(string email, string password)
        {
            User user = _userRepo.Login(email, password).ToBll();
            user.Roles = _userRoleRepo.GetRolesByUser(user.Id).Select(x => x.ToBll());
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
