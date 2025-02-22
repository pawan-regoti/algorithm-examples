using Serilog;
using Graphs;

var builder = Host.CreateApplicationBuilder(args);
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger, dispose: true);

try
{
    builder.Services.AddGraphs();

    var host = builder.Build();
    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    var graphExample = host.Services.GetRequiredService<GraphExample>();

    logger.LogInformation("Application started");
    
    graphExample.Run();

    logger.LogInformation("Application finished");
}
catch (Exception e)
{
    Log.Error(e, "Application failed: {Message}", e.Message);
}
finally
{
    Log.Information("Application closing");
    Log.CloseAndFlush();
}
