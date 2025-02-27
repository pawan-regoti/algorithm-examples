using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Graphs.Prims;

public class PrimsMinimumSpanningTreeExample(
    ILogger<PrimsMinimumSpanningTreeExample> logger,
    IServiceProvider serviceProvider,
    PrimsMinimumSpanningTree<Node> primsMinimumSpanningTree)
{
    
    public void Run()
    {
        var graph = CreateGraph();
        
        logger.LogInformation("Running Prims Minimum Spanning Tree");
        primsMinimumSpanningTree.Run(graph);
        logger.LogInformation("Prims Minimum Spanning Tree Complete");
    }

    
    Graph<Node> CreateGraph()
    {
        logger.LogInformation("Creating nodes");
        var a = CreateNode("A");
        var b = CreateNode("B");
        var c = CreateNode("C");
        var d = CreateNode("D");
        var e = CreateNode("E");
        logger.LogInformation("Nodes created");
        
        logger.LogInformation("Creating graph");
        var graph = new Graph<Node>(5);
        graph.AddEdge(new Edge<Node>(a, b, weight: 1));
        graph.AddEdge(new Edge<Node>(a, c, weight: 7));
        graph.AddEdge(new Edge<Node>(b, c, weight: 5));
        graph.AddEdge(new Edge<Node>(b, d, weight: 4));
        graph.AddEdge(new Edge<Node>(b, e, weight: 3));
        graph.AddEdge(new Edge<Node>(d, e, weight: 2));
        graph.AddEdge(new Edge<Node>(c, e, weight: 6));
        
        logger.LogInformation("Graph created");
        
        logger.LogInformation("Is directed: {IsDirected}", graph.IsDirected());
        logger.LogInformation("Number of edges: {NumberOfEdges}", graph.NumberOfEdges());
        logger.LogInformation("Number of nodes: {NumberOfNodes}", graph.NumberOfNodes());
        logger.LogInformation("Neighbours of A: {Neighbours}", string.Join(", ", graph.GetNeighbours(a).Select(x => x.Name)));
        logger.LogInformation("Display graph: \n{Graph}", graph);

        return graph;
    }
    
    private Node CreateNode(string name)
    {
        var node = serviceProvider.GetRequiredService<Node>();
        node.Name = name;
        return node;
    }
}