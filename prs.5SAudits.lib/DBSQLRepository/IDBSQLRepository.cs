namespace prs_5SAudits.lib.Models
{
    public interface IDBSQLRepository
    {
        //Settings Methods
        public Task<IEnumerable<Settings>> GetSettings();
        public Task<int?> UpsertSettings(Settings settings);
    }
}