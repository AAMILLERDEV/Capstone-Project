using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IDepartments
	{
		public Task<IEnumerable<Departments>> GetDepartments();
		public Task<int?> UpsertDepartments(Departments departments);
	}
}
