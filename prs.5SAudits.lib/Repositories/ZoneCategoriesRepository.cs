using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class ZoneCategoriesRepository : IZoneCategories
    {
        private readonly IDBSQLRepository db;

        public ZoneCategoriesRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<ZoneCategories>> GetZoneCategories() => db.GetZoneCategories();
        public Task<int?> UpsertZoneCategories(ZoneCategories ins) => db.UpsertZoneCategories(ins);
    }
}
