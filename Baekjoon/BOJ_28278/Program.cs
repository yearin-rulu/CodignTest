using System;
using System.Collections.Generic;
using System.Text;

namespace BOJ_28278
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int line = Convert.ToInt32(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < line; i++)
            {
                string[] input = Console.ReadLine().Split();
                switch (input[0])
                {
                    case "1":
                        stack.Push(Convert.ToInt32(input[1]));
                        break;
                    case "2":
                        if (stack.Count() > 0) sb.AppendLine(stack.Pop().ToString());
                        else sb.AppendLine("-1");
                        break;
                    case "3":
                        sb.AppendLine(stack.Count().ToString());
                        break;
                    case "4":
                        if (stack.Count() > 0) sb.AppendLine("0");
                        else sb.AppendLine("1");
                        break;
                    case "5":
                        if (stack.Count() > 0) sb.AppendLine(stack.Peek().ToString()); 
                    else sb.AppendLine("-1");
                        break;
                }
            }
            Console.WriteLine(sb);
        }
    }
}