using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarApp.Entities;
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
        private readonly IMapper _mapper;

        public CompetitionsController(ISolarDbRepository solarDbRepository, IMapper mapper)
        {
            _solarDbRepository = solarDbRepository ?? throw new ArgumentNullException(nameof(solarDbRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CompetitionDTO>> GetCompetitions()
        {
            var competitionsFromRepo = _solarDbRepository.GetCompetitions().ToList();
            if (competitionsFromRepo == null)
                return NotFound();
            return Ok(_mapper.Map<List<Competition>, List<CompetitionDTO>>(competitionsFromRepo));
        }

        [HttpGet("{competitionId}", Name = "GetCompetition")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CompetitionDTO> GetCompetition(int competitionId)
        {
            var competitionFromRepo = _solarDbRepository.GetCompetition(competitionId);
            if (competitionFromRepo == null)
                return NotFound();
            return Ok(_mapper.Map<CompetitionDTO>(competitionFromRepo));
        }

        [HttpPost]
        public ActionResult<CompetitionDTO> CreateCompetition([FromBody] CompetitionForCreatingDTO competition)
        {
            var competitionEntity = _mapper.Map<Entities.Competition>(competition);
            Console.WriteLine(competition.CompetitionDate.ToString());

            Console.WriteLine(competitionEntity.CompetitionDate.ToString());
            _solarDbRepository.AddCompetition(competitionEntity);
            _solarDbRepository.Save();

            var competitionToReturn = _mapper.Map<CompetitionDTO>(competitionEntity);

            return CreatedAtRoute("GetCompetition", new { competitionId = competitionToReturn.competitionid }, competitionToReturn);
        }
    }
}
