using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IAuditLog
	{
		public Task<AuditLog> GetAuditLog(int employee_ID);
		public Task<int?> UpsertAuditLog(AuditLog auditLog);
	}
}
