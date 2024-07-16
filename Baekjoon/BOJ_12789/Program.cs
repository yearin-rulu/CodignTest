internal class Program
{
    private static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), x => int.Parse(x));

        Stack<int> stack = new Stack<int>();

        bool isComplete = false;
        int now = 1;

        for (int idx = 0; idx < N + 1; idx++)
        {
            while (stack.Count() > 0)
            {
                if (stack.Peek() != now) break;

                stack.Pop();
                now++;
            }

            if (idx == N) break;

            if (now == arr[idx])
            {
                now++;
                continue;
            }

            stack.Push(arr[idx]);
        }

        Console.WriteLine(stack.Count() > 0 ? "Sad" : "Nice");
    }
}