internal class Search
{
    int[] arr;
    bool[] visited;

    public Search(int n, int m)
    {
        arr = new int[m];
        visited = new bool[n];
    }

    public void BackTracking(int depth)
    {
        if(arr.Length == depth)
        {
            Console.WriteLine(String.Join(' ', arr));
            return;
        }
        for(int i=0; i<visited.Length; i++)
        {
            if(visited[i]==true) continue;
            arr[depth] = i+1;
            visited[i] = true;
            BackTracking(depth+1);
            visited[i] = false;
        }
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        Search search = new Search(n,m);
        search.BackTracking(0);
    }
}