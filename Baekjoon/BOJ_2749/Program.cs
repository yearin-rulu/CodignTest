internal class Program
{
    static void Main(string[] args)
    {
        long mod = 1000000;
        long cycle = 1500000;
        long input = Convert.ToInt64(Console.ReadLine()) % cycle;
        long[] arr = new long[input+1];
        arr[0] = 0;
        arr[1] = 1;
        for (long i = 2; i < input + 1; i++)
            arr[i] = (arr[i - 2] + arr[i - 1]) % mod;
        Console.WriteLine(arr[input] % mod);
    }
}
