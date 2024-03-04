using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class ZonesRepository : IZones
    {
        private readonly IDBSQLRepository db;

        public ZonesRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<Zones>> GetZones() => db.GetZones();
        public Task<int?> UpsertZones(Zones ins) => db.UpsertZones(ins);
        public Task<bool> DeleteZone(int id) => db.DeleteZone(id);

    }
}
