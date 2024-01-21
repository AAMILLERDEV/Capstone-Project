using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
    public interface ISettings
    {
        public Task<IEnumerable<Settings>> GetSettings();
        public Task<int?> UpsertSettings(Settings settings);
    }
}
