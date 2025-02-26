using Graphs.BreadthFirstSearch;
using Graphs.DepthFirstSearch;
using Graphs.Prims;
using Microsoft.Extensions.Logging;


namespace Graphs;

public class GraphExample(
    ILogger<GraphExample> logger, 
    BreadthFirstSearchExample breadthFirstSearchExample, 
    DepthFirstSearchExample depthFirstSearchExample,
    PrimsMinimumSpanningTreeExample primsMinimumSpanningTreeExample)
{
    private readonly List<Node> _nodes = new(); 
    public void Run()
    {
        
        breadthFirstSearchExample.Run();
        depthFirstSearchExample.Run();
        primsMinimumSpanningTreeExample.Run();
    }
}