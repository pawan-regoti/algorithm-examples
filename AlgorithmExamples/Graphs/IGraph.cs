namespace Graphs;

public interface IGraph<T> where T : Node
{
    bool IsDirected();
    
    int NumberOfNodes();
    
    int NumberOfEdges();
    
    void AddEdge(T fromNode, T toNode, int weight = 1);
    
    T GetNode(int index = 0);

    IEnumerable<T> GetNeighbours(T node);

    int GetEdgeWeight(T fromNode, T toNode);
}