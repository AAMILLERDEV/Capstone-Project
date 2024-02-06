
using Microsoft.Extensions.Options;
using prs_5SAudits.lib;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Repositories;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ConnectionStrings"));

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<ISettings, SettingsRepository>(x => new SettingsRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddSingleton<IScoringCriteria, ScoringCriteriaRepository>(x => new ScoringCriteriaRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddSingleton<IScores, ScoresRepository>(x => new ScoresRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddSingleton<IResources, ResourcesRepository>(x => new ResourcesRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddSingleton<IDepartments, DepartmentsRepository>(x => new DepartmentsRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddSingleton<IDeductions, DeductionsRepository>(x => new DeductionsRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddSingleton<ICheckItem, CheckItemRepository>(x => new CheckItemRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddSingleton<IAuditStatus, AuditStatusRepository>(x => new AuditStatusRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddSingleton<IAudits, AuditsRepository>(x => new AuditsRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddSingleton<IAuditLog, AuditLogRepository>(x => new AuditLogRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddSingleton<IActions, ActionsRepository>(x => new ActionsRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));

    builder.Services.AddCors(o => o.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    }));

    builder.Services.AddControllers();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //no comment

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthorization();
    app.UseCors();
    app.MapControllers();

    app.Run();
} catch (Exception ex)
{

}

