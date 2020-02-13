using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolarApp.Models;
using SolarApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Controllers
{
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
        public ActionResult<IEnumerable<ResultDTO>> GetResultsForCompetition(int competitionId)
        {
            if (!_solarDbRepository.CompetitionExists(competitionId))
                return NotFound();

            var resultsFromRepo = _solarDbRepository.GetResults(competitionId);
            return Ok(_mapper.Map<IEnumerable<ResultDTO>>(resultsFromRepo));
        }

        [HttpGet("{resultId}")]
        public ActionResult<ResultDTO> GetResultFromCompetition(int resultId, int competitionId)
        {
            if (!_solarDbRepository.CompetitionExists(competitionId))
                return NotFound();

            var resultFromRepo = _solarDbRepository.GetResult(resultId, competitionId);
            if (resultFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<ResultDTO>(resultFromRepo));
        }




    }
}
