using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IEventTypes
	{
		public Task<IEnumerable<EventTypes>> GetEventTypes();
		public Task<int?> InsertEventTypes(EventTypes eventTypes);

	}
}
