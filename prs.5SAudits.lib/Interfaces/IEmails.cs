using prs_5SAudits.lib.Models;

namespace prs_5SAudits.lib.Interfaces
{
	public interface IEmails
    {
        public Task<bool> SendSupportEmail(Email email);
    }
}
