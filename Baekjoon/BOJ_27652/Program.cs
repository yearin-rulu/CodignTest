using System.Collections.Generic;
internal class Program
{
    static List<string> arrA;
    static List<string> arrB;

    private static void Main(string[] args)
    {
        arrA = new List<string>();
        arrB = new List<string>();
        int lines = int.Parse(Console.ReadLine());
        for(int line=0; line<lines; line++)
        {
            string[] str = Console.ReadLine().Split(' ');
            if(str[0]=="add")
            {
                if(str[1]=="A") arrA.Add(str[2]);
                else arrB.Add(str[2]);
            }
            else if(str[0]=="delete")
            {
                if(str[1]=="A") arrA.Remove(str[2]);
                else arrB.Remove(str[2]);
            }
            else
                Console.WriteLine(FindArr(str[1]));
        }
    }
    private static int FindArr(string str)
    {
        int count = 0;
        for(int index=1; index<str.Length; index++)
        {
            string suffix = str.Substring(0, index);
            string prefix = str.Substring(index, str.Length-index);

            int countA = arrA.Where(x=> x.StartsWith(suffix)==true).Count();
            int countB = arrB.Where(x=> x.EndsWith(prefix)==true).Count();

            count += countA*countB;
        }
        return count;
    }
}