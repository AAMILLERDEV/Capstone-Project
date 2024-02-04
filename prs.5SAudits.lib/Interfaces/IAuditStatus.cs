using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IAuditStatus
	{
		public Task<IEnumerable<AuditStatus>> GetAuditStatus();
		public Task<int?> UpsertAuditStatus(AuditStatus auditStatus);
	}
}
