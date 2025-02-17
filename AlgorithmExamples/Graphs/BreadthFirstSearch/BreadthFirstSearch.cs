using Microsoft.Extensions.Logging;

namespace Tree.BreadthFirstSearch;

public class Node(ILogger logger,  string name)
{
    public string Name { get; set; } = name;
    public List<Node> Neighbours { get; set; } = new();
    public bool Visited { get; private set; }

    public void Visit()
    {
        Visited = true;
        logger.LogInformation("Node visited: {Name}", Name);
    }

}
public class BreadthFirstSearch
{
    public void Run(Node root)
    {
        var queue = new Queue<Node>();
        queue.Enqueue(root);

        root.Visit();

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            foreach (var neighbour in node.Neighbours)
            {
                if (!neighbour.Visited)
                {
                    queue.Enqueue(neighbour);
                    neighbour.Visit();
                }
            } 
        }

    }
}