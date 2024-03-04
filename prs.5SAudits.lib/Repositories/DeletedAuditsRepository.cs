using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
	public class DeletedAuditsRepository : IDeletedAudits
	{
		private readonly IDBSQLRepository db;

		public DeletedAuditsRepository(IOptionsMonitor<AppSettings> options)
		{
			db = new DBSQLRepository(options.CurrentValue.DbConn);
		}

		public Task<IEnumerable<DeletedAudits>> GetDeletedAudits() => db.GetDeletedAudits();
		public Task<int?> InsertDeletedAudits(DeletedAudits deletedAudits) => db.InsertDeletedAudits(deletedAudits);
	}
}