using Serilog;

using Graphs;
using Graphs.BreadthFirstSearch;
using Graphs.DepthFirstSearch;

var builder = Host.CreateApplicationBuilder(args);
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger, dispose: true);

try
{
    builder.Services.AddTransient<BreadthFirstSearch>();
    builder.Services.AddTransient<DepthFirstSearch>();

    var host = builder.Build();
    var logger = host.Services.GetRequiredService<ILogger<Program>>();

    logger.LogInformation("Application started");

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

    logger.LogInformation("Run Breadth First Search");
    RunBreadthFirstSearch(root, host.Services);
    logger.LogInformation("Breadth First Search finished");

    MarkNodesAsNotVisited(root);
    
    logger.LogInformation("Run Depth First Search - Recursive");
    RunDepthFirstSearch(root, host.Services, runInRecursiveMode: true);
    logger.LogInformation("Depth First Search - Recursive finished");
    
    MarkNodesAsNotVisited(root);
    
    logger.LogInformation("Run Depth First Search - Iterative");
    RunDepthFirstSearch(root, host.Services, runInRecursiveMode: false);
    logger.LogInformation("Depth First Search - Iterative finished");

    MarkNodesAsNotVisited(root);

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

void MarkNodesAsNotVisited(Node root)
{
    root.MarkUnvisited();
    foreach (var neighbour in root.Neighbours)
    {
        MarkNodesAsNotVisited(neighbour);
    }
}

void RunBreadthFirstSearch(Node root, IServiceProvider serviceProvider)
{
    var breadthFirstSearch = serviceProvider.GetRequiredService<BreadthFirstSearch>();
    breadthFirstSearch.Run(root);
}

void RunDepthFirstSearch(Node root, IServiceProvider serviceProvider, bool runInRecursiveMode)
{
    var depthFirstSearch = serviceProvider.GetRequiredService<DepthFirstSearch>();
    depthFirstSearch.Run(root, runInRecursiveMode);
}
