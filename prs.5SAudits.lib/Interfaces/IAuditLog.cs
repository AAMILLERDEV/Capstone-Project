using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IAuditLog
	{
		public Task<IEnumerable<AuditLog>> GetAuditLog();
		public Task<int?> UpsertAuditLog(AuditLog auditLog);
	}
}
