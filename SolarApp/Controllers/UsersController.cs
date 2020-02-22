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

    }
}