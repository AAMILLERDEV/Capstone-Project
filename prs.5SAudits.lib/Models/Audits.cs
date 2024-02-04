namespace prs_5SAudits.lib.Models
{
	public record struct Audits
	{
		public int ID { set; get; }
		public DateTime DateStarted { set; get; }
		public int EmployeeID { set; get; }
		public DateTime DateCompleted { set; get; }
		public int DepartmentID { set; get; }
		public int OverallScore { set; get; }
		public int AuditStatusID { set; get; }
		public string Notes { set; get; }
	}
}