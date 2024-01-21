
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

