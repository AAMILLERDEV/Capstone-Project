using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
	[ApiController]
	public class EventTypesController : ControllerBase
	{

		public readonly IEventTypes db;

		public EventTypesController(IEventTypes db)
		{
			this.db = db;
		}





		[HttpGet]
		[Route("[controller]/GetEventTypes")]
		public Task<IEnumerable<EventTypes>> GetEventTypes() => db.GetEventTypes();

		[HttpPost]
		[Route("[controller]/InsertEventTypes")]
		public Task<int?> InsertEventTypes(EventTypes eventTypes) => db.InsertEventTypes(eventTypes);
	}
}