internal class SearchGraph
{
    public int[,] graph;
    public SearchGraph(int node)
    {
        graph = new int[node + 1, node + 1];
    }
    public void CreateGraph(int link)
    {
        for(int index = 0; index < link; index++)
        {
            var line = Console.ReadLine();
            int[] input = Array.ConvertAll(line.Split(' '), Int32.Parse);
            graph[input[0],input[1]] = 1;
            graph[input[1], input[0]] = 1;
        }
    }
    public List<string> SearchDfs(int startNode)
    {
        List<string> visit = new List<string>();
        List<string> stack = new List<string>();
        stack.Add(startNode.ToString());
        string node = string.Empty;
        while (stack.Count > 0)
        {
            if (visit.Count == graph.GetLength(0) - 1) break;
            node = stack.Last();
            stack.RemoveAt(stack.Count - 1);
            if (visit.Contains(node) == false)
            {
                visit.Add(node);
                for (int col = graph.GetLength(0) - 1; col >= 0; col--)
                    if(graph[Int32.Parse(node), col] == 1)
                        stack.Add((col).ToString());
            }
        }
        return visit;
    }
    public List<string> SearchBfs(int startNode)
    {
        List<string> visit = new List<string>();
        List<string> queue = new List<string>();
        queue.Add(startNode.ToString());
        string node = string.Empty;
        while (queue.Count > 0)
        {
            if (visit.Count == graph.GetLength(0) - 1) break;
            node = queue.First();
            queue.RemoveAt(0);
            if (visit.Contains(node) == false)
            {
                visit.Add(node);
                for (int col = 0; col < graph.GetLength(0); col++)
                    if (graph[Int32.Parse(node), col] == 1)
                        queue.Add((col).ToString());
            }
        }
        return visit;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Start();
    }
    private static void Start()
    {
        var line = Console.ReadLine();
        int[] values = Array.ConvertAll<string, int>(line.Split(' '), Int32.Parse);
        List<string> output = new List<string>();
        SearchGraph graph = new SearchGraph(values[0]);
        graph.CreateGraph(values[1]);
        
        Console.WriteLine(string.Join(' ', graph.SearchDfs(values[2])));
        Console.WriteLine(string.Join(' ', graph.SearchBfs(values[2])));
    }
}