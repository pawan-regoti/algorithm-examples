using System.Collections;
using System.Text;

namespace Graphs;

public class Graph<T>(int numberOfNodes, bool isDirected = false) : IGraph<T> where T : Node
{
    private readonly int[,] _graphMatrix = new int[numberOfNodes, numberOfNodes];
    
    private readonly T[] _nodes = new T[numberOfNodes];

    public bool IsDirected() => isDirected;

    public int NumberOfNodes() => _nodes.Length;

    public int NumberOfEdges()
    {
        var numberOfEdges = 0;
        var matrixSize = _graphMatrix.GetLength(0);
        for(var i = 0; i < matrixSize; i++)
        {
            for(var j = 0; j < matrixSize; j++)
            {
                if(_graphMatrix[i, j] > 0)
                {
                    numberOfEdges++;
                }
            }
        }
        return isDirected ? numberOfEdges : numberOfEdges / 2;
    }

    public void AddEdge(T fromNode, T toNode, int weight = 1)
    {
        if (!_nodes.Contains(fromNode))
        {
            _nodes[Array.IndexOf(_nodes, null)] = fromNode;
        }
        if (!_nodes.Contains(toNode))
        {
            _nodes[Array.IndexOf(_nodes, null)] = toNode;
        }
        
        var fromNodeIndex = Array.IndexOf(_nodes, fromNode);
        var toNodeIndex = Array.IndexOf(_nodes, toNode);
        _graphMatrix[fromNodeIndex, toNodeIndex] = weight;
        if(!IsDirected())
        {
            _graphMatrix[toNodeIndex, fromNodeIndex] = weight;
        }
    }
    
    public T GetNode(int index = 0)
    {
        return _nodes[index];
    }

    public IEnumerable<T> GetNeighbours(T node)
    {
        var nodeIndex = Array.IndexOf(_nodes, node);
        var neighbours = new List<T>();
        for(var i = 0; i < _nodes.Length; i++)
        {
            if(_graphMatrix[nodeIndex, i] > 0)
            {
                neighbours.Add(_nodes[i]);
            }
        }
        return neighbours;
    }

    public int GetEdgeWeight(T fromNode, T toNode)
    {
        var fromNodeIndex = Array.IndexOf(_nodes, fromNode);
        var toNodeIndex = Array.IndexOf(_nodes, toNode);
        return _graphMatrix[fromNodeIndex, toNodeIndex];
    }
    
    public override string ToString()
    {
        var depth = 0;
        var visitedNodes = new HashSet<T>();
        var graphString = new StringBuilder();
        
        StringBuilder CreateNeighbourString(T node, int currentDepth, StringBuilder nodeString)
        {
            var neighbours = GetNeighbours(node).ToList();
            if (visitedNodes.Add(node))
            {
                nodeString.AppendLine($"{node.Name}");
            }
            
            if(neighbours.All(x=> visitedNodes.Contains(x)))
            {
                return nodeString;
            }
            
            foreach (var neighbour in neighbours)
            {
                if (visitedNodes.Add(neighbour))
                {
                    var edgeWeight = GetEdgeWeight(node, neighbour);
                    nodeString.AppendLine($"{new string(' ', currentDepth * 8)}└──({edgeWeight})──{neighbour.Name}");
                    nodeString = CreateNeighbourString(neighbour, currentDepth + 1, nodeString);
                }
            }
            return nodeString;
        }
        
        graphString = CreateNeighbourString(_nodes[0], depth, graphString);
        
        return graphString.ToString();
    }
}