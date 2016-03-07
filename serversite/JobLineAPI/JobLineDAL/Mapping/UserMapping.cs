using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobLineDAL.Entities;

namespace JobLineDAL.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("Users").HasKey(k => k.Id);
            HasRequired(h => h.Role)
            .WithMany(c => c.Users)
            .HasForeignKey(k => k.RoleId);
        }
    }
}
