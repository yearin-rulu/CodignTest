internal class Teaching
{
    string[] words;
    bool[] visited;
    int K,N;
    public int result;
    
    public Teaching(int k, int n)
    {
        result = 0;
        K = k-5;
        N=n;
        visited = new bool[26];

        var essential = new char[5]{'a','n','t','i','c'};
        foreach(var es in essential)
            visited[es-'a'] = true;
        words = new string[n];
        for(int idx=0; idx<n; idx++)
        {
            string input = Console.ReadLine();
            words[idx] = input.Substring(4,input.Length-8);
        }
    }

    public void FindMaxCount(int alpha, int depth)
    {
        if(depth==K)
        {
            int count = 0;
            for(int idx=0; idx<words.Length; idx++)
            {
                bool isCheck = true;
                foreach(var ch in words[idx])
                {
                    if(visited[ch-'a'] == false)
                    {
                        isCheck = false;
                        break;
                    }
                }
                if(isCheck==true) count++;
            }
            result = Math.Max(count, result);
            return;
        }
        for(int idx=alpha; idx<26; idx++)
        {
            if(visited[idx]==true) continue;
            visited[idx] = true;
            FindMaxCount(idx, depth+1);
            visited[idx] = false;
        }
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        int[] inputs = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), Int32.Parse);
        int N = inputs[0];
        int K = inputs[1];
        int result = 0;
            
        Teaching teaching = new Teaching(K, N);
        if(K < 5) result=0;
        else if(K == 26) result = N;
        else
        {
            teaching.FindMaxCount(0,0);
            result = teaching.result;
        }
        Console.WriteLine(result);
    }
}