using System.Collections.Generic;
internal class Gerrymandering
{
    int N, result;
    int[] count, population;
    bool[] visited;
    bool[,] graph;

    public Gerrymandering(int n)
    {
        N = n;
        population = Array.ConvertAll(Console.ReadLine().Split(" "), x => int.Parse(x));
        
        count = new int[N];
        graph = new bool[N,N];
        visited = new bool[N];

        result=99999;

        for(int idx=0; idx<N; idx++)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), x => int.Parse(x));
            for(int i=1; i<arr.Length; i++)
                graph[idx, arr[i]-1] = true;
            graph[idx, idx] = true;
        }
    }
    public int GetResult()
    {
        return result;
    }
    public void GetMinValue(int count, int depth)
    {
        if(depth > 0)
        {
            int populationA=0, populationB=0;
            int countA = 0, countB=0;
            int[] areaA = new int[depth];
            int[] areaB = new int[N-depth];
            for(int idx=0; idx<visited.Length; idx++)
            {
                if(visited[idx] == true)
                {
                    areaA[countA++]=idx;
                    populationA = populationA + population[idx];
                }
                else
                {
                    areaB[countB++]=idx;
                    populationB = populationB + population[idx];
                }
            }
            bool isCheck = true;
            // 구역은 하나 이상이다
            if(countA==0 || countB==0) isCheck = false;
            // 구역 A(true)끼리 연결 되어있어야 한다
            if(isCheck==true && CheckConnection(areaA, true) == false) isCheck = false;
            // 구역 B(false)끼리 연결 되어있어야 한다
            if(isCheck==true && CheckConnection(areaB,false) == false) isCheck = false;

            if(isCheck==true)
                result = Math.Min(Math.Abs(populationA-populationB), result);
        }
        for(int idx=count; idx<visited.Length; idx++)
        {
            if(visited[idx] == true) continue;
            visited[idx] = true;
            GetMinValue(idx, depth+1);
            visited[idx] = false;
        }
    }
    private bool CheckConnection(int[] area, bool isCheck)
    {
        int count=0;
        bool[] visit = new bool[N];
        Queue<int> que = new Queue<int>();   
        que.Enqueue(area[0]);

        while(que.Count() > 0)
        {
            int row = que.Dequeue();
            for(int idx=0; idx<N; idx++)
            {
		            // 1. 연결되있는지 확인     2. 영역 확인              3. 방문했었는지 확인
                if(graph[row, idx]==true && visited[idx]==isCheck && visit[idx] ==false)
                {
                    visit[idx]=true;
                    count++;
                    que.Enqueue(idx);
                }
            }
        }
        if(area.Length == count) return true;
        return false;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());

        var gerrymandering = new Gerrymandering(N);
        gerrymandering.GetMinValue(0, 0);
        
        int result = gerrymandering.GetResult();
        result = result == 99999 ? -1 : result;

        Console.WriteLine(result);
    }
}