using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using JobLineAPI.Models;
using JobLineBUS.Contracts;

namespace JobLineAPI.Controllers
{
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
        public UserProfileModel Get(Guid id)
        {
            var user = _userService.GetUserProfileByUserId(id);
            return Mapper.Map<UserProfileModel>(user) ?? new UserProfileModel();
        }

        // POST api/user
        public void Post([FromBody]string value)
        {
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
