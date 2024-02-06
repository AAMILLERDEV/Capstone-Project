using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class ActionsRepository : IActions
    {
        private readonly IDBSQLRepository db;

        public ActionsRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<Actions>> GetActions() => db.GetActions();
        public Task<int?> UpsertActions(Actions actions) => db.UpsertActions(actions);
    }
}
