using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IScores
	{
		public Task<IEnumerable<Scores>> GetScores();
        public Task<IEnumerable<Scores>> GetScoresByAuditID(int audit_ID);
        public Task<int?> UpsertScores(Scores scores);
	}
}
