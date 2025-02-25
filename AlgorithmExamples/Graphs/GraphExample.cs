using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Graphs;

public class GraphExample(
    ILogger<GraphExample> logger, 
    IServiceProvider serviceProvider,
    BreadthFirstSearch.BreadthFirstSearch breadthFirstSearch, 
    DepthFirstSearch.DepthFirstSearch depthFirstSearch)
{
    private readonly List<Node> _nodes = new(); 
    public void Run()
    {
        
        var graph = CreateGraph();
        
        logger.LogInformation("Run Breadth First Search");
        RunBreadthFirstSearch(graph);
        logger.LogInformation("Breadth First Search finished");

        MarkNodesAsNotVisited();
    
        logger.LogInformation("Run Depth First Search - Recursive");
        RunDepthFirstSearch(graph, runInRecursiveMode: true);
        logger.LogInformation("Depth First Search - Recursive finished");
    
        MarkNodesAsNotVisited();
    
        logger.LogInformation("Run Depth First Search - Iterative");
        RunDepthFirstSearch(graph, runInRecursiveMode: false);
        logger.LogInformation("Depth First Search - Iterative finished");

        MarkNodesAsNotVisited();

    }
    
    
    Graph<Node> CreateGraph()
    {
        logger.LogInformation("Creating nodes");
        logger.LogInformation(@"
            A
            ├── B
            │   ├── D
            │   └── E
            │       ├── H
            │       ├── I
            │       └── J
            └── C
                ├── F
                │   ├── K
                │   ├── L
                │   └── M
                │
                └── G
                    ├── N
                    ├── O
                    └── P
        ");
        
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
        
        var graph = new Graph<Node>(16);
        graph.AddEdge(a, b);
        graph.AddEdge(a, c);
        graph.AddEdge(b, d);
        graph.AddEdge(b, e);
        graph.AddEdge(e, h);
        graph.AddEdge(e, i);
        graph.AddEdge(e, j);
        graph.AddEdge(c, f);
        graph.AddEdge(c, g);
        graph.AddEdge(f, k);
        graph.AddEdge(f, l);
        graph.AddEdge(f, m);
        graph.AddEdge(g, n);
        graph.AddEdge(g, o);
        graph.AddEdge(g, p);
        
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

    void RunBreadthFirstSearch(Graph<Node> graph)
    {
        breadthFirstSearch.Run(graph.GetNode(0), graph);
    }

    void RunDepthFirstSearch(Graph<Node> graph, bool runInRecursiveMode)
    {
        depthFirstSearch.Run(graph.GetNode(0), graph, runInRecursiveMode);
    }

}