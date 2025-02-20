using Microsoft.Extensions.Logging;

namespace Graphs.BreadthFirstSearch;

public class BreadthFirstSearch(ILogger<BreadthFirstSearch> logger)
{
    public void Run(Node root)
    {
        logger.LogInformation("Running Breadth First Search");
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