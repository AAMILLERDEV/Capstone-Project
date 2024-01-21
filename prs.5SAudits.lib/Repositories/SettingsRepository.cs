using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class SettingsRepository : ISettings
    {
        private readonly IDBSQLRepository db;

        public SettingsRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }

        public Task<IEnumerable<Settings>> GetSettings() => db.GetSettings();
        public Task<int?> UpsertSettings(Settings settings) => db.UpsertSettings(settings);
    }
}
