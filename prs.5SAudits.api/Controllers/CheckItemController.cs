using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class CheckItemController : ControllerBase
    {

        public readonly ICheckItem db;

        public CheckItemController(ICheckItem db)
        {
            this.db = db;
        }



        
     
        [HttpGet]
        [Route("[controller]/GetCheckItem")]
        public Task<IEnumerable<CheckItem>> GetCheckItem() => db.GetCheckItem();
        
        [HttpPost]
        [Route("[controller]/UpsertCheckItem")]
        public Task<int?> UpsertCheckItem(CheckItem checkItem) => db.UpsertCheckItem(checkItem);
    }
}