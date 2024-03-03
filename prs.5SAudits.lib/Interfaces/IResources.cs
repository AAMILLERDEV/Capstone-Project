using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IResources
	{
		public Task<IEnumerable<Resources>> GetResources();
		public Task<int?> UpsertResources(Resources resources);
        //public Task<Resources> DeleteResource(int id);
    }
}
