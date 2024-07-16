internal class Program
{
    private static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine().ToString());
        int[] arr = new int[1000001];
        for(int idx = 2; idx <= input; idx++)
        {
            arr[idx] = arr[idx-1]+1;
            if(idx % 3 == 0)
                arr[idx] = Math.Min(arr[idx], arr[idx/3]+1);
            if(idx % 2 == 0)
                arr[idx] = Math.Min(arr[idx], arr[idx/2]+1);
        }

        Console.WriteLine(arr[input]);
    }
}