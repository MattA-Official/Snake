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

            X = random.Next(0, 10);
            Y = random.Next(0, 10);
        }
    }
}
