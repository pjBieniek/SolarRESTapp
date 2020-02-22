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
    public class RolesController : ControllerBase
    {
        private readonly ISolarDbRepository _solarDbRepository;
        private readonly IMapper _mapper;

        public RolesController(ISolarDbRepository solarDbRepository, IMapper mapper)
        {
            _solarDbRepository = solarDbRepository ?? throw new ArgumentNullException(nameof(solarDbRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<RoleDTO> GetRoles()
        {
            var rolesFromRepo = _solarDbRepository.GetRoles();
            if (rolesFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<Role>, IEnumerable<RoleDTO>>(rolesFromRepo));
        }


    }
}