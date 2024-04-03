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

    [Fact]
    public async void GetActions()
    {
        var actions = await db.GetActions();
        Assert.NotNull(actions);
    }

    [Fact]
    public async void GetAuditLog()
    {
        var employee_ID = 999;
        var auditLogs = await db.GetAuditLog(employee_ID);
        Assert.NotNull(auditLogs);
    }

    [Fact]
    public async void GetAuditStatus()
    {
        var auditStatus = await db.GetAuditStatus();
        Assert.NotNull(auditStatus);
    }

    [Fact]
    public async void GetCheckItem()
    {
        var checkItem = await db.GetCheckItem();
        Assert.NotNull(checkItem);
    }

    [Fact]
    public async void GetDeductions()
    {
        var deductions = await db.GetDeductions();
        Assert.NotNull(deductions);
    }

    [Fact]
    public async void GetResourcesByID()
    {
        var id = 1;
        var resources = await db.GetResourcesByAuditId(1);
        Assert.NotNull(resources);
    }

    [Fact]
    public async void GetScores()
    {
        var scores = await db.GetScores();
        Assert.NotNull(scores);
    }

    [Fact]
    public async void GetScoringCategories()
    {
        var scoringCategories = await db.GetScoringCategories();
        Assert.NotNull(scoringCategories);
    }

    [Fact]
    public async void GetScoringCriteria()
    {
        var scoringCriteria = await db.GetScoringCriteria();
        Assert.NotNull(scoringCriteria);
    }

    [Fact]
    public async void GetSettings()
    {
        var settings = await db.GetSettings();
        Assert.NotNull(settings);
    }

    [Fact]
    public async void GetZoneCategories()
    {
        var zoneCategories = await db.GetZoneCategories();
        Assert.NotNull(zoneCategories);
    }

    [Fact]
    public async void GetZones()
    {
        var zones = await db.GetZones();
        Assert.NotNull(zones);
    }
}
