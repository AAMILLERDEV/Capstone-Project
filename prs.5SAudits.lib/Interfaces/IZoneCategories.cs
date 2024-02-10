using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IZoneCategories
	{
		public Task<IEnumerable<ZoneCategories>> GetZoneCategories();
		public Task<int?> UpsertZoneCategories(ZoneCategories ins);
	}
}
