namespace prs_5SAudits.lib.Models
{
	public record struct Scores
	{
		public int ID { set; get; }
		public int CheckItem { set; get; }
		public string Comments { set; get; }
		public int AuditID { set; get; }
	}
}