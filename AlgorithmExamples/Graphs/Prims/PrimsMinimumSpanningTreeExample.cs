using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Graphs.Prims;

public class PrimsMinimumSpanningTreeExample(
    ILogger<PrimsMinimumSpanningTreeExample> logger,
    IServiceProvider serviceProvider,
    PrimsMinimumSpanningTree primsMinimumSpanningTree)
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
        var f = CreateNode("F");
        var g = CreateNode("G");
        var h = CreateNode("H");
        var i = CreateNode("I");
        var j = CreateNode("J");
        var k = CreateNode("K");
        var l = CreateNode("L");
        var m = CreateNode("M");
        var n = CreateNode("N");
        var o = CreateNode("O");
        var p = CreateNode("P");
        logger.LogInformation("Nodes created");
        
        logger.LogInformation("Creating graph");
        var graph = new Graph<Node>(16);
        graph.AddEdge(new Edge<Node>(a, b, weight: 3));
        graph.AddEdge(new Edge<Node>(a, c, weight: 3));
        graph.AddEdge(new Edge<Node>(b, d, weight: 5));
        graph.AddEdge(new Edge<Node>(b, e, weight: 3));
        graph.AddEdge(new Edge<Node>(e, h, weight: 3));
        graph.AddEdge(new Edge<Node>(e, i, weight: 5));
        graph.AddEdge(new Edge<Node>(e, j, weight: 3));
        graph.AddEdge(new Edge<Node>(c, f, weight: 3));
        graph.AddEdge(new Edge<Node>(c, g, weight: 3));
        graph.AddEdge(new Edge<Node>(f, k, weight: 5));
        graph.AddEdge(new Edge<Node>(f, l, weight: 3));
        graph.AddEdge(new Edge<Node>(f, m, weight: 3));
        graph.AddEdge(new Edge<Node>(g, n, weight: 5));
        graph.AddEdge(new Edge<Node>(g, o, weight: 3));
        graph.AddEdge(new Edge<Node>(g, p, weight: 3));
        
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