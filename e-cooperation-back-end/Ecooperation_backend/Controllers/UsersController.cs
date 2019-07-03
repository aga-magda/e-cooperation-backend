using System;
using System.Threading.Tasks;
using AutoMapper;
using Ecooperation_backend.DTOs;
using Ecooperation_backend.Entities;
using Ecooperation_backend.Helpers;
using Ecooperation_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecooperation_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly ITokenGenerator _tokenGenerator;

        public UsersController
        (
            IUserService userService,
            IMapper mapper,
            IAuthorizationService authorizationService,
            ITokenGenerator tokenGenerator
        )
        {
            _userService = userService;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _tokenGenerator = tokenGenerator;
        }


        // POST: /users/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserDTO userDTO)
        {
            try
            {
                var user = await _userService.Authenticate(userDTO.UserName, userDTO.Password);
                var tokenString = _tokenGenerator.GenerateToken(user.Id);

                return Ok(new
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = tokenString,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // POST: /users/register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                await _userService.Create(user, userDTO.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // GET: /users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _userService.GetById(id);
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, user, "SameAuthorPolicy");
                if (authorizationResult.Succeeded)
                    return Ok(user);
                else if (User.Identity.IsAuthenticated)
                    return new ForbidResult();
                else
                    return new ChallengeResult();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: /users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody]UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Id = id;

            if (id != user.Id)
            {
                return BadRequest();
            }

            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, new User { Id = id }, "SameAuthorPolicy");

            if (authorizationResult.Succeeded)
            {
                try
                {
                    await _userService.Update(user, userDTO.Password);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
            else if (User.Identity.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }
}