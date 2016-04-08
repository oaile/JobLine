using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using JobLineAPI.Models;
using JobLineBUS.Contracts;
using JobLineBUS.Dtos;

namespace JobLineAPI.Controllers
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET api/user
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        [Route("api/user/profile/{id}")]
        public UserProfileModel Get(Guid id)
        {
            var user = _userService.GetUserProfileByUserId(id);
            return Mapper.Map<UserProfileModel>(user) ?? new UserProfileModel();
        }

        // POST api/user
        [Route("api/user/login")]
        public UserModel Login([FromBody]UserModel user)
        {
            var userDto = Mapper.Map<UserDto>(user);
            //Encrypt password
            var hashPassword = Crypto.HashPassword(userDto.Password);
            userDto.Password = hashPassword;
            var isLogin = _userService.Login(userDto);
            return Mapper.Map<UserModel>(isLogin);
        }

        [Route("api/user/register")]
        public void Register([FromBody]UserModel user)
        {
            var userDto = Mapper.Map<UserDto>(user);
            //Encrypt password
            var hashPassword = Crypto.HashPassword(userDto.Password);
            userDto.Password = hashPassword;
            var isLogin = _userService.Login(userDto);
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
