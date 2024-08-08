internal class Program
{
    private static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), x => int.Parse(x));
        Array.Sort(arr);
        
        long minValue = long.MaxValue;
        long[] result= new long[3];

        for(int first=0; first<n-2; first++)
        {
            int second = first+1;
            int third = n-1;
            while(second<third)
            {
                long value =  (long)arr[first]+arr[second]+arr[third];
                if(Math.Abs(minValue) > Math.Abs(value))
                {
                    minValue = value;
                    result[0] = arr[first];
                    result[1] = arr[second];
                    result[2] = arr[third];
                }
                if(value<0) second++;
                else third--;
            }
        }
        Console.WriteLine(string.Format("{0} {1} {2}", result[0], result[1], result[2]));
    }
}