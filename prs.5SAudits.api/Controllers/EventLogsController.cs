using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
	[ApiController]
	public class EventLogsController : ControllerBase
	{

		public readonly IEventLogs db;

		public EventLogsController(IEventLogs db)
		{
			this.db = db;
		}





		[HttpGet]
		[Route("[controller]/GetEventLogs")]
		public Task<IEnumerable<EventLogs>> GetEventLogs() => db.GetEventLogs();	

		[HttpPost]
		[Route("[controller]/InsertEventLogs")]
		public Task<bool> InsertEventLogs(EventLogs eventLogs) => db.InsertEventLogs(eventLogs);

		[HttpPost]
		[Route("[controller]/LogEmailEvent")]
		public Task<bool> LogEmailEvent(Email email) => db.LogEmailEvent(email);
	}
}