using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class ActionsController : ControllerBase
    {

        public readonly IActions db;

        public ActionsController(IActions db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("[controller]/GetActions")]
        public Task<IEnumerable<Actions>> GetActions() => db.GetActions();
        
        [HttpPost]
        [Route("[controller]/UpsertActions")]
        public Task<int?> UpsertActions(Actions actions) => db.UpsertActions(actions);
    }
}