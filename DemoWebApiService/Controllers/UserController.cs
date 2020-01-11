using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Demo.Core.BL;
using Demo.Core.BLImplementation;
using Demo.Core.Data.SQLServer;
using DemoService.DTO;
using System.Collections.Generic;
using DemoWebApiService.Services;
using System;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

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
        [HttpPost("api/User/Login/{userParam}")]
        public ActionResult Login(User userParam)
        {
            try
            {
                User user = _mapper.Map<User>(_userRepository.GetUsersDetailsByLogin(userParam.UserName, userParam.Password));

                if (user == null)
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }
                else
                {
                    // authentication successful so generate jwt token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("1234567890123456");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    user.Token = tokenHandler.WriteToken(token);

                    // remove password before returning
                    user.Password = null;

                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("api/User/AddUser/{usersParam}")]
        public ActionResult AddUser(User _users)
        {
            try
            {
                int UserID = _userRepository.AddUser(_mapper.Map<Demo.Core.Data.Model.User>(_users));
                return UserID == 0 ? NotFound(UserID) : (ActionResult)Ok(200);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("api/User/GetUserByID/{Id}")]
        public IActionResult GetUserByID(int Id)
        {
            try
            {
                User _user = _mapper.Map<User>(_userRepository.GetUserByID(Id));
                return _user == null ? NotFound(_user) : (IActionResult)Ok(_user);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("api/User/GetByEmailID/{Email}")]
        public IActionResult GetByEmailID(string Email)
        {
            try
            {
                User _user = _mapper.Map<User>(_userRepository.GetUserByEmailID(Email));
                return _user == null ? NotFound(_user) : (IActionResult)Ok(_user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("api/User/UpdateUser/{_users}")]
        public ActionResult UpdateUser(User _users)
        {
            try
            {
                int UserId = _userRepository.UpdateUser(_mapper.Map<Demo.Core.Data.Model.User>(_users));
                return UserId == 0 ? NotFound(UserId) : (ActionResult)Ok(200);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("api/User/DeleteUser/{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                return Ok(200);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      
      
        [HttpPut("api/User/updatePasswordByID/{userID},{newPassword}")]
        public ActionResult updatePasswordByID(int userID, string newPassword)
        {
            try
            {
                _userRepository.updatePasswordByID(userID, newPassword);
                return Ok(200);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}