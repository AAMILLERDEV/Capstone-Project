using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IScores
	{
		public Task<IEnumerable<Scores>> GetScores();
		public Task<int?> UpsertScores(Scores scores);
	}
}
