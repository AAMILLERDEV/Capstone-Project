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
		public Task<int?> InsertEventLogs(EventLogs eventLog) => db.InsertEventLogs(eventLog);

		public async Task<bool> LogEmailEvent (Email email)
		{
			try
			{
				EventLogs log = new EventLogs()
				{
					EventType_ID = ((await db.GetEventTypes()).FirstOrDefault(x => x.EventName == "Information").ID),
					ShortMessage = email.Subject,
					LongMessage = email.Body,
					DateTime = System.DateTime.Now
				};

				await InsertEventLogs(log);

				return true;
			}
			catch (Exception)
			{
				return false;
				throw;
			}
		}

		public async Task<bool> LogErrorEvent(Exception ex)
		{
			try
			{
				EventLogs eventLogs = new EventLogs()
				{
					EventType_ID = ((await db.GetEventTypes()).FirstOrDefault(x => x.EventName == "Error").ID),
				    ShortMessage = ex.Source,
					LongMessage = "Inner Message: " + ex.Message +  " : Stack Trace: " + ex.StackTrace,
					DateTime = System.DateTime.Now
				};

				await InsertEventLogs(eventLogs);

				return true;
			}
			catch (Exception)
			{
				return false;
				throw;
			}
		}
	}
}