namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int WIDTH = 20;
            int HEIGHT = 20;
            int generations = 10;

            Game gameOfLife = new Game(WIDTH, HEIGHT);
            gameOfLife.SeedGrid(WIDTH, HEIGHT);
            gameOfLife.DrawGrid(WIDTH, HEIGHT);
            Console.WriteLine("Press any key to start simulation");
            Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < generations; i++)
            {
                gameOfLife.ApplyRules(WIDTH, HEIGHT);
                gameOfLife.DrawGrid(WIDTH, HEIGHT);

                Console.WriteLine($"generation : {i + 1}");

                Thread.Sleep(500);

                if(i != generations - 1)
                {
                    Console.Clear();
                }  
            }
        }
    }
}