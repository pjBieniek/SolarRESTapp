using Microsoft.AspNetCore.Mvc;
using SolarApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Controllers
{
    [ApiController]
    [Route("api/competitions")]
    public class CompetitionsController : ControllerBase
    {
        private readonly ISolarDbRepository _solarDbRepository;

        public CompetitionsController(ISolarDbRepository solarDbRepository)
        {
            _solarDbRepository = solarDbRepository ?? throw new ArgumentNullException(nameof(solarDbRepository));
        }

        [HttpGet]
        public IActionResult GetCompetitions()
        {
            var competitionsFromRepo = _solarDbRepository.GetCompetitions();
            return Ok(competitionsFromRepo);
        }

        [HttpGet("{competitionId}")]
        public IActionResult GetCompetition(int competitionId)
        {
            var competitionFromRepo = _solarDbRepository.GetCompetition(competitionId);
            if (competitionFromRepo == null)
                return NotFound();
            return Ok(competitionFromRepo);
        }
    }
}
