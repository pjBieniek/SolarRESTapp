using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarApp.Entities;
using SolarApp.Models;
using SolarApp.Services;

namespace SolarApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly ISolarDbRepository _solarDbRepository;
        public readonly IMapper _mapper;

        public UsersController(ISolarDbRepository solarDbRepository, IMapper mapper)
        {
            _solarDbRepository = solarDbRepository;
            _mapper = mapper;
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
            var userEntity = _mapper.Map<Entities.User>(user);
            _solarDbRepository.AddUser(userEntity);
            _solarDbRepository.Save();

            var userToReturn = _mapper.Map<UserDTO>(userEntity);

            return CreatedAtRoute("GetUser", new { userId = userToReturn.UserId }, userToReturn);
        }

        [HttpPut("{id}")]
        public ActionResult PutCompetitions(int id, [FromBody] UserForUpdateDTO user)
        {
            if (!_solarDbRepository.UserExists(id))
                return NotFound();

            var userEntity = _mapper.Map<Entities.User>(user);

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
    }
}