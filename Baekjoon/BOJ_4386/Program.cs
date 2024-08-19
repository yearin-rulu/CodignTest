internal class Node
{
    public double Distance;
    public int From;
    public int To;

    public Node(double distance, int from, int to)
    {
        Distance = distance;
        From = from;
        To = to;
    }
}
internal class Star
{
    public int Idx;
    public double X;
    public double Y;
    public Star(int idx, double x, double y)
    {
        Idx=idx;
        X=x;
        Y=y;
    }
}
internal class Program
{
    static int[] Parent;
    private static double FindDistance(double x, double y, double xx, double yy)
    {
        double dx = (x-xx)*(x-xx);
        double dy = (y-yy)*(y-yy);

        return Math.Sqrt(dx+dy);
    }
    private static int FindParent(int a)
    {
        if(a==Parent[a]) return a;
        else return Parent[a] = FindParent(Parent[a]);
    }
    private static bool SameParent(int a, int b)
    {
        a = FindParent(a);
        b = FindParent(b);

        if(a==b) return true;
        else return false;
    }
    private static void Union(int a, int b)
    {
        a = FindParent(a);
        b = FindParent(b);
        Parent[b]=a;
    }

    private static void Main(string[] args)
    {
        List<Node> nodes = new List<Node>();
        double result = 0;
       
        int n = Convert.ToInt32(Console.ReadLine());
        Star[] stars = new Star[n];
        Parent = new int[n];
        
        for(int i=0; i<n; i++)
        {
            double[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), x => double.Parse(x));
            stars[i] = new Star(i, arr[0], arr[1]);
            Parent[i] = i;
        }

        for(int i=0; i<n;i++)
        {
            for(int j=0; j<n; j++)
            {
                double distance = Math.Sqrt(Math.Pow(stars[i].X - stars[j].X, 2) + Math.Pow(stars[i].Y - stars[j].Y, 2));
                nodes.Add(new Node(distance, i, j));
            }
        }

        nodes = nodes.OrderBy(x=>x.Distance).ToList();
        
        foreach(var item in nodes)
        {
            if(SameParent(item.From, item.To)==false)
            {
                Union(item.From, item.To);
                result = result+item.Distance;
            }
        }
        Console.WriteLine(Math.Round(result,2));
    }
}