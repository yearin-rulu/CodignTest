internal class Program
{
    private static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int count = 0;
        int result = -1;
        if(n%5 == 0)
           result = n/5;
        else
        {
            while(n>0)
            {
                n=n-2;
                count++;
                if(n%5 == 0)
                {
                    result = n/5+count;
                    break;
                }
            }
        }
        Console.WriteLine(result);
    }
}