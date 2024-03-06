using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;
using System.Runtime.InteropServices;

namespace prs_5SAudits.lib.Repositories
{
    public class AuditsRepository : IAudits
    {
        private readonly IDBSQLRepository db;

        public AuditsRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }

        public Task<IEnumerable<Audits>> GetAudits() => db.GetAudits();
        public Task<Audits> GetAuditByID(int id) => db.GetAuditByID(id);
        public Task<int?> UpsertAudits(Audits audits) => db.UpsertAudits(audits);
        public Task<bool> DeleteAudits(int id) => db.DeleteAudit(id);

        public async Task<int?> SetAuditNumber(int value)
        {
            var auditNumber = (await db.GetSettings()).FirstOrDefault(x => x.SettingKey == "AuditNumber");
            auditNumber.SettingValue = value.ToString();
            return await db.UpsertSettings(auditNumber);
        }

        public async Task<int?> GetAuditNumber()
        {
            var auditNumber = (await db.GetSettings()).FirstOrDefault(x => x.SettingKey == "AuditNumber");

            try
            {
                return int.Parse(auditNumber.SettingValue);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
