using System.Collections.Generic;
internal class BreakTheWallAndMove
{
    public int score;
    int N,M,K;
    int[,] map;
    int[,,] visited;
    (int x,int y)[] move;
    public BreakTheWallAndMove()
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), x => int.Parse(x));
        N=arr[0];
        M=arr[1];
        K=arr[2];

        visited = new int[N,M,K+1];
        map = new int[N, M];

        for(int n=0; n<N; n++)
        {
            string tmp = Console.ReadLine();
            for(int m=0; m<tmp.Length; m++)
                map[n,m] = Convert.ToInt32(tmp.Substring(m,1));
        }
        move = new (int, int)[4];
        move[0] = (0,1);
        move[1] = (1,0);
        move[2] = (0,-1);
        move[3] = (-1,0);
    }
    public int BFS()
    {
        Queue<(int,int,int)> queue = new Queue<(int,int,int)>();
        queue.Enqueue((0,0,K));
        visited[0,0,K] = 1;

        while(queue.Count() != 0)
        {
            (int row, int column, int broken) player = queue.Dequeue();
            if(player.row == N-1 && player.column == M-1)
                return visited[player.row, player.column, player.broken];
            foreach((int x, int y) next in move)
            {
                int newRow = player.row + next.x;
                int newColumn = player.column + next.y;

                if(newRow>N-1 || newRow<0 || newColumn>M-1 || newColumn<0)
                    continue;
                    
                if(player.broken>0 && visited[newRow, newColumn, player.broken-1]==0 && map[newRow, newColumn]==1)
                {
                    visited[newRow, newColumn, player.broken-1] = visited[player.row, player.column, player.broken] + 1;
                    queue.Enqueue((newRow, newColumn, player.broken-1));
                }
                else if(visited[newRow, newColumn, player.broken]==0 && map[newRow, newColumn]==0)
                {
                    visited[newRow, newColumn, player.broken] = visited[player.row, player.column, player.broken]+1;
                    queue.Enqueue((newRow, newColumn, player.broken));
                }
            }
        }
        return -1;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var game = new BreakTheWallAndMove();
        Console.WriteLine(game.BFS());
    }
}