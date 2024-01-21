﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public int StaffID { get; set; }
       
        public string? Gender { get; set; }
        public string? Position { get; set; }
    }
}
