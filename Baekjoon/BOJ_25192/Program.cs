internal class Program
{
    private static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        int count = 0;
        HashSet<string> users = new HashSet<string>();

        for(int idx=0; idx<N; idx++)
        {
            string user = Console.ReadLine();
            if(user == "ENTER")
            {
                count += users.Count();
                users.Clear();
                continue;
            }
            users.Add(user);
        }
        count += users.Count();
        Console.WriteLine(count);
    }
}