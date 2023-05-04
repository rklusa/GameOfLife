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

        public void ApplyRules(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int neighbors = 0;
                    int left = (x - 1);
                    int right = (x + 1);
                    int up = (y - 1);
                    int down = (y + 1);

                    if ((x != 0 && x < width - 1) && (y != 0 && y < height - 1)) // keep check within bounds of grid array
                    {
                        if (grid[left, up] == 1)
                        {
                            neighbors++;
                        }

                        if (grid[x, up] == 1)
                        {
                            neighbors++;
                        }

                        if (grid[right, up] == 1)
                        {
                            neighbors++;
                        }

                        if (grid[left, y] == 1)
                        {
                            neighbors++;
                        }

                        if (grid[right, y] == 1)
                        {
                            neighbors++;
                        }

                        if (grid[left, down] == 1)
                        {
                            neighbors++;
                        }

                        if (grid[x, down] == 1)
                        {
                            neighbors++;
                        }

                        if (grid[right, down] == 1)
                        {
                            neighbors++;
                        }
                    }

                    if (grid[x, y] == 1 && neighbors == 2 || neighbors == 3)
                    {
                        grid[x, y] = 1;
                    }
                    else if (grid[x, y] == 0 && neighbors == 3)
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
    }
}