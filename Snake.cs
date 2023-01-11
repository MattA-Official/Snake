using System;
using System.Collections.Generic;

namespace Snake
{
    // Snake Class
    class Snake
    {
        public List<SnakeSegment> SnakeSegments { get; set; }
        public Fruit Fruit { get; set; }
        public int Direction { get; set; }

        public Snake()
        {
            SnakeSegments = new List<SnakeSegment>();
            Fruit = new Fruit(7, 5);

            // Add the head in the middle of the game area (10x10)
            SnakeSegments.Add(new SnakeSegment(5, 5));

            // Set the direction to move the snake left
            Direction = 1;
        }

        public void Draw()
        {
            foreach (SnakeSegment segment in SnakeSegments)
            {
                Console.SetCursorPosition(segment.X * 2, segment.Y);
                Console.Write(" ■");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(Fruit.X * 2, Fruit.Y);
            Console.Write(" .");
            Console.ResetColor();
        }

        // Control the snake using arrow keys
        public void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Direction = 0;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Direction = 1;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Direction = 2;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Direction = 3;
                        break;
                    default:
                        break;
                }
            }
        }

        // Move in the current direction
        public void Move()
        {
            for (int i = SnakeSegments.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Direction)
                    {
                        case 0:
                            SnakeSegments[i].Y--;
                            break;

                        case 1:
                            SnakeSegments[i].X++;
                            break;

                        case 2:
                            SnakeSegments[i].Y++;
                            break;

                        case 3:
                            SnakeSegments[i].X--;
                            break;
                    }
                }
                else
                {
                    SnakeSegments[i].X = SnakeSegments[i - 1].X;
                    SnakeSegments[i].Y = SnakeSegments[i - 1].Y;
                }
            }
        }

        // Grow the snake
        public void Grow()
        {
            SnakeSegment tail = SnakeSegments[SnakeSegments.Count - 1];

            SnakeSegments.Add(new SnakeSegment(tail.X, tail.Y));
        }

        // Check a collision with itself, the wall, or fruit
        public bool CheckCollision()
        {
            // Check if the snake collided with itself
            for (int i = 1; i < SnakeSegments.Count; i++)
            {
                if (
                    SnakeSegments[0].X == SnakeSegments[i].X
                    && SnakeSegments[0].Y == SnakeSegments[i].Y
                )
                {
                    return true;
                }
            }

            // Check if the snake collided with the wall
            if (
                SnakeSegments[0].X < 0
                || SnakeSegments[0].X > 9
                || SnakeSegments[0].Y < 0
                || SnakeSegments[0].Y > 9
            )
            {
                return true;
            }

            // Check if the snake collided with some fruit
            if (SnakeSegments[0].X == Fruit.X && SnakeSegments[0].Y == Fruit.Y)
            {
                Fruit.Eat();
                Grow();
            }

            return false;
        }
    }
}
