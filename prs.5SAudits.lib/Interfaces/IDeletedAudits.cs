using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IDeletedAudits
	{
		public Task<IEnumerable<DeletedAudits>> GetDeletedAudits();
		public Task<int?> InsertDeletedAudits(DeletedAudits deletedAudits);

	}
}
