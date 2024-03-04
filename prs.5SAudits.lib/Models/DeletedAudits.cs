namespace prs_5SAudits.lib.Models
{
	public record struct DeletedAudits
	{
		public int ID { set; get; }
		public int Employee_ID { set; get; }
		public string Reason { set; get; }
		public int Audit_ID { set; get; }
	}
}