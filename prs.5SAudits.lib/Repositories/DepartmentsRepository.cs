using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Repositories
{
    public class DepartmentsRepository : IDepartments
    {
        private readonly IDBSQLRepository db;

        public DepartmentsRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<Departments>> GetDepartments() => db.GetDepartments();
        public Task<int?> UpsertDepartments(Departments departments) => db.UpsertDepartments(departments);
    }
}
