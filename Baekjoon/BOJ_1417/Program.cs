internal class Program
{
    private static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];
        for(int num=0; num<n; num++)
            arr[num] = Convert.ToInt32(Console.ReadLine());
            
        int init = arr[0];
        int number=0;
        int index=0;
        do
        {
            (number, index) = arr.Select((n, i) => (n, i)).Max();
            arr[0] = arr[0]+1;
            arr[index] = arr[index]-1;

        }while(index!=0);

        Console.WriteLine(arr[0]-init);
    }
}