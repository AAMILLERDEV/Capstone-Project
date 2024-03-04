using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
	public class EventTypesRepository : IEventTypes
	{
		private readonly IDBSQLRepository db;

		public EventTypesRepository(IOptionsMonitor<AppSettings> options)
		{
			db = new DBSQLRepository(options.CurrentValue.DbConn);
		}

		public Task<IEnumerable<EventTypes>> GetEventTypes() => db.GetEventTypes();
		public Task<int?> InsertEventTypes(EventTypes eventTypes) => db.InsertEventTypes(eventTypes);
	}
}