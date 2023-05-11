namespace GameOfLife
{
    internal class Game
    {
        int[,] grid;

        public Game(int width, int height)
        {
            grid = new int[width, height];
        }

        public void SeedGrid(int width, int height)
        {
            Random randInt = new Random();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int rnd = randInt.Next(0, 2);
                    grid[x, y] = rnd;
                }
            }
        }

        public void DrawGrid(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (grid[x, y] == 1)
                    {
                        Console.Write("#" + " ");
                    }
                    else
                    {
                        Console.Write(" " + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public int CheckNeighbors(int x, int y, int width, int height)
        {
            int neighbors = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = - 1; j <= 1; j++)
                {
                    if (x + i < 0 || x + i >= width)
                    {
                        continue;
                    }
                    if (y + j < 0 || y + j >= height)
                    {
                        continue;
                    }
                    if (x + i == x && y + j == y)
                    {
                        continue;
                    }

                    neighbors += grid[x + i, y + j];
                }
            }
            return neighbors;
        }

        public void ApplyNeighbors(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int liveNeighbors = CheckNeighbors(x, y, width, height);

                    if (grid[x, y] == 1 && liveNeighbors == 2 || liveNeighbors == 3)
                    {
                        grid[x, y] = 1;
                    }
                    else if (grid[x, y] == 0 && liveNeighbors == 3)
                    {
                        grid[x, y] = 1;
                    }
                    else
                    {
                        grid[x, y] = 0;
                    }
                }
            }
        }
    }
}