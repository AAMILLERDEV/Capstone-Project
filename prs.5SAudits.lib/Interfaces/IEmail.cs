using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IEmail
	{
		public Task<bool> EventLogEmail(EventLogs eventLogs);
		public Task<bool> CreateEmail(Email email);

	}
}
