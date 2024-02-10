namespace prs_5SAudits.lib.Models
{
	public record struct ZoneCategories
	{
		public int ID { set; get; }
		public string CategoryName { set; get; }
		public double Target { set; get; }
	}
}