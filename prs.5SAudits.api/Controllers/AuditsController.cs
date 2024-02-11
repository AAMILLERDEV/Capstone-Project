using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class AuditsController : ControllerBase
    {

        public readonly IAudits db;

        public AuditsController(IAudits db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("[controller]/GetAuditByID/{id}")]
        public Task<Audits> GetAuditByID(int id) => db.GetAuditByID(id);

        [HttpGet]
        [Route("[controller]/GetAudits")]
        public Task<IEnumerable<Audits>> GetAudits() => db.GetAudits();
        
        [HttpPost]
        [Route("[controller]/UpsertAudits")]
        public Task<int?> UpsertAudits(Audits audits) => db.UpsertAudits(audits);
    }
}