using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IEventLog
	{
        public Task<IEnumerable<EventLogs>> GetEventLogs();
        public Task<bool> CreateEventLog(EventLogs eventLog);
    }
}
