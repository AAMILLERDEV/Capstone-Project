using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IScoringCriteria
	{
		public Task<IEnumerable<ScoringCriteria>> GetScoringCriteria();
		public Task<int?> UpsertScoringCriteria(ScoringCriteria scoringCriteria);
        public Task<bool> DeleteScoringCriteria(int id);
    }
}
