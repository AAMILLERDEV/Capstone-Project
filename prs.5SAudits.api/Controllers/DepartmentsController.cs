using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        public readonly IDepartments db;

        public DepartmentsController(IDepartments db)
        {
            this.db = db;
        }



     
        [HttpGet]
        [Route("[controller]/GetDepartments")]
        public Task<IEnumerable<Departments>> GetDepartments() => db.GetDepartments();
        
        [HttpPost]
        [Route("[controller]/UpsertDepartments")]
        public Task<int?> UpsertDepartments(Departments departments) => db.UpsertDepartments(departments);
    }
}