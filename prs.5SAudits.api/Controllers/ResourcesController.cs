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
        [Route("[controller]/GetResources")]
        public Task<IEnumerable<Resources>> GetResources() => db.GetResources();
        
        [HttpPost]
        [Route("[controller]/UpsertResources")]
        public Task<int?> UpsertScores(Resources resources) => db.UpsertResources(resources);

        [HttpPost, DisableRequestSizeLimit]
        [Route("[controller]/CreateResource")]
        public async Task<bool> CreateResource(Resources res) => db.CreateResource(res);

    }
}