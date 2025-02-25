namespace Graphs.DepthFirstSearch;

public class DepthFirstSearch()
{
    public void Run(Node startingNode, Graph<Node> graph, bool runInRecursiveMode = true)
    {
        if (runInRecursiveMode)
        {
            RunRecursive(startingNode, graph);
        }
        else
        {
            RunIterative(startingNode, graph);
        }
    }
    
    private void RunRecursive(Node node, Graph<Node> graph)
    {
        node.Visit();
        foreach (var neighbour in graph.GetNeighbours(node))
        {
            if (!neighbour.Visited)
            {
                RunRecursive(neighbour, graph);
            }
        }
    }
    
    private void RunIterative(Node startingNode, Graph<Node> graph)
    {
        var stack = new Stack<Node>();
        stack.Push(startingNode);
        
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            node.Visit();
            
            foreach (var neighbour in graph.GetNeighbours(node))
            {
                if (!neighbour.Visited)
                {
                    stack.Push(neighbour);
                }
            }
        }
    }
}