namespace prs_5SAudits.lib.Models
{
    public record struct Settings
    {
        public int ID { set; get; }
        public string SettingValue { set; get; }
        public string SettingKey { set; get; }
        public bool IsReadOnly { set; get; }
    }
}