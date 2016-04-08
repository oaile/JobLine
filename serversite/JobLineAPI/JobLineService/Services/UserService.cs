using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<User> _useRepository;
        public UserService(IRepository<UserProfile> userProfileRepository, IRepository<Role> roleRepository, IRepository<User> useRepository)
        {
            _userProfileRepository = userProfileRepository;
            _roleRepository = roleRepository;
            _useRepository = useRepository;
        }
        public UserProfileDto GetUserProfileByUserId(Guid userId)
        {
            var userProfile = _userProfileRepository.Get(u => u.UserId == userId);
            return Mapper.Map<UserProfileDto>(userProfile) ?? null;
        }

        public List<RoleDto> GetAllRole()
        {
            var roleList = _roleRepository.Get(u => u.Name != "Administrator");
            return Mapper.Map<List<RoleDto>>(roleList) ?? null;
        }

        public UserDto Register(UserDto userDto)
        {
            var user = Mapper.Map<User>(userDto);
            var result = _useRepository.Insert(user);
            return Mapper.Map<UserDto>(result);
        }

        public UserDto Login(UserDto userDto)
        {
            var result = _useRepository.Get(u => u.Username == userDto.Username && u.Password == userDto.Password);
            return Mapper.Map<UserDto>(result) ?? null;
        }
    }
}
