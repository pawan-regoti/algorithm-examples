using Microsoft.Extensions.Logging;

namespace Graphs.Prims;

public class PrimsMinimumSpanningTree<T>(ILogger<PrimsMinimumSpanningTree<T>> logger) where T : Node
{
    public void Run(Graph<T> graph)
    {
        var visitedNodes = new HashSet<T>();
        var unvisitedNodes = new HashSet<T>(graph.GetNodes());
        var minimumSpanningTree = new List<Edge<T>>();

        var startingNode = unvisitedNodes.First();
        visitedNodes.Add(startingNode);
        unvisitedNodes.Remove(startingNode);

        while (unvisitedNodes.Count > 0)
        {
            Edge<T> minimumEdge = new Edge<T>(startingNode, startingNode, int.MaxValue);
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
    
    public void RunWithProrityQueue(Graph<T> graph)
    {
        var minimumSpanningTree = new List<Edge<T>>();
        var visitedNodes = new Dictionary<T, Edge<T>>();
        var unvisitedNodes = graph.GetNodes().ToDictionary(key => key, value => int.MaxValue);
        unvisitedNodes[unvisitedNodes.First().Key] = 0; // Set weight of first node to 0, as it is the starting node
        
        while (DequeueMinimumWeightNode(unvisitedNodes, out var node))
        {
            if(node is null)
            {
                break;
            }
            
            if (visitedNodes.TryGetValue(node, out var minimumEdge))
            {
                minimumSpanningTree.Add(minimumEdge);
            }

            foreach (var neighbour in graph.GetNeighbours(node))
            {
                if (!unvisitedNodes.ContainsKey(neighbour))
                {
                    continue;
                }
                
                var edge = graph.GetEdge(node, neighbour);
                if (edge.Weight >= unvisitedNodes[neighbour])
                {
                    continue;
                }
                    
                unvisitedNodes[neighbour] = edge.Weight;
                visitedNodes[neighbour] = edge;
            }
        }

        logger.LogInformation("Minimum Spanning Tree:");
        foreach (var edge in minimumSpanningTree)
        {
            logger.LogInformation("From: {FromNode} To: {ToNode} Weight: {Weight}", edge.FromNode.Name, edge.ToNode.Name, edge.Weight);
        }
    }

    private bool DequeueMinimumWeightNode(Dictionary<T, int> unvisitedNodes, out T? node)
    {
        node = null;
        var weight = int.MaxValue;
        foreach (var (key, value) in unvisitedNodes)
        {
            if (value < weight)
            {
                node = key;
                weight = value;
            }
        }

        if (node is null)
        {
            return false;
        }

        unvisitedNodes.Remove(node);
        return true;
    }
}