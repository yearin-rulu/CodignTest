internal class Program
{
    private static void Main(string[] args)
    {
        int kg = int.Parse(Console.ReadLine().ToString());
        
        if(kg % 5 == 0)
        {
            Console.WriteLine(kg/5);
            return;
        }
        int count=0;
        while(kg>=3)
        {
            kg-=3;
            count+=1;
            if(kg%5==0)
            {
                Console.WriteLine(kg/5+count);
                break;
            }
            else if(kg==1 || kg==2)
                Console.WriteLine(-1);
            else if(kg==0)
                Console.WriteLine(count);
        }
    }
}