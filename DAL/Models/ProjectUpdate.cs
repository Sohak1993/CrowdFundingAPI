﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ProjectUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Goal { get; set; }
    }
}
