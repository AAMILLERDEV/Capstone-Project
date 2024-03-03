using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;
using System.Runtime.InteropServices;

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
        public Task<Audits> GetAuditByID(int id) => db.GetAuditByID(id);
        public Task<int?> UpsertAudits(Audits audits) => db.UpsertAudits(audits);
        public Task<Audits> DeleteAudit(int id) => db.DeleteAudit(id);

        //public async Task<int> SetKeyProjectNumber(int value)
        //{
        //    var currentValue = await GetKeyProjectNumberSetting();
        //    currentValue.SettingValue = value.ToString();
        //    return await db.SQLUpsertSettings(currentValue);
        //}

        //public async Task<int> GetKeyProjectNumber()
        //{
        //    var currentValue = await GetKeyProjectNumberSetting();

        //    try
        //    {
        //        return int.Parse(currentValue.SettingValue);
        //    }
        //    catch (Exception e)
        //    {
        //        //var eventype_ID = (await db.GetAllEventTypes).FirstOrDefault(x => x.EventTypeName == "Critical").ID;
        //        //short Message -> e.Source, long message -> "innerMessage: {e.InnerMessage}, stacktrace: {e.stackTrace}, 
        //        //Event Log
        //        return -1;

        //    }
        // }

        //Create a method to get a specific setting from the database
    }
}
