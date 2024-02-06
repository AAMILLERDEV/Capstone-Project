using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class DeductionsController : ControllerBase
    {

        public readonly IDeductions db;

        public DeductionsController(IDeductions db)
        {
            this.db = db;
        }



        
     
        [HttpGet]
        [Route("[controller]/GetDeductions")]
        public Task<IEnumerable<Deductions>> GetDeductions() => db.GetDeductions();
        
        [HttpPost]
        [Route("[controller]/UpsertDeductions")]
        public Task<int?> UpsertDeductions(Deductions deductions) => db.UpsertDeductions(deductions);
    }
}