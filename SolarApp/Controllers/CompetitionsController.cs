using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (!_solarDbRepository.CompetitionExists(competitionId))
                return NotFound();
            var competitionFromRepo = _solarDbRepository.GetCompetition(competitionId);
            return Ok(_mapper.Map<CompetitionDTO>(competitionFromRepo));
        }

        [HttpPost]
        public ActionResult<CompetitionDTO> CreateCompetition([FromBody] CompetitionForCreatingDTO competition)
        {
            var competitionEntity = _mapper.Map<Entities.Competition>(competition);
            _solarDbRepository.AddCompetition(competitionEntity);
            _solarDbRepository.Save();

            var competitionToReturn = _mapper.Map<CompetitionDTO>(competitionEntity);

            return CreatedAtRoute("GetCompetition", new { competitionId = competitionToReturn.competitionid }, competitionToReturn);
        }

        [HttpPut("{id}")]
        public ActionResult PutCompetitions(int id, [FromBody] CompetitionForCreatingDTO competition)
        {
            if (!_solarDbRepository.CompetitionExists(id))
                return NotFound();
            
            var competitionEntity = _mapper.Map<Entities.Competition>(competition);
            
            _solarDbRepository.UpdateCompetition(id, competitionEntity);

            try
            {
                _solarDbRepository.Save();
                var updated = _mapper.Map<CompetitionDTO>(_solarDbRepository.GetCompetition(id));
                return Ok(updated);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<CompetitionDTO> DeleteCompetition(int id)
        {
            if (!_solarDbRepository.CompetitionExists(id))
                return NotFound();
            var competitionForDelete = _solarDbRepository.DeleteCompetition(id);
            _solarDbRepository.Save();
            return Ok(_mapper.Map<CompetitionDTO>(competitionForDelete));
        }
    }
}
