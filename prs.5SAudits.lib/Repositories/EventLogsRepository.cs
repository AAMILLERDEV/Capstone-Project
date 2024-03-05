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

		public Task<bool> LogEmailEvent (Email email)
		{
			try
			{
				EventLogs log = new EventLogs()
				{
					EventType_ID = 2,
					ShortMessage = email.Subject,
					LongMessage = email.Body,
					DateTime = System.DateTime.Now
				};

				InsertEventLogs(log);

				return Task.FromResult(true);
			}
			catch (Exception)
			{
				return Task.FromResult(false);
				throw;
			}
		}

		public Task<bool> LogErrorEvent(Exception ex)
		{
			try
			{
				EventLogs eventLogs = new EventLogs()
				{
					EventType_ID = 1,
					ShortMessage = ex.Message,
					LongMessage = "Source: " +ex.Source + " \n" + "StackTrace: " + ex.StackTrace + " \n" + 
						"TargetSite: " + ex.TargetSite,
					DateTime = System.DateTime.Now
				};

				InsertEventLogs(eventLogs);

				return Task.FromResult(true);
			}
			catch (Exception)
			{
				return Task.FromResult(false);
				throw;
			}
		}
	}
}