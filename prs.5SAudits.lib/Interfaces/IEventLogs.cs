﻿using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IEventLogs
	{
        public Task<IEnumerable<EventLogs>> GetEventLogs();
        public Task<int?> InsertEventLogs(EventLogs eventLog);
		public Task<bool> LogEmailEvent(Email email);
		public Task<bool> LogErrorEvent(Exception ex);

	}
}
