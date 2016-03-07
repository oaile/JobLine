using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobLineDAL.Entities;

namespace JobLineDAL.Mapping
{
    public class UserProfileMapping : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMapping()
        {
            ToTable("UserProfiles").HasKey(k => k.Id);

            HasRequired(t => t.User).WithMany(p => p.UserProfiles).HasForeignKey(k => k.UserId);

        }
    }
}
