using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Graphs.DepthFirstSearch;

public class DepthFirstSearchExample(
    ILogger<DepthFirstSearchExample> logger,
    IServiceProvider serviceProvider,
    DepthFirstSearch depthFirstSearch)
{
    private List<Node> _nodes = new List<Node>();

    public void Run()
    {
        var graph = CreateGraph();
        logger.LogInformation("Run Depth First Search - Recursive");
        depthFirstSearch.Run(graph.GetNode(0), graph, runInRecursiveMode: true);
        logger.LogInformation("Depth First Search - Recursive finished");
    
        MarkNodesAsNotVisited();
    
        logger.LogInformation("Run Depth First Search - Iterative");
        depthFirstSearch.Run(graph.GetNode(0), graph, runInRecursiveMode: false);
        logger.LogInformation("Depth First Search - Iterative finished");
        
        MarkNodesAsNotVisited();
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
        graph.AddEdge(new Edge<Node>(a, b));
        graph.AddEdge(new Edge<Node>(a, c));
        graph.AddEdge(new Edge<Node>(b, d));
        graph.AddEdge(new Edge<Node>(b, e));
        graph.AddEdge(new Edge<Node>(e, h));
        graph.AddEdge(new Edge<Node>(e, i));
        graph.AddEdge(new Edge<Node>(e, j));
        graph.AddEdge(new Edge<Node>(c, f));
        graph.AddEdge(new Edge<Node>(c, g));
        graph.AddEdge(new Edge<Node>(f, k));
        graph.AddEdge(new Edge<Node>(f, l));
        graph.AddEdge(new Edge<Node>(f, m));
        graph.AddEdge(new Edge<Node>(g, n));
        graph.AddEdge(new Edge<Node>(g, o));
        graph.AddEdge(new Edge<Node>(g, p));
        
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
        _nodes.Add(node);
        return node;
    }
    
    void MarkNodesAsNotVisited()
    {
        _nodes.ForEach(x => x.MarkUnvisited());
    }

}