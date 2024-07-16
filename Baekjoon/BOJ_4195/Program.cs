using System.Collections;
using System.Text;

internal class Program
{
    static Hashtable Friends;
    static Hashtable size;
    private static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        int turns = Convert.ToInt32(Console.ReadLine());
        
        for (int turn = 0; turn<turns; turn++)
        {
            Friends = new Hashtable();
            size = new Hashtable();

            int lines = Convert.ToInt32(Console.ReadLine());
            for (int value = 0; value < lines; value++)
            {
                string[] arr = Console.ReadLine().Split(' ');
                string key1 = arr[0];
                string key2 = arr[1];

                if (Friends.ContainsKey(key1) == false)
                {
                    Friends.Add(key1, key1);
                    size.Add(key1, 1);
                }
                if (Friends.ContainsKey(key2) == false)
                {
                    Friends.Add(key2, key2);
                    size.Add(key2, 1);
                }
                Uion(key1, key2);
                sb.AppendLine(size[Find(key1)].ToString());
            }
        }
        Console.WriteLine(sb.ToString());
    }
    private static string Find(string key)
    {
        if (key == Friends[key])
            return key;

        Friends[key] = Find((string)Friends[key]);
        return (string)Friends[key];
    }
    private static void Uion(string key1, string key2)
    {
        key1 = Find(key1);
        key2 = Find(key2);

        if (key1 == key2)
            return;

        Friends[key2] = key1;
        size[key1] = (int)size[key1] + (int)size[key2];
    }
}