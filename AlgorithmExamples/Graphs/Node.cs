using Microsoft.Extensions.Logging;

namespace Graphs;

public class Node(ILogger<Node> logger)
{
    public string Name { get; set; } = string.Empty;
    public List<Node> Neighbours { get; set; } = new();
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

    public override string ToString()
    {
        if(Neighbours.Count == 0)
        {
            return Name;
        }
        else
        {
            return $"{Name} > ({string.Join(", ", Neighbours)})";
        }
    }
}