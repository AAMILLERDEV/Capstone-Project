namespace prs_5SAudits.lib.Models
{
	public record struct Zones
	{
		public int ID { set; get; }
		public string ZoneName { set; get; }
		public int ZoneCategory_ID { set; get; }
	}
}