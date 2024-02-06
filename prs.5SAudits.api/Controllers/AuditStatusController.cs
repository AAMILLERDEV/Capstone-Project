using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class AuditStatusController : ControllerBase
    {

        public readonly IAuditStatus db;

        public AuditStatusController(IAuditStatus db)
        {
            this.db = db;
        }



        
     
        [HttpGet]
        [Route("[controller]/GetAuditStatus")]
        public Task<IEnumerable<AuditStatus>> GetAuditStatus() => db.GetAuditStatus();
        
        [HttpPost]
        [Route("[controller]/UpsertAuditStatus")]
        public Task<int?> UpsertAuditStatus(AuditStatus auditStatus) => db.UpsertAuditStatus(auditStatus);
    }
}