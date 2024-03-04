using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
	[ApiController]
	public class DeletedAuditsController : ControllerBase
	{

		public readonly IDeletedAudits db;

		public DeletedAuditsController(IDeletedAudits db)
		{
			this.db = db;
		}





		[HttpGet]
		[Route("[controller]/GetDeletedAudits")]
		public Task<IEnumerable<DeletedAudits>> GetDeletedAudits() => db.GetDeletedAudits();

		[HttpPost]
		[Route("[controller]/InsertEventLogs")]
		public Task<int?> InsertDeletedAudits(DeletedAudits deleted) => db.InsertDeletedAudits(deleted);	
	}
}