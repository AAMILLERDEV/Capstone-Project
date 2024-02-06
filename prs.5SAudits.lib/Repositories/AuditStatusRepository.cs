using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class AuditStatusRepository : IAuditStatus
    {
        private readonly IDBSQLRepository db;

        public AuditStatusRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<AuditStatus>> GetAuditStatus() => db.GetAuditStatus();
        public Task<int?> UpsertAuditStatus(AuditStatus auditStatus) => db.UpsertAuditStatus(auditStatus);
    }
}
