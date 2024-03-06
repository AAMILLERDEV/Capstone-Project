using Microsoft.AspNetCore.Mvc;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;

namespace prs_5SAudits.api.Controllers
{
    [ApiController]
    public class EmailController : ControllerBase
    {
        public readonly IEmails db;

        public EmailController(IEmails db)

        {
            this.db = db;
        }

        [HttpPost]
        [Route("[controller]/SendEmail")]
        public Task<bool> SendEmail(Email email) => db.SendSupportEmail(email);

    }
}