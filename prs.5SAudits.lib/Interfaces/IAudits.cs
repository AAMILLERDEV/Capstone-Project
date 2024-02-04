using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IAudits
	{
		public Task<IEnumerable<Audits>> GetAudits();
		public Task<int?> UpsertAudits(Audits audits);
	}
}
