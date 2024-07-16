public enum Color
{
    Red=0,
    Blue=1,
}
public enum Way
{
    Right=0,
    Down,
    Left,
    Up,
}
public class Ball
{
    public char[,] Bord;
    public int[,,] Visited;
    public (int x, int y) RedBall;
    public (int x, int y) BlueBall;
    public Ball(char[,] bord, int[,,] visited, (int x, int y) redBall, (int x, int y) blueBall)
    {
        Bord = bord;
        RedBall = redBall;
        BlueBall = blueBall;
        Visited = visited;
    }
}

public class Game
{
    Ball startBall;
    (int x, int y)[] MOVE;
    (int x, int y) GOAL;
    public Game()
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().ToString().Trim().Split(" "), x => int.Parse(x));
        int[,,] visited = new int[arr[0], arr[1], 2];
        char[,] bord = new char[arr[0], arr[1]];
        (int x, int y) blue = (0,0);
        (int x, int y) red = (0,0);

        for(int row = 0; row<arr[0]; row++)
        {
            string line = Console.ReadLine().ToString().Trim();
            int col = 0;
            foreach(char c in line)
            {
                bord[row,col] = c;
                visited[row,col,0]=-1;
                visited[row,col,1]=-1;

                if(bord[row,col] == 'B')
                {
                    blue = (row, col);
                    visited[row,col,1] = 0;
                }
                else if(bord[row,col] == 'R')
                {
                    red = (row, col);
                    visited[row,col,0]=0;
                }
                else if(bord[row, col] == 'O') 
                    GOAL = (row, col);
                col++;
            }
        }

        startBall = new Ball(bord, visited, red, blue);

        MOVE = new (int, int)[4];
        MOVE[(int)Way.Right] = (0,1);
        MOVE[(int)Way.Down] = (1,0);
        MOVE[(int)Way.Left] = (0,-1);
        MOVE[(int)Way.Up] = (-1,0);
    }

    public int BFS()
    {
        var queue = new Queue<Ball>();
        queue.Enqueue(startBall);
        
        while(queue.Count()>0)
        {
            var now = queue.Dequeue();
            foreach(Way way in Enum.GetValues(typeof(Way)))
            {
                var visited = (int[,,]) now.Visited.Clone();
                var red = MovingBall(ref visited, now, way, Color.Red);
                var blue = MovingBall(ref visited, now, way, Color.Blue);

                var tempBord = (char[,]) now.Bord.Clone();
                tempBord[now.RedBall.x, now.RedBall.y]='.';
                tempBord[red.x, red.y]='R';
                tempBord[now.BlueBall.x, now.BlueBall.y]='.';
                tempBord[blue.x, blue.y]='B';

                if(now.Visited[red.x, red.y, 0]==-1 || now.Visited[blue.x, blue.y, 1]==-1)
                {
                    if(visited[GOAL.x, GOAL.y, 0]>0 && visited[GOAL.x, GOAL.y, 1]>0){}
                    else
                    {
                        Ball ball = new Ball(tempBord, visited, red, blue);    
                        queue.Enqueue(ball);
                    }
                }

                if(visited[now.RedBall.x, now.RedBall.y, 0]>10)
                    return -1;
                else if(visited[GOAL.x, GOAL.y, 0]>0 && visited[GOAL.x, GOAL.y, 1]<0)
                    return visited[GOAL.x, GOAL.y, 0];
            }
        }
        return -1;
    }
    private (int x, int y) MovingBall(ref int[,,] visited, Ball now, Way way, Color color)
    {
        var nowBall = color==Color.Red ? now.RedBall : now.BlueBall;
        var tempBall = nowBall;
        var isOtherColor = false;

        while(true)
        {
            (int x, int y) nextBall = (tempBall.x+MOVE[(int)way].x, tempBall.y+MOVE[(int)way].y);

            if(now.Bord[nextBall.x, nextBall.y] == 'O')
            {
                visited[nextBall.x, nextBall.y, (int)color] = visited[nowBall.x, nowBall.y, (int)color]+1;
                tempBall = nextBall;
                break;
            }
            else if(now.Bord[nextBall.x, nextBall.y] == '#')
            {
                if(isOtherColor ==  true)
                    tempBall = (tempBall.x-MOVE[(int)way].x, tempBall.y-MOVE[(int)way].y);
                visited[tempBall.x, tempBall.y, (int)color] = visited[nowBall.x, nowBall.y, (int)color]+1;
                break;
            }
            else if(now.Bord[nextBall.x, nextBall.y] == 'R' || now.Bord[nextBall.x, nextBall.y] == 'B')
            {
                if(now.Bord[nextBall.x, nextBall.y] != Convert.ToChar(color.ToString().Substring(0,1)))
                    isOtherColor = true;
                tempBall = nextBall;
            }
            else if(now.Bord[nextBall.x, nextBall.y] == '.')
                tempBall = nextBall;
        }
        return tempBall;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Game game = new Game();
        Console.WriteLine(game.BFS());
    }
}