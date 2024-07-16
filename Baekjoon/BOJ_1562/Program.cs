    internal class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int VISIT = 1 << 10;
            int MOD = 1000000000;
            //자릿수, 마지막 숫자, 사용된 숫자들의 비트 값
            int[,,] dp = new int[N, 10, VISIT];
            
            // 1의 자리수 초기
            for (int i = 1; i < 10; i++)  
                dp[0, i, 1 << i] = 1;

            for (int n = 1; n < N; n++)
            {
                for (int k = 0; k < 10; k++)
                {
                    for (int visit = 0; visit < VISIT; visit++)
                    {
                        int newVisit = visit | (1 << k);
                        if (k < 9)
                            dp[n, k, newVisit] += dp[n - 1, k + 1, visit];
                        if(k > 0)
                            dp[n, k, newVisit] += dp[n - 1, k - 1, visit];
                        dp[n, k, newVisit] %= MOD;
                    }
                }
            }
            int result = 0;
            for (int i = 0; i < 10; i++)
                result = (result + dp[N-1, i, VISIT - 1]) % MOD;
                
            Console.WriteLine(result);
        }
    }