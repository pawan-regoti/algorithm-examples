namespace Graphs.DepthFirstSearch;

public class DepthFirstSearch()
{
    public void Run(Node root, bool runInRecursiveMode = true)
    {
        if (runInRecursiveMode)
        {
            RunRecursive(root);
        }
        else
        {
            RunIterative(root);
        }
    }
    
    private void RunRecursive(Node root)
    {
        root.Visit();
        foreach (var neighbour in root.Neighbours)
        {
            if (!neighbour.Visited)
            {
                RunRecursive(neighbour);
            }
        }
    }
    
    private void RunIterative(Node root)
    {
        var stack = new Stack<Node>();
        stack.Push(root);
        
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            node.Visit();
            
            foreach (var neighbour in node.Neighbours)
            {
                if (!neighbour.Visited)
                {
                    stack.Push(neighbour);
                }
            }
        }
    }
}