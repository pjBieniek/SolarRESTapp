using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarApp.Entities;
using SolarApp.Models;
using SolarApp.Services;

namespace SolarApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISolarDbRepository _solarDbRepository;
        private readonly IMapper _mapper;

        public UsersController(ISolarDbRepository solarDbRepository, IMapper mapper)
        {
            _solarDbRepository = solarDbRepository ?? throw new ArgumentNullException(nameof(solarDbRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            var usersFromRepo = _solarDbRepository.GetUsers().ToList();
            if (usersFromRepo == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(usersFromRepo));
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CompetitionDTO> GetUser(int userId)
        {
            var userFromRepo = _solarDbRepository.GetUser(userId);
            if (userFromRepo == null)
                return NotFound();
            return Ok(_mapper.Map<UserDTO>(userFromRepo));
        }

        [HttpGet("{userId}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CompetitionDTO> GetUserRoles(int userId)
        {
            var userRolesFromRepo = _solarDbRepository.GetUserRoles(userId);
            if (userRolesFromRepo == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<UserRole>, IEnumerable<UserRoleDTO>>(userRolesFromRepo));
        }
    }
}