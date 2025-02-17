namespace Tree.BreadthFirstSearch;

public class Node(string name)
{
    public string Name { get; set; } = name;
    public List<Node> Children { get; set; } = new();
    public bool Visited { get; set; }
}
public class BreadthFirstSearch
{
    public void Run(Node root)
    {
        var queue = new Queue<string>();
        
    }
}