namespace GraphAlgorithm;

class Program
{
	static void Main(string[] args)
	{
		Graph graph = new Graph();
		graph.AddVertex(1);
		graph.AddVertex(2);
		graph.AddVertex(3);
		graph.AddVertex(4);
		graph.AddVertex(5);

		graph.AddEdge(1, 2);
		graph.AddEdge(1, 4);
		graph.AddEdge(2, 3);
		graph.AddEdge(2, 4);
		graph.AddEdge(4, 1);
		graph.AddEdge(4, 3);

		var unreachableVertices = graph.FindUnreachableVertices();
		Console.WriteLine("Unreachable Vertices:");
		unreachableVertices.ForEach(Console.WriteLine);

		var reachabilityCount = graph.GetReachabilityCount();
		Console.WriteLine("\nVertex Reachability:");
		foreach (var vertex in reachabilityCount)
		{
			Console.WriteLine($"Vertex {vertex.Key}: Can reach {vertex.Value} other vertices");
		}
	}
}