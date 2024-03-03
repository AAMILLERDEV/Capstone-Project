using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class DeductionsRepository : IDeductions
    {
        private readonly IDBSQLRepository db;

        public DeductionsRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<Deductions>> GetDeductions() => db.GetDeductions();
        public Task<int?> UpsertDeductions(Deductions deductions) => db.UpsertDeductions(deductions);
        //public Task<Deductions> DeleteDeductions(int id) => db.DeleteDeductions(id);
    }
}
