using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class ZoneCategoriesController : ControllerBase
    {

        public readonly IZoneCategories db;

        public ZoneCategoriesController(IZoneCategories db)
        {
            this.db = db;
        }
     
        [HttpGet]
        [Route("[controller]/GetZoneCategories")]
        public Task<IEnumerable<ZoneCategories>> GetZones() => db.GetZoneCategories();
        
        [HttpPost]
        [Route("[controller]/UpsertZoneCategories")]
        public Task<int?> UpsertZoneCategories(ZoneCategories ins) => db.UpsertZoneCategories(ins);
    }
}