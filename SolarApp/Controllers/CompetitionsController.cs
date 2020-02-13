using Microsoft.AspNetCore.Mvc;
using SolarApp.Helpers;
using SolarApp.Models;
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
        public ActionResult<IEnumerable<CompetitionDTO>> GetCompetitions()
        {
            var competitionsFromRepo = _solarDbRepository.GetCompetitions();
            var competitionsDto = new List<CompetitionDTO>();

            foreach(var comp in competitionsFromRepo)
            {
                competitionsDto.Add(new CompetitionDTO()
                {
                    competitionid = comp.CompetitionId,
                    CompetitionTitle = comp.CompetitionTitle,
                    CompetitionDescription = comp.CompetitionDescription,
                    CompetitionUrlAddress = comp.CompetitionUrlAddress,
                    Date = $"{comp.CompetitionDate.ToString("d MMM yyyy")}  ({comp.CompetitionDate.GetDays()})"
                });
                

            }
            return Ok(competitionsDto);
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
