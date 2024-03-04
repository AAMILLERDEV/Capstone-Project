using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class CheckItemRepository : ICheckItem
    {
        private readonly IDBSQLRepository db;

        public CheckItemRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<CheckItem>> GetCheckItem() => db.GetCheckItem();
        public Task<int?> UpsertCheckItem(CheckItem checkItem) => db.UpsertCheckItem(checkItem);
        public Task<bool> DeleteCheckItem(int id) => db.DeleteCheckItem(id);
    }
}
