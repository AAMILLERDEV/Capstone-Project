using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class ScoringCategoriesController : ControllerBase
    {

        public readonly IScoringCategories db;

        public ScoringCategoriesController(IScoringCategories db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("[controller]/GetScoringCategories")]
        public Task<IEnumerable<ScoringCategories>> GetScoringCategories() => db.GetScoringCategories();
        
        [HttpPost]
        [Route("[controller]/UpsertScoringCategories")]
        public Task<int?> UpsertScoringCategories(ScoringCategories ins) => db.UpsertScoringCategories(ins);

		[HttpPost]
		[Route("[controller]/DeleteScoringCategories")]
		public Task<bool> DeleteScoringCategories(int id) => db.DeleteScoringCategory(id);
	}
}