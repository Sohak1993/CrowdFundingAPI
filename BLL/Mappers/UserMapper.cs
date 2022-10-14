using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLLM = BLL.Models;
using DALM = DAL.Models;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static BLLM.User ToBll(this DALM.User user)
        {
            return new BLLM.User
            {
                Id = user.Id,
                NickName = user.NickName,
                BirthDate = user.BirthDate,
                Email = user.Email
            };
        }

        public static DALM.User ToDall(this BLLM.User user)
        {
            return new DALM.User
            {
                Id = user.Id,
                NickName = user.NickName,
                BirthDate = user.BirthDate,
                Email = user.Email
            };
        }
    }
}
