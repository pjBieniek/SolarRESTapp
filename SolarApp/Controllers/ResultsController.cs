using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarApp.Models;
using SolarApp.Services;
using System;
using System.Collections.Generic;
using SolarApp.DatabaseCreation.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/competitions/{competitionId}/results")]
    public class ResultsController : ControllerBase
    {
        private readonly ISolarDbRepository _solarDbRepository;
        private readonly IMapper _mapper;

        public ResultsController(ISolarDbRepository solarDbRepository, IMapper mapper)
        {
            _solarDbRepository = solarDbRepository ??
                throw new ArgumentNullException(nameof(solarDbRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ResultDTO>> GetResultsForCompetition(int competitionId)
        {
            if (!_solarDbRepository.CompetitionExists(competitionId))
                return NotFound();

            var resultsFromRepo = _solarDbRepository.GetResults(competitionId);
            return Ok(_mapper.Map<IEnumerable<ResultDTO>>(resultsFromRepo));
        }

        [HttpGet("{resultId}", Name = "GetResultForBand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ResultDTO> GetResultFromCompetition(int resultId, int competitionId)
        {
            if (!_solarDbRepository.CompetitionExists(competitionId))
                return NotFound();

            var resultFromRepo = _solarDbRepository.GetResult(resultId, competitionId);
            if (resultFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<ResultDTO>(resultFromRepo));
        }

        [HttpPost]
        public ActionResult<ResultDTO> CreateResultForCompetition(int competitionId, [FromBody] ResultForCreatingDTO result)
        {
            if (!_solarDbRepository.CompetitionExists(competitionId))
                return NotFound();
            var resultEntity = _mapper.Map<Result>(result);
            _solarDbRepository.AddResult(competitionId, resultEntity);
            _solarDbRepository.Save();

            var resultToReturn = _mapper.Map<ResultDTO>(resultEntity);
            return CreatedAtRoute("GetResultForBand", new { competitionId = competitionId, resultId = resultToReturn.ResultId }, resultToReturn);
        }




    }
}
