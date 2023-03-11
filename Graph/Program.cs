Graph graph = new(7);
graph.InsertEdge(0, 1, 1);
graph.InsertEdge(0, 5, 1);
graph.InsertEdge(0, 6, 1);
graph.InsertEdge(1, 0, 1);
graph.InsertEdge(1, 2, 1);
graph.InsertEdge(1, 5, 1);
graph.InsertEdge(1, 6, 1);
graph.InsertEdge(2, 3, 1);
graph.InsertEdge(2, 4, 1);
graph.InsertEdge(2, 6, 1);
graph.InsertEdge(3, 4, 1);
graph.InsertEdge(4, 2, 1);
graph.InsertEdge(4, 5, 1);
graph.InsertEdge(5, 2, 1);
graph.InsertEdge(5, 3, 1);
graph.InsertEdge(6, 3, 1);
graph.DepthFirstSearch(0, new bool[graph.Vertices]);

public class Graph
{
    public int Vertices { get; private set; }
    private int[,] Matrix { get; set; }

    public Graph(int vertices)
    {
        Vertices = vertices;
        Matrix = new int[vertices, vertices];
    }

    public void InsertEdge(int u, int v, int w)
    {
        Matrix[u, v] = w;
    }

    public void DeleteEdge(int u, int v)
    {
        Matrix[u, v] = 0;
    }

    public bool EdgeExists(int u, int v)
    {
        return Matrix[u, v] != 0;
    }

    public int EdgeCount()
    {
        int count = 0;
        for(int i = 0; i < Vertices; ++i)
            for (int j = 0; j < Vertices; ++j)
                if (EdgeExists(i, j))
                    ++count;

        return count;
    }

    public void DisplayMatrix()
    {
        for (int i = 0; i < Vertices; ++i)
        {
            for (int j = 0; j < Vertices; ++j)
                    Console.Write(Matrix[i, j] + " ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void DisplayEdges()
    {
        for (int i = 0; i < Vertices; ++i)
            for (int j = 0; j < Vertices; ++j)
                if(EdgeExists(i, j))
                    Console.Write($"[{i}, {j}]");
        Console.WriteLine();
    }

    public int Outdegree(int v)
    {
        int count = 0;
        for (int i = 0; i < Vertices; ++i)
            if (EdgeExists(v, i))
                ++count;
        return count;
    }

    public int Indegree(int v)
    {
        int count = 0;
        for (int i = 0; i < Vertices; ++i)
            if (EdgeExists(i, v))
                ++count;
        return count;
    }

    public void BreadthFirstSearch(int s)
    {
        int i = s;
        Queue<int> queue = new();
        bool[] visited = new bool[Vertices];
        visited[i] = true;
        Console.Write(i + " ");
        queue.Enqueue(i);
        while (queue.TryDequeue(out i) != false)
        {
            for (int j = 0; j < Vertices; ++j)
            {
                if (EdgeExists(i, j) && visited[j] != true)
                {
                    Console.Write(j + " ");
                    visited[j] = true;
                    queue.Enqueue(j);
                }
            }
        }
    }

    public void DepthFirstSearch(int s, bool[] visited)
    {
        if (visited[s] != true)
        {
            Console.Write(s + " ");
            visited[s] = true;
            for(int j = 0; j < Vertices; ++j)
            {
                if(EdgeExists(s, j) && visited[j] != true)
                {
                    DepthFirstSearch(j, visited);
                }
            }
        }
    }
}
