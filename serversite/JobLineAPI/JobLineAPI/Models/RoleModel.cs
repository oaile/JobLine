using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobLineAPI.Models
{
    public class RoleModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<UserModel> Users { get; set; }
    }
}