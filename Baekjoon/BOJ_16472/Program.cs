internal class Program
{
    private static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        string input = Console.ReadLine();
        char[] str = String.IsNullOrWhiteSpace(input) == true ? new char[0] : input.ToCharArray();
        char[] tmps = new char[str.Length];
        int result = 0;
        int start=0;
        int last=0;
        while(str.Length > last)
        {
            if(str.Length-start-1 < N) break; 
            Array.Clear(tmps);
            int countType = 1;
            int tmpIdx=0;
            for(last=start; last<str.Length; last++)
            {
                bool isExists = tmps.Contains(str[last]);
                
                if(isExists==false && countType++ > N)
                    break;
                tmps[tmpIdx++] = str[last];
            }
            result = Math.Max(result, tmpIdx);
            start++;
        }
        Console.WriteLine(result);

    }
}