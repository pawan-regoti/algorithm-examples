using AlgorithmExamples;
using Tree.BreadthFirstSearch;

var builder = Host.CreateApplicationBuilder(args);
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

breadthFirstSearch.Run(root);
logger.LogInformation("Application finished");
