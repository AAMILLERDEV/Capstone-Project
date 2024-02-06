using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class ResourcesRepository : IResources
    {
        private readonly IDBSQLRepository db;

        public ResourcesRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<Resources>> GetResources() => db.GetResources();
        public Task<int?> UpsertResources(Resources resources) => db.UpsertResources(resources);
    }
}
