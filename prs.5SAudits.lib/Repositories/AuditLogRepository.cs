using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class AuditLogRepository : IAuditLog
    {
        private readonly IDBSQLRepository db;

        public AuditLogRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<AuditLog> GetAuditLog(int employee_ID) => db.GetAuditLog(employee_ID);
        public Task<int?> UpsertAuditLog(AuditLog audits) => db.UpsertAuditLog(audits);
    }
}
