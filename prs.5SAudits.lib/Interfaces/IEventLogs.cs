using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IEventLogs
	{
        public Task<IEnumerable<EventLogs>> GetEventLogs();
        public Task<bool> InsertEventLogs(EventLogs eventLog);
    }
}
