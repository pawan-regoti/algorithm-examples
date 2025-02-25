namespace Graphs;

public interface IGraph<T>
{
    bool IsDirected();
    
    int NumberOfNodes();
    
    int NumberOfEdges();
    
    void AddEdge(T fromNode, T toNode, int weight = 1);

    IEnumerable<T> GetNeighbours(T node);

    int GetEdgeWeight(T fromNode, T toNode);
}