using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class ResourcesController : ControllerBase
    {

        public readonly IResources db;

        public ResourcesController(IResources db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("[controller]/GetResourcesByAuditId/{id}")]
        public Task<IEnumerable<Resources>> GetResourcesByAuditId(int id) => db.GetResourcesByAuditId(id);
        
        [HttpPost]
        [Route("[controller]/UpsertResources")]
        public Task<int?> UpsertScores(Resources resources) => db.UpsertResources(resources);

    }
}