﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLineDAL.Entities
{
    public class User : BaseEntity
    {
        public Guid RoleId { get; set; }
        public bool Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        public virtual IList<UserProfile> UserProfiles { get; set; }
    }
}
