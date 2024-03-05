using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IEmail
	{
		public Task<bool> CreateEmail(EventLogs eventLogs);

	}
}
