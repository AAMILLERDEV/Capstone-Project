namespace prs_5SAudits.lib.Models
{
	public record struct Actions
	{
		public int ID { set; get; }
		public int Audit_ID { set; get; }
		public int Score_ID { set; get; }
		public string Message { set; get; }

	}
}