using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLineBUS.Dtos
{
    public class UserProfileDto : BaseDto
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string CurrentlyResidingIn { get; set; }
        public string State { get; set; }
        public string MonthlySalaryExpectation { get; set; }
        public virtual UserDto User { get; set; }
        public Guid UserId { get; set; }
    }
}
