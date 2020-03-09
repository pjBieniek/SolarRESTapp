using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SolarApp.DatabaseCreation.Entities;
using SolarApp.Data.Models;
using SolarApp.Data.Services;

namespace SolarApp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly ISolarDbRepository _solarDbRepository;
        public readonly IMapper _mapper;
        public readonly JWTSettings _jwtsettings;

        public UsersController(ISolarDbRepository solarDbRepository, IMapper mapper, IOptions<JWTSettings> jwtsettings)
        {
            _solarDbRepository = solarDbRepository;
            _mapper = mapper;
            _jwtsettings = jwtsettings.Value;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            var usersFromRepo = _solarDbRepository.GetUsers().ToList();
            if (usersFromRepo == null)
                return NotFound();
            return Ok(_mapper.Map<List<User>, List<UserDTO>>(usersFromRepo));
        }

        [HttpGet("{userId}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> GetUser(int userId)
        {
            if (!_solarDbRepository.UserExists(userId))
                return NotFound();
            var userFromRepo = _solarDbRepository.GetUser(userId);
            return Ok(_mapper.Map<UserDTO>(userFromRepo));
        }

        [HttpPost]
        public ActionResult<UserDTO> CreateUser([FromBody] UserForCreatingDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            _solarDbRepository.AddUser(userEntity);
            _solarDbRepository.Save();

            var userToReturn = _mapper.Map<UserDTO>(userEntity);

            return CreatedAtRoute("GetUser", new { userId = userToReturn.UserId }, userToReturn);
        }

        [HttpPut("{id}")]
        public ActionResult PutUser(int id, [FromBody] UserForUpdateDTO user)
        {
            if (!_solarDbRepository.UserExists(id))
                return NotFound();

            var userEntity = _mapper.Map<User>(user);

            _solarDbRepository.UpdateUser(id, userEntity);

            try
            {
                _solarDbRepository.Save();
                var updated = _mapper.Map<UserDTO>(_solarDbRepository.GetUser(id));
                return Ok(updated);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<UserDTO> DeleteUser(int id)
        {
            if (!_solarDbRepository.UserExists(id))
                return NotFound();
            var userForDelete = _solarDbRepository.DeleteUser(id);
            _solarDbRepository.Save();
            return Ok(_mapper.Map<UserDTO>(userForDelete));
        }

        [HttpGet("Login")]
        public ActionResult<UserDTO> Login([FromBody] UserForLoginDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            userEntity = _solarDbRepository.LoginUser(userEntity);
            var userDto = _mapper.Map<UserDTO>(userEntity);

            UserWithToken userWithToken = null;
            if (userEntity != null)
                userWithToken = new UserWithToken(userDto);

            if (userWithToken == null)
                return NotFound();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDto.UserEmail)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userWithToken.Token = tokenHandler.WriteToken(token);

            return userWithToken;
        }
    }
}