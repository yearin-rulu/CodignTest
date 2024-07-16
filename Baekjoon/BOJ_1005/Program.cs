internal class Building
{
    public int building=0;
    public int time=0;
    public int resultTime=0;
    public int visitedCount=0;
    public List<int> links=new List<int>();
}
internal class ACMCraft
{
    int lastBuilding;
    List<Building> buildinges;
    public ACMCraft()
    {   
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), x => int.Parse(x));
        int numBuilding = arr[0];
        int numLink = arr[1];

        int[] times = Array.ConvertAll(Console.ReadLine().Split(" "), x=>int.Parse(x));

        buildinges = new List<Building>();
        for(int idx=0; idx<numBuilding; idx++)
            buildinges.Add(new Building(){building=idx+1, time=times[idx]});
        for(int idx=0; idx<numLink; idx++)
        {
            int[] tmp=Array.ConvertAll(Console.ReadLine().Split(" "), x=>int.Parse(x));
            buildinges[tmp[0]-1].links.Add(tmp[1]);
            ++buildinges[tmp[1]-1].visitedCount;
        }
        lastBuilding = int.Parse(Console.ReadLine());
    }

    public int TopologicalSorting()
    {
        Queue<int> queue = new Queue<int>();
        var build = buildinges.Where(x=> x.visitedCount==0).ToList();
        foreach(var b in build)
        {
            queue.Enqueue(b.building);
            b.resultTime = b.time;
        }
        
        while(buildinges[lastBuilding-1].visitedCount>0)
        {
            int now = queue.Dequeue();
            foreach(var nextBuilding in buildinges[now-1].links)
            {
                buildinges[nextBuilding-1].resultTime = Math.Max(buildinges[nextBuilding-1].resultTime, buildinges[now-1].resultTime+buildinges[nextBuilding-1].time);
                --buildinges[nextBuilding-1].visitedCount;
                if(buildinges[nextBuilding-1].visitedCount == 0)
                    queue.Enqueue(nextBuilding);
            }
        }

        return buildinges[lastBuilding-1].resultTime;
    }
    
}
internal class Program
{
    private static void Main(string[] args)
    {
        int testCases = int.Parse(Console.ReadLine());
        for(int testCase=0; testCase<testCases; testCase++)
        {
            ACMCraft craft= new ACMCraft();
            Console.WriteLine(craft.TopologicalSorting());
        }
    }
}