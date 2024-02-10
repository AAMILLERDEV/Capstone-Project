namespace prs_5SAudits.lib.Models
{
	public record struct AuditLog
	{
		public int ID { set; get; }
		public int Employee_ID { set; get; }
		public int PreviousAudit_ID { set; get; }
	}
}