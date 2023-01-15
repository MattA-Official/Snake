using System;

namespace Snake
{
    // Fruit Class
    class Fruit
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Fruit(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("O");
        }

        public void Eat()
        {
            Random random = new Random();

            // Make sure the fruit doesn't spawn on the snake
            do
            {
                X = random.Next(0, 10);
                Y = random.Next(0, 10);
            } while (
                GameLoop.snake.SnakeSegments.Exists(segment => segment.X == X && segment.Y == Y)
            );
        }
    }
}
