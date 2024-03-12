#nullable enable
namespace GraphAlgorithm;

using Xunit;

public class GraphAlgorithmTests
{
	public class GraphTests
	{
		[Fact]
		public void AddVertex_ShouldAddVertexToGraph()
		{
			// Arrange
			var graph = new Graph();
			int vertex = 1;

			// Act
			graph.AddVertex(vertex);

			// Assert
			Assert.Contains(vertex, graph._adjacencyList.Keys);
		}

		[Fact]
		public void AddEdge_ShouldAddEdgeBetweenTwoVertices()
		{
			// Arrange
			var graph = new Graph();
			int source = 1;
			int target = 2;
			graph.AddVertex(source);
			graph.AddVertex(target);

			// Act
			graph.AddEdge(source, target);

			// Assert
			Assert.Contains(target, graph._adjacencyList[source]);
		}

		[Fact]
		public void FindUnreachableVertices_ShouldReturnUnreachableVertices()
		{
			// Arrange
			var graph = new Graph();
			graph.AddVertex(1);
			graph.AddVertex(2);
			graph.AddVertex(3);
			graph.AddEdge(1, 2);

			// Act
			List<int> unreachableVertices = graph.FindUnreachableVertices();

			// Assert
			Assert.Equal([1, 3], unreachableVertices);
		}

		[Fact]
		public void GetReachabilityCount_ShouldReturnCorrectReachabilityCount()
		{
			// Arrange
			var graph = new Graph();
			graph.AddVertex(1);
			graph.AddVertex(2);
			graph.AddVertex(3);
			graph.AddEdge(1, 2);
			graph.AddEdge(2, 3);

			// Act
			Dictionary<int, int> reachabilityCount = graph.GetReachabilityCount();

			// Assert
			Assert.Equal(new Dictionary<int, int>
			{
				{ 1, 2 },
				{ 2, 1 },
				{ 3, 0 }
			}, reachabilityCount);
		}
	}
}