﻿namespace prs_5SAudits.lib.Models
{
	public record struct CheckItem
	{
		public int ID { set; get; }
		public string ItemName { set; get; }
		public int CategoryID { set; get; }
		public string Question { set; get; }
	}
}