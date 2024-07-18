internal class Program
{
    private static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        int K = Convert.ToInt32(Console.ReadLine());
        
        int start = 1;
        int end = K;
        int result = -1;
        
        while(start <= end)
        {
            int cnt =0;
            int mid = (start+end)/2;
            for(int i=1; i<=N; i++)
                cnt = cnt + Math.Min(mid/i, N);
            if(cnt<K)
                start = mid+1;
            else
            {
                result = mid;
                end = mid-1;
            }
        }
        Console.WriteLine(result);
    }
}