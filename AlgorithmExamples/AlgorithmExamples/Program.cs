using Serilog;

using Graphs;
using Graphs.BreadthFirstSearch;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger(), dispose: true);

try
{
    builder.Services.AddTransient<BreadthFirstSearch>();

    var host = builder.Build();
    var logger = host.Services.GetRequiredService<ILogger<Program>>();

    logger.LogInformation("Application started");
    var breadthFirstSearch = host.Services.GetRequiredService<BreadthFirstSearch>();

    var root = new Node(logger, "A");
    root.Neighbours.Add(new Node(logger, "B"));
    root.Neighbours.Add(new Node(logger, "C"));
    root.Neighbours[0].Neighbours.Add(new Node(logger, "D"));
    root.Neighbours[0].Neighbours.Add(new Node(logger, "E"));
    root.Neighbours[1].Neighbours.Add(new Node(logger, "F"));
    root.Neighbours[1].Neighbours.Add(new Node(logger, "G"));
    root.Neighbours[0].Neighbours[1].Neighbours.Add(new Node(logger, "H"));
    root.Neighbours[0].Neighbours[1].Neighbours.Add(new Node(logger, "I"));
    root.Neighbours[0].Neighbours[1].Neighbours.Add(new Node(logger, "J"));
    root.Neighbours[1].Neighbours[0].Neighbours.Add(new Node(logger, "K"));
    root.Neighbours[1].Neighbours[0].Neighbours.Add(new Node(logger, "L"));
    root.Neighbours[1].Neighbours[0].Neighbours.Add(new Node(logger, "M"));
    root.Neighbours[1].Neighbours[1].Neighbours.Add(new Node(logger, "N"));
    root.Neighbours[1].Neighbours[1].Neighbours.Add(new Node(logger, "O"));
    root.Neighbours[1].Neighbours[1].Neighbours.Add(new Node(logger, "P"));
    logger.LogInformation("Nodes created \n{Nodes}", root);

    breadthFirstSearch.Run(root);
    logger.LogInformation("Application finished");
}
catch (Exception e)
{
    Log.Error(e, "Application failed: {Message}", e.Message);
}
