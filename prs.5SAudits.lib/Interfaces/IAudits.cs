using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IAudits
	{
        public Task<Audits> GetAuditByID(int id);
        public Task<IEnumerable<Audits>> GetAudits();
		public Task<int?> UpsertAudits(Audits audits);
        public Task<bool> DeleteAudits(int id);
    }
}
