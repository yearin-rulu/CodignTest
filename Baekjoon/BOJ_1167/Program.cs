internal class Program
{
    static int V;
    static List<(int node, int distance)>[] Nodes;
    static bool[] visited;
    static int maxNode;
    static int maxDistance;
    private static void Main(string[] args)
    {
        V = Convert.ToInt32(Console.ReadLine());
        Nodes = new List<(int node, int distance)>[V+1];

        for (int i = 1; i < V+1; i++)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), x => int.Parse(x));

            Nodes[arr[0]] = new List<(int node, int distance)>();
            for (int a = 1; a < arr.Length - 1; a++)
                Nodes[arr[0]].Add((arr[a], arr[++a]));
        }
        visited = new bool[V + 1];
        DFS(1, 0);


        //maxDistance = 0;
        visited = new bool[V + 1];
        DFS(maxNode, 0);

        Console.WriteLine(maxDistance);
    }
    private static void DFS(int node, int distance)
    {
        if (visited[node]) return;

        visited[node] = true;
        if(maxDistance < distance)
        {
            maxDistance = distance;
            maxNode = node;
        }
        foreach(var next in Nodes[node])
            DFS(next.node, next.distance + distance);
    }
}