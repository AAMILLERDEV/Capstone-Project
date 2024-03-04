namespace prs_5SAudits.lib.Models
{
	public record struct Scores
	{
		public int ID { set; get; }
		public int ScoreCategory_ID { set; get; }
		public string? Comments { set; get; }
		public int Audit_ID { set; get; }
		public double Score { set; get; }
		public bool? isDeleted { set; get; }
	}
}