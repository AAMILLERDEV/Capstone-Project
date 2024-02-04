namespace prs_5SAudits.lib.Models
{
	public record struct Resources
	{
		public int ID { set; get; }
		public int AuditID { set; get; }
		public DateTime DateAdded { set; get; }
		public int ScoreID { set; get; }
	}
}