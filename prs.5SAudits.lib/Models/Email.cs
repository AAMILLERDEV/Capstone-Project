using System.Net.Mail;

namespace prs_5SAudits.lib.Models
{
	public record struct Email
	{
		public string Subject { set; get; }
		public string Body { set; get; }
		public bool IsHTML { set; get; }
		public MailAddress From { set; get; }
	}
}