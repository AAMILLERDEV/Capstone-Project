using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class ScoresController : ControllerBase
    {

        public readonly IScores db;

        public ScoresController(IScores db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("[controller]/GetScoresByAuditID/{audit_ID}")]
        public Task<IEnumerable<Scores>> GetScoresByAuditID(int audit_ID) => db.GetScoresByAuditID(audit_ID);

        [HttpGet]
        [Route("[controller]/GetScores")]
        public Task<IEnumerable<Scores>> GetScores() => db.GetScores();
        
        [HttpPost]
        [Route("[controller]/UpsertScores")]
        public Task<int?> UpsertScores(Scores scores) => db.UpsertScores(scores);
    }
}