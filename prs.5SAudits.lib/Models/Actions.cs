namespace prs_5SAudits.lib.Models
{
	public record struct Actions
	{
		public int ID { set; get; }
		public int AuditID { set; get; }
		public int ScoreID { set; get; }
		public string Message { set; get; }
	}
}