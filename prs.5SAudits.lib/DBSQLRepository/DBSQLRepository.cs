using Dapper;
using prs_5SAudits.lib.Models;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace prs_5SAudits.lib;

public class DBSQLRepository : IDBSQLRepository
{
    private string connectionString { get; }

    public DBSQLRepository(string connString)
    {
        connectionString = connString;
    }



    // DB methods for the setting object
    public async Task<IEnumerable<Settings>> GetSettings()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Settings>("ref.settings_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertSettings(Settings ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@SettingKey", ins.SettingKey },
            { "@SettingValue", ins.SettingValue },
            { "@IsReadOnly", ins.IsReadOnly }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("ref.settings_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex);
        }

        return insertedID ?? ins.ID;
    }


    // DB methods for the Actions object
    public async Task<IEnumerable<Actions>> GetActions()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Actions>("hist.actions_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertActions(Actions ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@audit_ID", ins.Audit_ID },
            { "@score_ID", ins.Score_ID },
            { "@message", ins.Message }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.actions_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }

        return insertedID ?? ins.ID;
    }

    // DB methods for the AuditLog object
    public async Task<IEnumerable<AuditLog>> GetAuditLog()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<AuditLog>("ref.auditLog_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertAuditLog(AuditLog ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@employee_ID", ins.Employee_ID },
            { "@previousAudit_ID", ins.PreviousAudit_ID }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("ref.auditLog_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex);
        }

        return insertedID ?? ins.ID;
    }

    // DB methods for the Audits object
    public async Task<IEnumerable<Audits>> GetAudits()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Audits>("hist.audits_GET", commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<Audits> GetAuditByID(int id)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Audits>("hist.auditByID_GET", new { id }, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertAudits(Audits ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@dateStarted", ins.DateStarted },
            { "@employee_ID", ins.Employee_ID },
            { "@dateCompleted", ins.DateCompleted },
            { "@Zone_ID", ins.Zone_ID },
            { "@overallScore", ins.OverallScore },
            { "@auditStatus_ID", ins.AuditStatus_ID },
            { "@notes", ins.Notes },
            { "@isDeleted", ins.IsDeleted },
            { "@AuditNumber", ins.AuditNumber }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.audits_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
            await LogSuccess("Audit added to system", ins.ToString());

        }
        catch (Exception ex)
        {
            return await LogError(ex);
        }

        return insertedID ?? ins.ID;
    }

    // DB methods for the AuditStatus object
    public async Task<IEnumerable<AuditStatus>> GetAuditStatus()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<AuditStatus>("ref.auditStatus_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertAuditStatus(AuditStatus ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@statusName", ins.StatusName }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("ref.auditStatus_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex); ;
        }

        return insertedID ?? ins.ID;
    }

    public async Task<bool> DeleteAudit(int audit_ID)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.QueryAsync<Audits>("hist.audits_DELETE", new { audit_ID }, commandType: CommandType.StoredProcedure);
            return true;

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return false;
        }
    }

    // DB methods for the CheckItem object
    public async Task<IEnumerable<CheckItem>> GetCheckItem()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<CheckItem>("ref.checkItem_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertCheckItem(CheckItem ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@itemName", ins.ItemName },
            { "@category_ID", ins.Category_ID },
            { "@question", ins.Question }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("ref.checkItem_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex); ;
        }

        return insertedID ?? ins.ID;
    }

    public async Task<bool> DeleteCheckItem(int CheckItem_ID)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.CheckItem_DELETE", new { CheckItem_ID }, commandType: CommandType.StoredProcedure);
            return true;

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return false;
        }
    }

    // DB methods for the Deductions object
    public async Task<IEnumerable<Deductions>> GetDeductions()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Deductions>("ref.deductions_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertDeductions(Deductions ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@description", ins.Description }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("ref.deductions_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex); ;
        }

        return insertedID ?? ins.ID;
    }

    public async Task<bool> DeleteDeduction(int Deduction_ID)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.QueryAsync<Resources>("hist.deductions_DELETE", new { Deduction_ID }, commandType: CommandType.StoredProcedure);
            return true;

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return false;
        }
    }

    // DB methods for the Zones object
    public async Task<IEnumerable<Zones>> GetZones()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Zones>("ref.zones_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertZones(Zones ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@departmentName", ins.ZoneName },
            { "@zoneCategory_ID", ins.ZoneCategory_ID }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("ref.zones_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex); ;
        }

        return insertedID ?? ins.ID;
    }

    public async Task<bool> DeleteZone(int Zone_ID)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.zones_DELETE", new { Zone_ID }, commandType: CommandType.StoredProcedure);
            return true;

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return false;
        }
    }

    //Zone Categories

    public async Task<IEnumerable<ZoneCategories>> GetZoneCategories()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<ZoneCategories>("ref.zoneCategories_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertZoneCategories(ZoneCategories ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@CategoryName", ins.CategoryName },
            { "@target", ins.Target }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("ref.zoneCategories_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex); ;
        }

        return insertedID ?? ins.ID;
    }

    // DB methods for the Resources object
    public async Task<IEnumerable<Resources>> GetResourcesByAuditId(int audit_ID)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Resources>("hist.resourcesByAuditID_GET", new { audit_ID }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertResources(Resources ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@audit_ID", ins.Audit_ID },
            { "@dateAdded", ins.DateAdded },
            { "@score_ID", ins.Score_ID },
            { "@isDeleted", ins.IsDeleted }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.resources_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex); ;
        }

        return insertedID ?? ins.ID;
    }

    public async Task<bool> DeleteResource(int id)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.resources_DELETE", new { id }, commandType: CommandType.StoredProcedure);
            return true;

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return false;
        }
    }

    // DB methods for the Scores object

    public async Task<IEnumerable<Scores>> GetScoresByAuditID(int audit_ID)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Scores>("hist.scoresByAudit_GET", new { audit_ID }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<IEnumerable<Scores>> GetScores()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Scores>("hist.scores_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertScores(Scores ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@scoreCategory_ID", ins.ScoreCategory_ID },
            { "@comments", ins.Comments },
            { "@audit_ID", ins.Audit_ID },
            { "@score", ins.Score },
            { "@isDeleted", ins.isDeleted }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.scores_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex); ;
        }

        return insertedID ?? ins.ID;
    }

    // DB methods for the ScoringCriteria object
    public async Task<IEnumerable<ScoringCriteria>> GetScoringCriteria()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<ScoringCriteria>("ref.scoringCriteria_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertScoringCriteria(ScoringCriteria ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@description", ins.Description }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("ref.scoringCriteria_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex);
        }

        return insertedID ?? ins.ID;
    }

    public async Task<bool> DeleteScoringCriteria(int ScoringCriteria_ID)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.scoringCriteria_DELETE", new { ScoringCriteria_ID }, commandType: CommandType.StoredProcedure);
            return true;

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return false;
        }
    }
    //Scoring Categories

    public async Task<IEnumerable<ScoringCategories>> GetScoringCategories()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<ScoringCategories>("ref.scoringCategories_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> UpsertScoringCategories(ScoringCategories ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@id", ins.ID },
            { "@CategoryName", ins.CategoryName }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("ref.scoringCategories_UPSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return default;
        }

        return insertedID ?? ins.ID;
    }
    public async Task<bool> DeleteScoringCategory(int scoringCategory_ID)

    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.ScoringCategories_DELETE", new { scoringCategory_ID }, commandType: CommandType.StoredProcedure);
            return true;
        }
        catch (Exception ex)
        {
            await LogError(ex);
            return false;

        }
    }

    //Event Types
    public async Task<IEnumerable<EventTypes>> GetEventTypes()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<EventTypes>("ref.eventTypes_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> InsertEventTypes(EventTypes ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@EventName", ins.EventName }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("ref.eventTypes_INSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex);
        }

        return insertedID ?? ins.ID;
    }

    //Event Logs
    public async Task<IEnumerable<EventLogs>> GetEventLogs()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<EventLogs>("hist.eventLogs_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> InsertEventLogs(EventLogs ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@EventType_ID", ins.EventType_ID },
            { "@ShortMessage", ins.ShortMessage },
            { "@LongMessage", ins.LongMessage },
            { "@DateTime", ins.DateTime }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.eventLogs_INSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");
        }
        catch (Exception ex)
        {
            return await LogError(ex);
        }

        return insertedID ?? ins.ID;

    }

    //Deleted Audits
    public async Task<IEnumerable<DeletedAudits>> GetDeletedAudits()
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<DeletedAudits>("hist.deletedAudits_GET", commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            await LogError(ex);
            return default;
        }
    }

    public async Task<int?> InsertDeletedAudits(DeletedAudits ins)
    {
        int? insertedID = 0;

        var parameters = new DynamicParameters(new Dictionary<string, object>
        {
            { "@Employee_ID", ins.Employee_ID },
            { "@Reason", ins.Reason },
            { "@Audit_ID", ins.Audit_ID }
        });

        parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("hist.deletedAudits_INSERT", parameters, commandType: CommandType.StoredProcedure);
            insertedID = parameters.Get<int?>("@insertedID");

        }
        catch (Exception ex)
        {
            return await LogError(ex);
        }

        return insertedID ?? ins.ID;
    }


    //Event Logger Methods

    public async Task<int?> LogError(Exception e)
    {
        EventLogs eventLog = new()
        {
            DateTime = DateTime.Now,
            EventType_ID = 1,
            ID = 0,
            LongMessage = $"Inner Exception: {e.InnerException} : Stack Trace: {e.StackTrace}",
            ShortMessage = e.Source
        };

        return await InsertEventLogs(eventLog);
    }

    public async Task<int?> LogSuccess(string shortMsg, string longMsg)
    {
        EventLogs eventLog = new()
        {
            DateTime = DateTime.Now,
            EventType_ID = 2,
            ID = 0,
            LongMessage = longMsg,
            ShortMessage = shortMsg
        };

        return await InsertEventLogs(eventLog);
    }
}
