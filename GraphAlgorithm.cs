namespace GraphAlgorithm;

using System.Collections.Generic;

public class Graph
{
	// private поставить на prod :D
	public Dictionary<int, HashSet<int>> _adjacencyList = [];

	public void AddVertex(int vertex)
	{
		if (!_adjacencyList.ContainsKey(vertex))
		{
			_adjacencyList[vertex] = [];
		}
	}

	public void AddEdge(int source, int target)
	{
		if (_adjacencyList.ContainsKey(source) && _adjacencyList.ContainsKey(target))
		{
			_adjacencyList[source].Add(target);
		}
	}

	public List<int> FindUnreachableVertices()
	{
		var allVertices = new HashSet<int>(_adjacencyList.Keys);
		var reachableVertices = new HashSet<int>();

		foreach (var vertex in _adjacencyList.Keys)
		{
			reachableVertices.UnionWith(_adjacencyList[vertex]);
		}

		allVertices.ExceptWith(reachableVertices);

		return [.. allVertices];
	}

	public Dictionary<int, int> GetReachabilityCount()
	{
		var reachabilityCount = new Dictionary<int, int>();

		foreach (var vertex in _adjacencyList.Keys)
		{
			var visited = new HashSet<int>();
			DFS(vertex, visited);
			// Subtract 1 to exclude the vertex itself
			reachabilityCount[vertex] = visited.Count - 1;
		}

		return reachabilityCount;
	}

	private void DFS(int vertex, HashSet<int> visited)
	{
		if (visited.Contains(vertex)) return;

		visited.Add(vertex);
		foreach (var neighbor in _adjacencyList[vertex])
		{
			DFS(neighbor, visited);
		}
	}
}