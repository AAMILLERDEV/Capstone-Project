namespace prs_5SAudits.lib.Models
{
    public interface IDBSQLRepository
    {
        //Settings Methods
        public Task<IEnumerable<Settings>> GetSettings();
        public Task<int?> UpsertSettings(Settings settings);

		//Actions Methods
		public Task<IEnumerable<Actions>> GetActions();
		public Task<int?> UpsertActions(Actions actions);

		//AuditLog Methods
		public Task<IEnumerable<AuditLog>> GetAuditLog();
		public Task<int?> UpsertAuditLog(AuditLog auditLog);

		//Audits Methods
		public Task<IEnumerable<Audits>> GetAudits();
		public Task<int?> UpsertAudits(Audits audits);

		//AuditStatus Methods
		public Task<IEnumerable<AuditStatus>> GetAuditStatus();
		public Task<int?> UpsertAuditStatus(AuditStatus auditStatus);

		//CheckItem Methods
		public Task<IEnumerable<CheckItem>> GetCheckItem();
		public Task<int?> UpsertCheckItem(CheckItem checkItem);

		//Deductions Methods
		public Task<IEnumerable<Deductions>> GetDeductions();
		public Task<int?> UpsertDeductions(Deductions deductions);

		//Departments Methods
		public Task<IEnumerable<Departments>> GetDepartments();
		public Task<int?> UpsertDepartments(Departments departments);

		//Resources Methods
		public Task<IEnumerable<Resources>> GetResources();
		public Task<int?> UpsertResources(Resources resources);

		//Scores Methods
		public Task<IEnumerable<Scores>> GetScores();
		public Task<int?> UpsertScores(Scores scores);

		//ScoringCriteria Methods
		public Task<IEnumerable<ScoringCriteria>> GetScoringCriteria();
		public Task<int?> UpsertScoringCriteria(ScoringCriteria scoringCriteria);
	}
}