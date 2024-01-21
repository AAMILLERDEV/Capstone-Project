using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class SettingsController : ControllerBase
    {

        public readonly ISettings db;

        public SettingsController(ISettings db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("[controller]/GetSettings")]
        public Task<IEnumerable<Settings>> GetSettings() => db.GetSettings();
    }
}