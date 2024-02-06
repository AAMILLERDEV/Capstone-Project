using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class ScoresRepository : IScores
    {
        private readonly IDBSQLRepository db;

        public ScoresRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<Scores>> GetScores() => db.GetScores();
        public Task<int?> UpsertScores(Scores scores) => db.UpsertScores(scores);
    }
}
