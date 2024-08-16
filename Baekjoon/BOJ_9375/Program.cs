internal class Program
{
    private static void Main(string[] args)
    {
        int testCase = Convert.ToInt32(Console.ReadLine());

        for(int c=0; c<testCase; c++)
        {
            int kind = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            for(int k=0; k<kind; k++)
            {
                string[] arr = Console.ReadLine().ToString().Split(" ");
                
                if(dic.ContainsKey(arr[1]) == false)
                    dic.Add(arr[1], new List<string>(){arr[0]});
                else 
                    dic[arr[1]].Add(arr[0]);
            }

            int result = 1;
            foreach(var key in dic.Keys)
                result = result * (dic[key].Count() + 1);

            Console.WriteLine(result-1);
        }
    }
}