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
}
