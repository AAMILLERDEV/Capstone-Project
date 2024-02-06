using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class AuditLogController : ControllerBase
    {

        public readonly IAuditLog db;

        public AuditLogController(IAuditLog db)
        {
            this.db = db;
        }


       

        
     
        [HttpGet]
        [Route("[controller]/GetAuditLog")]
        public Task<IEnumerable<AuditLog>> GetAuditLog() => db.GetAuditLog();
        
        [HttpPost]
        [Route("[controller]/UpsertAuditLog")]
        public Task<int?> UpsertAuditLog(AuditLog audits) => db.UpsertAuditLog(audits);
    }
}