namespace prs_5SAudits.lib.Models
{
	public record struct EventTypes
	{
		public int ID { set; get; }
		public int EventType_ID { set; get; }
        public string LongMessage { set; get; }
		public DateTime? DateTime { set; get; }
    }
}