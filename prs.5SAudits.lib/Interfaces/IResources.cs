using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IResources
	{
        public Task<IEnumerable<Resources>> GetResourcesByAuditId(int id);
        public Task<int?> UpsertResources(Resources resources);
        public Task<bool> DeleteResource(int id);

    }
}
