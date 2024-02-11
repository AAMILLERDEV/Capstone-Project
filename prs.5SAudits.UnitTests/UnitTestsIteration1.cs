using Xunit;
using prs_5SAudits.lib;

namespace prs._5SAudits.UnitTests;

public class UnitTestsIteration1
{
    private readonly DBSQLRepository db;

    public UnitTestsIteration1()
    {
        db = new DBSQLRepository("Server=.;Database=prs.5SAudits;User ID=sa; Password=password;Trusted_Connection=True;");
    }

    [Fact]
    public async void GetAudits()
    {
        var audits = await db.GetAudits();
        Assert.NotNull(audits);
    }
}
