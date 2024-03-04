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
        public Task<bool> DeleteAudit(int id) => db.DeleteAudit(id);

        //public async Task<int> setkeyprojectnumber(int value)
        //{
        //    var currentvalue = await getkeyprojectnumbersetting();
        //    currentvalue.settingvalue = value.tostring();
        //    return await db.sqlupsertsettings(currentvalue);
        //}

        //public async Task<int> Getkeyprojectnumber()
        //{
        //    var currentvalue = await GetKeyProjectNumberSetting();

        //    try
        //    {
        //        return int.Parse(currentvalue.settingvalue);
        //    }
        //    catch (Exception e)
        //    {
        //        var eventype_id = (await db.getalleventtypes).firstordefault(x => x.eventName == "critical").id;

        //        //short message -> e.source, long message -> "innermessage: {e.innermessage}, stacktrace: {e.stacktrace}, 
        //        //event log
        //        return -1;

        //    }
        //}

        ////Create a method to get a specific setting from the database
        //public async Task<string> GetKeyProjectNumberSetting()
        //{

        //}
    }
}
