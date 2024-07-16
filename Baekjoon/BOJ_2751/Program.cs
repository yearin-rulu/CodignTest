public class Sort
{   
    // 병합정렬
    internal static int[] Merge(int[] arr)
    {
        Divide(arr, 0, arr.Length-1);
        return arr;
    }
    internal static void Divide(int[] arr, int left, int right)
    {
        if(left >= right) 
            return;
        
        int middle = (right+left)/2;
        Divide(arr, left, middle);
        Divide(arr, middle+1, right);

        Conquer(arr, left, middle, right);
    }
    internal static void Conquer(int[] arr, int left, int middle, int right)
    {
        int leftLength = middle-left+1;
        int rightLength = right-middle;

        int[] leftArr = new int[leftLength];
        int[] rightArr = new int[rightLength]; 

        for(int index=0; index<leftLength; index++)
            leftArr[index]=arr[left+index];
        for(int index=0; index<rightLength; index++)
            rightArr[index]=arr[middle+1+index];
        
        int leftIndex=0;
        int rightIndex=0;
        int totalIndex=left;

        while(leftIndex<leftLength && rightIndex<rightLength)
        {
            bool isLeft = leftArr[leftIndex] <= rightArr[rightIndex];
            arr[totalIndex] = isLeft ? leftArr[leftIndex] : rightArr[rightIndex];
            if(isLeft) leftIndex++;
            else rightIndex++;
            totalIndex++;
        }
        while(leftIndex<leftLength)
        {
            arr[totalIndex] = leftArr[leftIndex];
            leftIndex++;
            totalIndex++;
        }
        while(rightIndex<rightLength)
        {
            arr[totalIndex] = rightArr[rightIndex];
            rightIndex++;
            totalIndex++;
        }        
    }
    // 기수정렬
    internal static int[] Radix(int[] arr)
    {
        int arrLength = arr.Length, index;
        int max = Math.Abs(arr.Max()) > Math.Abs(arr.Min()) ? Math.Abs(arr.Max()).ToString().Length: Math.Abs(arr.Min()).ToString().Length;
        Queue<int>[] memoryPlus = new Queue<int>[10];        
        Queue<int>[] memoryMinus = new Queue<int>[10];
        for(index = 0; index < 10; index++)
        {
            memoryPlus[index] = new Queue<int>();
            memoryMinus[index] = new Queue<int>();
        }
        
        for(int digit=1; digit<=max; digit++)
        {
            for(index=0; index<arrLength; index++)
            {
                if(arr[index] < 0)
                    memoryMinus[(Math.Abs(arr[index]) % (int)Math.Pow(10, digit)) / (int)Math.Pow(10, digit-1)].Enqueue(arr[index]);
                else
                    memoryPlus[(Math.Abs(arr[index]) % (int)Math.Pow(10, digit)) / (int)Math.Pow(10, digit-1)].Enqueue(arr[index]);
            }

            index=0;
            for(int memoryIndex=9; memoryIndex>=0; memoryIndex--)
            {
                while(memoryMinus[memoryIndex].Count()!=0)
                    arr[index++] = memoryMinus[memoryIndex].Dequeue();
            }
            for(int memoryIndex=0; memoryIndex<10; memoryIndex++)
            {
                while(memoryPlus[memoryIndex].Count()!=0)
                    arr[index++] = memoryPlus[memoryIndex].Dequeue();
            }
        }
        return arr;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine().ToString());
        int[] arr = new int[count];
        for(int index = 0; index < count; index++)
            arr[index] = int.Parse(Console.ReadLine().ToString());

        //arr = Sort.Merge(arr);
        arr = Sort.Radix(arr);
        Console.WriteLine(String.Join("\n", arr));
    }
}