namespace prs_5SAudits.lib.Models
{
    public interface IDBSQLRepository
    {
        //Settings Methods

		//Add get settings method for a particular setting -> get the setting by settingKey in the stored proc
        public Task<IEnumerable<Settings>> GetSettings();
        public Task<int?> UpsertSettings(Settings settings);

        //public Task<Settings> GetSettingBySettingKey(string SettingKey);

        //Actions Methods
        public Task<IEnumerable<Actions>> GetActions();
		public Task<int?> UpsertActions(Actions actions);

		//AuditLog Methods
		public Task<IEnumerable<AuditLog>> GetAuditLog();
		public Task<int?> UpsertAuditLog(AuditLog auditLog);
		public Task<bool> DeleteAudit(int id);

        //Audits Methods
        public Task<IEnumerable<Audits>> GetAudits();
        public Task<Audits> GetAuditByID(int id);
        public Task<int?> UpsertAudits(Audits audits);

		//AuditStatus Methods
		public Task<IEnumerable<AuditStatus>> GetAuditStatus();
		public Task<int?> UpsertAuditStatus(AuditStatus auditStatus);

		//CheckItem Methods
		public Task<IEnumerable<CheckItem>> GetCheckItem();
		public Task<int?> UpsertCheckItem(CheckItem checkItem);
        public Task<bool> DeleteCheckItem(int id);

        //Deductions Methods
        public Task<IEnumerable<Deductions>> GetDeductions();
		public Task<int?> UpsertDeductions(Deductions deductions);
        public Task<bool> DeleteDeduction(int id);

        //Zones Methods
        public Task<IEnumerable<Zones>> GetZones();
		public Task<int?> UpsertZones(Zones ins);
        public Task<bool> DeleteZone(int id);

        //Zone Categories
        public Task<IEnumerable<ZoneCategories>> GetZoneCategories();
        public Task<int?> UpsertZoneCategories(ZoneCategories ins);


		//Resources Methods
		public Task<IEnumerable<Resources>> GetResourcesByAuditId(int audit_ID);
        public Task<int?> UpsertResources(Resources resources);
        public Task<bool> DeleteResource(int id);

        //Scores Methods
        public Task<IEnumerable<Scores>> GetScores();
        public Task<IEnumerable<Scores>> GetScoresByAuditID(int audit_ID);
        public Task<int?> UpsertScores(Scores scores);

		//ScoringCriteria Methods
		public Task<IEnumerable<ScoringCriteria>> GetScoringCriteria();
		public Task<int?> UpsertScoringCriteria(ScoringCriteria scoringCriteria);
        public Task<bool> DeleteScoringCriteria(int id);

        //Scoring Categories
        public Task<IEnumerable<ScoringCategories>> GetScoringCategories();
        public Task<int?> UpsertScoringCategories(ScoringCategories ins);
		public Task<bool> DeleteScoringCategory(int id);

		//Event Types
		public Task<IEnumerable<EventTypes>> GetEventTypes();
		public Task<int?> InsertEventTypes(EventTypes ins);

		//Event Logs
		public Task<IEnumerable<EventLogs>> GetEventLogs();
		public Task<bool> InsertEventLogs(EventLogs ins);

		//Deleted Audits
		public Task<IEnumerable<DeletedAudits>> GetDeletedAudits();
		public Task<int?> InsertDeletedAudits(DeletedAudits ins);

		//Email
		//public Task<bool> CreateEmail(EventLogs eventLogs);
	}
}