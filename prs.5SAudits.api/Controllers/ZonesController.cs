using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class ZonesController : ControllerBase
    {

        public readonly IZones db;

        public ZonesController(IZones db)
        {
            this.db = db;
        }



     
        [HttpGet]
        [Route("[controller]/GetZones")]
        public Task<IEnumerable<Zones>> GetZones() => db.GetZones();
        
        [HttpPost]
        [Route("[controller]/UpsertZones")]
        public Task<int?> UpsertZones(Zones ins) => db.UpsertZones(ins);

		[HttpPost]
		[Route("[controller]/DeleteZone")]
		public Task<bool> DeleteZone(int id) => db.DeleteZone(id);
	}
}