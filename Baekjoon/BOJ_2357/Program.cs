using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), x => int.Parse(x));
        int n = arr[0];
        int m= arr[1];

        int[] arrN = new int[n];
        int[] minTree = new int[4*n];
        int[] maxTree = new int[4*n];
        for(int i=0; i<n; i++)
            arrN[i] = Convert.ToInt32(Console.ReadLine());

        Init(true,0,n-1,1,minTree,arrN);
        Init(false,0,n-1,1,maxTree,arrN);
        StringBuilder sb = new StringBuilder();
        for(int i=0; i<m; i++)
        {
            int[] arrTmp = Array.ConvertAll(Console.ReadLine().Split(" "), x => int.Parse(x));

            int min = Find(true,0,n-1,1,arrTmp[0]-1,arrTmp[1]-1,minTree);
            int max = Find(false,0,n-1,1,arrTmp[0]-1,arrTmp[1]-1,maxTree);
            
            sb.Append(min + " " +  max + "\n");
        }
        Console.WriteLine(sb);
    }
    private static int Init(bool isType, int start, int end, int node, int[] tree, int[] arr)
    {
        if(start==end)
            return tree[node]=arr[start];
        
        int mid = (start+end)/2;
        int left = node*2;
        int right = left+1;

        if(isType==true)
            return tree[node]=Math.Min(Init(true,start, mid, left, tree, arr), Init(true,mid+1, end, right, tree, arr));
        else
            return tree[node]=Math.Max(Init(false,start, mid, left, tree, arr), Init(false,mid+1, end, right, tree, arr));
        
    }

    private static int Find(bool isType, int start, int end, int node, int left, int right, int[] tree)
    {            
        if(left>end || right<start) 
            return isType==true ? Int32.MaxValue : Int32.MinValue;
        if(left<=start && end<=right)
            return tree[node];

        int mid = (start+end)/2;
        if(isType==true)
            return Math.Min(Find(isType,start,mid,node*2,left,right,tree), Find(isType,mid+1,end,node*2+1,left,right,tree));
        else
            return Math.Max(Find(isType,start,mid,node*2,left,right,tree), Find(isType,mid+1,end,node*2+1,left,right,tree));
    }
}