using Microsoft.Extensions.Logging;

namespace Graphs.DepthFirstSearch;

public class DepthFirstSearch(ILogger<DepthFirstSearch> logger)
{
    public void Run(Node root)
    {
        root.Visit();
        foreach (var neighbour in root.Neighbours)
        {
            if (!neighbour.Visited)
            {
                Run(neighbour);
            }
        }
    }
}