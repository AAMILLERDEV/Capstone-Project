using Dapper;
using prs_5SAudits.lib.Models;
using System.Data;
using System.Data.SqlClient;

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
            return default;
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
			return default;
		}
	}

	public async Task<int?> UpsertActions(Actions ins)
	{
		int? insertedID = 0;

		var parameters = new DynamicParameters(new Dictionary<string, object>
		{
			{ "@id", ins.ID },
			{ "@audit_ID", ins.AuditID },
			{ "@score_ID", ins.ScoreID },
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
			return default;
		}
	}

	public async Task<int?> UpsertAuditLog(AuditLog ins)
	{
		int? insertedID = 0;

		var parameters = new DynamicParameters(new Dictionary<string, object>
		{
			{ "@id", ins.ID },
			{ "@employee_ID", ins.EmployeeID },
			{ "@previousAudit_ID", ins.PreviousAuditID }
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
			return default;
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
			{ "@employee_ID", ins.EmployeeID },
			{ "@dateCompleted", ins.DateCompleted },
			{ "@department_ID", ins.DepartmentID },
			{ "@overallScore", ins.OverallScore },
			{ "@auditStatus_ID", ins.AuditStatusID },
			{ "@notes", ins.Notes }
		});

		parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

		try
		{
			using IDbConnection connection = new SqlConnection(connectionString);
			await connection.ExecuteAsync("hist.audits_UPSERT", parameters, commandType: CommandType.StoredProcedure);
			insertedID = parameters.Get<int?>("@insertedID");
		}
		catch (Exception ex)
		{
			return default;
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
			return default;
		}

		return insertedID ?? ins.ID;
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
			{ "@category_ID", ins.CategoryID },
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
			return default;
		}

		return insertedID ?? ins.ID;
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
			return default;
		}

		return insertedID ?? ins.ID;
	}

	// DB methods for the Departments object
	public async Task<IEnumerable<Departments>> GetDepartments()
	{
		try
		{
			using IDbConnection connection = new SqlConnection(connectionString);
			return await connection.QueryAsync<Departments>("ref.departments_GET", commandType: CommandType.StoredProcedure);

		}
		catch (Exception ex)
		{
			return default;
		}
	}

	public async Task<int?> UpsertDepartments(Departments ins)
	{
		int? insertedID = 0;

		var parameters = new DynamicParameters(new Dictionary<string, object>
		{
			{ "@id", ins.ID },
			{ "@departmentName", ins.DepartmentName }
		});

		parameters.Add("@insertedID", 0, direction: ParameterDirection.Output);

		try
		{
			using IDbConnection connection = new SqlConnection(connectionString);
			await connection.ExecuteAsync("ref.departments_UPSERT", parameters, commandType: CommandType.StoredProcedure);
			insertedID = parameters.Get<int?>("@insertedID");
		}
		catch (Exception ex)
		{
			return default;
		}

		return insertedID ?? ins.ID;
	}

	// DB methods for the Resources object
	public async Task<IEnumerable<Resources>> GetResources()
	{
		try
		{
			using IDbConnection connection = new SqlConnection(connectionString);
			return await connection.QueryAsync<Resources>("hist.resources_GET", commandType: CommandType.StoredProcedure);

		}
		catch (Exception ex)
		{
			return default;
		}
	}

	public async Task<int?> UpsertResources(Resources ins)
	{
		int? insertedID = 0;

		var parameters = new DynamicParameters(new Dictionary<string, object>
		{
			{ "@id", ins.ID },
			{ "@audit_ID", ins.AuditID },
			{ "@dateAdded", ins.DateAdded },
			{ "@score_ID", ins.ScoreID }
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
			return default;
		}

		return insertedID ?? ins.ID;
	}

	// DB methods for the Scores object
	public async Task<IEnumerable<Scores>> GetScores()
	{
		try
		{
			using IDbConnection connection = new SqlConnection(connectionString);
			return await connection.QueryAsync<Scores>("hist.scores_GET", commandType: CommandType.StoredProcedure);

		}
		catch (Exception ex)
		{
			return default;
		}
	}

	public async Task<int?> UpsertScores(Scores ins)
	{
		int? insertedID = 0;

		var parameters = new DynamicParameters(new Dictionary<string, object>
		{
			{ "@id", ins.ID },
			{ "@checkItem", ins.CheckItem },
			{ "@comments", ins.Comments },
			{ "@audit_ID", ins.AuditID }
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
			return default;
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
			return default;
		}

		return insertedID ?? ins.ID;
	}
}
