using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
	[ApiController]
	public class EmailController : ControllerBase
	{

		public readonly IEmail db;

		public EmailController(IEmail db)
		{
			this.db = db;
		}




		[HttpPost]
		[Route("[controller]/EventLogEmail")]
		public Task<bool> EventLogEmail(EventLogs eventLogs) => db.EventLogEmail(eventLogs);

		[HttpPost]
		[Route("[controller]/CreateEmail")]
		public Task<bool> CreateEmail(Email email) => db.CreateEmail(email);
	}
}