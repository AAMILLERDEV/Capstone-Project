namespace prs_5SAudits.lib.Models
{
	public record struct EventLogs
	{
		public int ID { set; get; }
		public int EventType_ID { set; get; }
		public string ShortMessage { set; get; }
		public string LongMessage { set; get; }
		public DateTime DateTime { set; get; }
	}
}