using Microsoft.Extensions.Logging;

namespace Graphs;

public class Node(ILogger<Node> logger)
{
    public string Name { get; set; } = string.Empty;
    public bool Visited { get; private set; }

    public void Visit()
    {
        Visited = true;
        logger.LogInformation("Node visited: {Name}", Name);
    }
    
    public void MarkUnvisited()
    {
        Visited = false;
    }
}