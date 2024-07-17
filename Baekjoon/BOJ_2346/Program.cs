using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        int N = Convert.ToInt32(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), x=> Convert.ToInt32(x));
        bool[] visit = new bool[N];

        int now = 0;
        visit[0]=true;
        sb.Append(now+1);

        for(int i = 1; i < N; i++)
        {
            int move = arr[now];
            int count =0;
            bool isPositive = move > 0;
            while(count != Math.Abs(move))
            {
                if(isPositive==true) //양수
                    now = now+1 >= N ? 0 : now+1;
                else //음수
                    now = now-1 < 0 ? N-1: now-1;
                    
                count = visit[now] == false ? count+1 : count;
            }
            sb.Append(" " + (now+1));
            visit[now] = true;
        }
        Console.WriteLine(sb);
    }
}