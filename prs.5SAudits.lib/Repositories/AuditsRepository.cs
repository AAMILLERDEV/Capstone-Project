using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class AuditsRepository : IAudits
    {
        private readonly IDBSQLRepository db;

        public  AuditsRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<Audits>> GetAudits() => db.GetAudits();
        public Task<int?> UpsertAudits(Audits audits) => db.UpsertAudits(audits);
    }
}
