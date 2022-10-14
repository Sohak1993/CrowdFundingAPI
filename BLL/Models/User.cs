﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class User
    {
       public int Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public IEnumerable <Role> Roles { get; set; }
    }
}
