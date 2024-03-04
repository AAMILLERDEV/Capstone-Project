using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface ICheckItem
	{
		public Task<IEnumerable<CheckItem>> GetCheckItem();
		public Task<int?> UpsertCheckItem(CheckItem checkItem);
        public Task<bool> DeleteCheckItem(int id);
    }
}
