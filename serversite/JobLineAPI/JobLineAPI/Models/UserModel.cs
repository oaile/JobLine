﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobLineAPI.Models
{
    public class UserModel : BaseModel
    {
        public Guid RoleId { get; set; }
        public bool Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleModel Role { get; set; }
        public IList<UserProfileModel> UserProfiles { get; set; }
    }
}