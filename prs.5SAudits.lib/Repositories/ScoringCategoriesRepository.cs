using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class ScoringCategoriesRepository : IScoringCategories
    {
        private readonly IDBSQLRepository db;

        public ScoringCategoriesRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<ScoringCategories>> GetScoringCategories() => db.GetScoringCategories();
        public Task<int?> UpsertScoringCategories(ScoringCategories ins) => db.UpsertScoringCategories(ins);
        //public Task<ScoringCategories> DeleteScoringCategories(int id) => db.DeleteScoringCategories(id);
    }
}
