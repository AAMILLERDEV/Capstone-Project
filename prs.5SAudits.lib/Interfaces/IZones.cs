using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IZones
	{
		public Task<IEnumerable<Zones>> GetZones();
		public Task<int?> UpsertZones(Zones ins);
        public Task<bool> DeleteZone(int id);
    }
}
