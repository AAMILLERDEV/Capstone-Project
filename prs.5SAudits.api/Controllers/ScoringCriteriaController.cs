using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class ScoringCriteriaController : ControllerBase
    {

        public readonly IScoringCriteria db;

        public ScoringCriteriaController(IScoringCriteria db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("[controller]/GetScoringCriteria")]
        public Task<IEnumerable<ScoringCriteria>> GetScoringCriteria() => db.GetScoringCriteria();
        
        [HttpPost]
        [Route("[controller]/UpsertScoringCriteria")]
        public Task<int?> UpsertScoringCriteria(ScoringCriteria scoringCriteria) => db.UpsertScoringCriteria(scoringCriteria);
    }
}