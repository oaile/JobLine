using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobLineBUS.Dtos;
using JobLineDAL.Entities;

namespace JobLineBUS.Contracts
{
    public interface IUserService
    {
        UserProfileDto GetUserProfileByUserId(Guid id);
        UserDto Login(UserDto userDto);
    }
}
