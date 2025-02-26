namespace Graphs;

public interface IGraph<T> where T : Node
{
    T[] GetNodes();
    
    bool IsDirected();
    
    int NumberOfNodes();
    
    int NumberOfEdges();
    
    void AddEdge(Edge<T> edge);
    
    T GetNode(int index = 0);

    IEnumerable<T> GetNeighbours(T node);

    Edge<T> GetEdge(T fromNode, T toNode);
    
    int GetEdgeWeight(T fromNode, T toNode);
}