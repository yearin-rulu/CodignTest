internal class Program
{
    private static void Main(string[] args)
    {
        int n =  Convert.ToInt32(Console.ReadLine());
        string[] patterns = Console.ReadLine().Split("*");
        
        for(int num=0; num<n; num++)
        {
            string line = Console.ReadLine();
            string result = "NE";

            if(line.StartsWith(patterns[0]) && line.EndsWith(patterns[1]))
                result = "DA";
            
            if(patterns[0].Length+patterns[1].Length > line.Length)
                result = "NE";
            Console.WriteLine(result);
        }
    }
}