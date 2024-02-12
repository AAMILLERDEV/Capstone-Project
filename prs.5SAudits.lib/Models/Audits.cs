namespace prs_5SAudits.lib.Models
{
	public record struct Audits
	{
		public int? ID { set; get; }
		public DateTime DateStarted { set; get; }
		public int Employee_ID { set; get; }
		public DateTime? DateCompleted { set; get; }
		public int Department_ID { set; get; }
		public double OverallScore { set; get; }
		public int AuditStatus_ID { set; get; }
		public string? Notes { set; get; }
	}
}