﻿using RentTech.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentTech.Domain.Entities
{
    public class User : Auditable
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
