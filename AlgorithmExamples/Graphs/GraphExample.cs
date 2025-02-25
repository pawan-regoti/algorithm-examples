using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Graphs;

public class GraphExample(
    ILogger<GraphExample> logger, 
    IServiceProvider serviceProvider,
    BreadthFirstSearch.BreadthFirstSearch breadthFirstSearch, 
    DepthFirstSearch.DepthFirstSearch depthFirstSearch)
{
    public void Run()
    {
        
        var root = CreateGraph(serviceProvider);

        logger.LogInformation("Nodes created \n{NodeHierarchy}", root.GetNodeHierarchy());

        logger.LogInformation("Run Breadth First Search");
        RunBreadthFirstSearch(root);
        logger.LogInformation("Breadth First Search finished");

        MarkNodesAsNotVisited(root);
    
        logger.LogInformation("Run Depth First Search - Recursive");
        RunDepthFirstSearch(root, runInRecursiveMode: true);
        logger.LogInformation("Depth First Search - Recursive finished");
    
        MarkNodesAsNotVisited(root);
    
        logger.LogInformation("Run Depth First Search - Iterative");
        RunDepthFirstSearch(root, runInRecursiveMode: false);
        logger.LogInformation("Depth First Search - Iterative finished");

        MarkNodesAsNotVisited(root);

    }
    
    
    Node CreateGraph(IServiceProvider serviceProvider)
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

        var root = CreateNode("A");
        root.Neighbours.Add(CreateNode("B"));
        root.Neighbours.Add(CreateNode("C"));
        root.Neighbours[0].Neighbours.Add(CreateNode("D"));
        root.Neighbours[0].Neighbours.Add(CreateNode("E"));
        root.Neighbours[1].Neighbours.Add(CreateNode("F"));
        root.Neighbours[1].Neighbours.Add(CreateNode("G"));
        root.Neighbours[0].Neighbours[1].Neighbours.Add(CreateNode("H"));
        root.Neighbours[0].Neighbours[1].Neighbours.Add(CreateNode("I"));
        root.Neighbours[0].Neighbours[1].Neighbours.Add(CreateNode("J"));
        root.Neighbours[1].Neighbours[0].Neighbours.Add(CreateNode("K"));
        root.Neighbours[1].Neighbours[0].Neighbours.Add(CreateNode("L"));
        root.Neighbours[1].Neighbours[0].Neighbours.Add(CreateNode("M"));
        root.Neighbours[1].Neighbours[1].Neighbours.Add(CreateNode("N"));
        root.Neighbours[1].Neighbours[1].Neighbours.Add(CreateNode("O"));
        root.Neighbours[1].Neighbours[1].Neighbours.Add(CreateNode("P"));
           
        return root;
    }
    
    private Node CreateNode(string name)
    {
        var node = serviceProvider.GetRequiredService<Node>();
        node.Name = name;
        return node;
    }

    void MarkNodesAsNotVisited(Node root)
    {
        root.MarkUnvisited();
        foreach (var neighbour in root.Neighbours)
        {
            MarkNodesAsNotVisited(neighbour);
        }
    }

    void RunBreadthFirstSearch(Node root)
    {
        breadthFirstSearch.Run(root);
    }

    void RunDepthFirstSearch(Node root, bool runInRecursiveMode)
    {
        depthFirstSearch.Run(root, runInRecursiveMode);
    }

}