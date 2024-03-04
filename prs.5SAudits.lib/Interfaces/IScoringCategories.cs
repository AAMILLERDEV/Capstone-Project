using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IScoringCategories
	{
		public Task<IEnumerable<ScoringCategories>> GetScoringCategories();
		public Task<int?> UpsertScoringCategories(ScoringCategories ins);
        public Task<bool> DeleteScoringCategory(int id);
    }
}
