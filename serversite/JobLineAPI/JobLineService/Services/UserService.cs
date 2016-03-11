using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobLineBUS.Contracts;
using JobLineBUS.Dtos;
using JobLineDAL.Contracts;
using JobLineDAL.Entities;

namespace JobLineBUS.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IRepository<UserProfile> _userProfileRepository;
        public UserService(IRepository<UserProfile> userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        public UserProfileDto GetUserProfileByUserId(Guid userId)
        {
            var userProfile = _userProfileRepository.Get(u => u.UserId == userId);
            return Mapper.Map<UserProfileDto>(userProfile) ?? null;
        }
    }
}
