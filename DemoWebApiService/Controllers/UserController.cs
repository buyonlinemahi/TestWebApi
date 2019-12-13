using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Demo.Core.BL;
using Demo.Core.BLImplementation;
using Demo.Core.Data.SQLServer;
using DemoService.DTO;
using System.Collections.Generic;
using DemoWebApiService.Services;

namespace DemoWebApiService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(DemoDbContext context, IMapper mapper ,IUserService userService)
        {
            _mapper = mapper;
            _userRepository = new UserRepository(context);
            _userService = userService;
        }
        [HttpGet("api/User/Login/{userParam}")]
        public ActionResult Login(User userParam)
        {
            List<User> _user = _mapper.Map<List<User>>(_userRepository.GetUsersByUserName(userParam.UserName));
            var user = _userService.Authenticate(userParam.UserName, userParam.Password, _user);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }


        [HttpPost("api/User/AddUser/{_users}")]
        public ActionResult AddUser(User _users)
        {
            int UserID = _userRepository.AddUser(_mapper.Map<Demo.Core.Data.Model.User>(_users));
            return UserID == 0 ? NotFound(UserID) : (ActionResult)Ok(200);
           

        }

        [HttpGet("api/User/GetUserByID/{Id}")]
        public IActionResult GetUserByID(int Id)
        {
            User _user = _mapper.Map<User>(_userRepository.GetUserByID(Id));
            return _user == null ? NotFound(_user) : (IActionResult)Ok(200);

        }

        [HttpGet("api/User/GetByEmailID/{Email}")]
        public IActionResult GetByEmailID(string Email)
        {
            User _user = _mapper.Map<User>(_userRepository.GetUserByEmailID(Email));
            return _user == null ? NotFound(_user) : (IActionResult)Ok(200);
        }

        [HttpPut("api/User/UpdateUser/{_users}")]
        public ActionResult UpdateUser(User _users)
        {
            int UserId = _userRepository.UpdateUser(_mapper.Map<Demo.Core.Data.Model.User>(_users));
            return UserId == 0 ? NotFound(UserId) : (ActionResult)Ok(200);
        }

        [HttpDelete("api/User/DeleteUser/{id}")]
        public ActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return Ok(200);
        }      
      
        [HttpPut("api/User/updatePasswordByID/{userID},{newPassword}")]
        public ActionResult updatePasswordByID(int userID, string newPassword)
        {
            _userRepository.updatePasswordByID(userID, newPassword);
            return Ok(200);
        }

    }
}