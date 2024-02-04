using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IActions
	{
		public Task<IEnumerable<Actions>> GetActions();
		public Task<int?> UpsertActions(Actions actions);
	}
}
