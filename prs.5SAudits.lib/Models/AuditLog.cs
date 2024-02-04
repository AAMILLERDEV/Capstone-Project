namespace prs_5SAudits.lib.Models
{
	public record struct AuditLog
	{
		public int ID { set; get; }
		public int EmployeeID { set; get; }
		public int PreviousAuditID { set; get; }
	}
}