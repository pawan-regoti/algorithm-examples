using Microsoft.Extensions.Logging;

namespace Graphs.Prims;

public class PrimsMinimumSpanningTree(ILogger<PrimsMinimumSpanningTree> logger)
{
    public void Run(Graph<Node> graph)
    {
        logger.LogInformation("Running Prims Minimum Spanning Tree");
        var visitedNodes = new HashSet<Node>();
        var unvisitedNodes = new HashSet<Node>(graph.GetNodes());
        var minimumSpanningTree = new List<Edge<Node>>();

        var startingNode = unvisitedNodes.First();
        visitedNodes.Add(startingNode);
        unvisitedNodes.Remove(startingNode);

        while (unvisitedNodes.Count > 0)
        {
            Edge<Node> minimumEdge = new Edge<Node>(startingNode, startingNode, int.MaxValue);
            foreach (var visitedNode in visitedNodes)
            {
                foreach (var neighbour in graph.GetNeighbours(visitedNode))
                {
                    if (visitedNodes.Contains(neighbour))
                    {
                        continue;
                    }

                    var edge = graph.GetEdge(visitedNode, neighbour);
                    if (edge.Weight < minimumEdge.Weight)
                    {
                        minimumEdge = edge;
                    }
                }
            }
            
            minimumSpanningTree.Add(minimumEdge);
            visitedNodes.Add(minimumEdge.ToNode);
            unvisitedNodes.Remove(minimumEdge.ToNode);
        }

        logger.LogInformation("Minimum Spanning Tree:");
        foreach (var edge in minimumSpanningTree)
        {
            logger.LogInformation("From: {FromNode} To: {ToNode} Weight: {Weight}", edge.FromNode.Name, edge.ToNode.Name, edge.Weight);
        }
    }
}