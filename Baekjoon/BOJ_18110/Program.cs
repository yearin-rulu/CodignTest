internal class Program
{
    private static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        if(N == 0)
        {
            Console.WriteLine(0);
            return;
        }

        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
            arr[i] = Convert.ToInt32(Console.ReadLine());

        Array.Sort(arr);

        int exception = Round(N * 0.15);
        double sum = 0;
        for (int i = exception; i < N - exception; i++)
            sum = sum + arr[i];

        int count = N - 2 * exception;
        int avg = Round(sum / count);

        Console.WriteLine(avg);
    }
    private static int Round(double value)
    {
        if (value - (int)value >= 0.5)
            return (int)value+1;
        else 
            return (int)value;
    }
}