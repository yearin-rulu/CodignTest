internal class Search
{
    internal static string Binary(string[] arr, string key)
    {
        int left =0, right=arr.Length-1;
        while(left<=right)
        {
            int middle = (left+right)/2;
            int isCheck = key.CompareTo(arr[middle]); 
            
            if(isCheck == 0) return "1";

            if(isCheck < 0) right = middle-1;
            else left = middle+1;
        }
        return "0";
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        string n = Console.ReadLine();
        string[] arrN = Console.ReadLine().Split(' ');
        Array.Sort(arrN);
        int m = int.Parse(Console.ReadLine());
        string[] arrM = Console.ReadLine().Split(' ');

        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        sw.AutoFlush = true;
        for(int index=0; index<m; index++)
            arrM[index] = Search.Binary(arrN, arrM[index]);
        sw.WriteLine(String.Join("\n", arrM));
        sw.Close();
    }
}