﻿using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IEmailRepository
	{
		public Task<bool> CreateEmail(EventLogs eventLogs);

	}
}
