internal class Shark
{
    // public char name;
    public int Row;
    public int Column;
    public int Speed;
    public int Direction;
    public int Size;
    public Shark()
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), x => int.Parse(x));
        this.Row = arr[0];
        this.Column = arr[1];
        this.Speed = arr[2];
        this.Direction = arr[3];
        this.Size = arr[4];
    }
}

internal class Program
{
    static int ROW;
    static int COLUMN;
    private static void Main(string[] args)
    {
        int result = 0;
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), x => int.Parse(x));
        ROW = arr[0]+1;
        COLUMN = arr[1]+1;
        int sharkCount = arr[2];

        int[,] map = new int[ROW+1, COLUMN+1];
        Shark[] sharks = new Shark[sharkCount+1];
        for(int i=1; i<=sharkCount; i++)
        {
            Shark shark = new Shark();
            sharks[i] = shark;
            map[shark.Row, shark.Column] = i;
        }

        
        for(int person=1; person<COLUMN; person++)
        {
            for(int row=1; row<ROW; row++)
            {
                int shark = map[row, person];
                if(shark==0) continue;
                result += sharks[shark].Size;
                sharks[shark].Size=0;
                break;
            }
            map = new int[ROW, COLUMN];
            for(int shark=1; shark<=sharkCount;shark++)
            {
                if(sharks[shark].Size==0) continue;

                MoveShark(sharks[shark]);

                int tmpShark = map[sharks[shark].Row, sharks[shark].Column];
                if(tmpShark==0)
                    map[sharks[shark].Row, sharks[shark].Column] = shark;
                else
                {
                    if(sharks[tmpShark].Size > sharks[shark].Size)
                    {
                        sharks[shark].Size=0;
                    }
                    else
                    {
                        sharks[tmpShark].Size =0;
                        map[sharks[shark].Row, sharks[shark].Column] = shark;
                    }
                }
            }
        }
        Console.WriteLine(result);
    }

    private static void MoveShark(Shark shark)
    {
        for(int s=0; s<shark.Speed; s++)
        {
            switch(shark.Direction)
            {
                case 1: //위
                    if(shark.Row>1)
                        shark.Row--;
                    else
                    {
                        shark.Row++;
                        shark.Direction=2;
                    }
                    break;
                case 2: //아래
                    if(shark.Row<ROW-1)
                        shark.Row++;
                    else
                    {
                        shark.Row--;
                        shark.Direction=1;
                    }
                    break;
                case 3: //오른쪽
                    if(shark.Column<COLUMN-1)
                        shark.Column++;
                    else
                    {
                        shark.Column--;
                        shark.Direction=4;
                    }
                    break;
                case 4: //왼쪽
                    if(shark.Column>1)
                        shark.Column--;
                    else
                    {
                        shark.Column++;
                        shark.Direction=3;
                    }
                    break;
            }
        }
    }
}