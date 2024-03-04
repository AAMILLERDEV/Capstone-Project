namespace prs_5SAudits.lib.Models
{
	public record struct Deductions
	{
		public int ID { set; get; }
		public string Description { set; get; }
        public bool? IsDeleted { set; get; }
    }
}