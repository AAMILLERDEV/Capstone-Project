using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IDeductions
	{
		public Task<IEnumerable<Deductions>> GetDeductions();
		public Task<int?> UpsertDeductions(Deductions deductions);
        public Task<Deductions> DeleteDeductions(int id);
    }
}
