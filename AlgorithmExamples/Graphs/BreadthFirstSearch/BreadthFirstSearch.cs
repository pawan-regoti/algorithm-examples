using Microsoft.Extensions.Logging;

namespace Graphs.BreadthFirstSearch;

public class BreadthFirstSearch(ILogger<BreadthFirstSearch> logger)
{
    public void Run(Node startingNode, Graph<Node> graph)
    {
        logger.LogInformation("Running Breadth First Search");
        var queue = new Queue<Node>();
        queue.Enqueue(startingNode);

        startingNode.Visit();

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            foreach (var neighbour in graph.GetNeighbours(node))
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