namespace prs_5SAudits.lib.Models
{
	public record struct ScoringCriteria
	{
		public int ID { set; get; }
		public string Description { set; get; }
        public bool? IsDeleted { set; get; }
    }
}