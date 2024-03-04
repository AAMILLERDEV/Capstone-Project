using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
	public class EventLogsRepository : IEventLogs
	{
		private readonly IDBSQLRepository db;

		public EventLogsRepository(IOptionsMonitor<AppSettings> options)
		{
			db = new DBSQLRepository(options.CurrentValue.DbConn);
		}

		public Task<IEnumerable<EventLogs>> GetEventLogs() => db.GetEventLogs();
		public Task<bool> InsertEventLogs(EventLogs eventLog) => db.InsertEventLogs(eventLog);
	}
}