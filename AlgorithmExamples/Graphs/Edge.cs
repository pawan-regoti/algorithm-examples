namespace Graphs;

public class Edge<T>
{
    public T FromNode { get; set; }
    
    public T ToNode { get; set; }
    
    public int Weight { get; set; }
    
    public bool IsDirected { get; set; }
    
    public Edge(T fromNode, T toNode, int weight = 1, bool isDirected = false)
    {
        FromNode = fromNode;
        ToNode = toNode;
        Weight = weight;
        IsDirected = isDirected;
    }

    public Edge()
    { }

    public override string ToString()
    {
        return $"{FromNode}──({Weight})──{(IsDirected?">":"")}{ToNode}";
    }
}