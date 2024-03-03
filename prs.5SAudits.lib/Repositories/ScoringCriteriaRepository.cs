using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class ScoringCriteriaRepository : IScoringCriteria
    {
        private readonly IDBSQLRepository db;

        public ScoringCriteriaRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<ScoringCriteria>> GetScoringCriteria() => db.GetScoringCriteria();
        public Task<int?> UpsertScoringCriteria(ScoringCriteria scoringCriteria) => db.UpsertScoringCriteria(scoringCriteria);
        public Task<ScoringCriteria> DeleteScoringCriteria(int id) => db.DeleteScoringCriteria(id);
    }
}
