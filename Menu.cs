using System;

namespace Snake
{
    class Menu
    {
        private string[] Options;
        private int SelectedOption = 0;
        public bool Open { get; private set; } = true;

        public Menu(string[] options)
        {
            Options = options;
        }

        public void Draw()
        {
            Console.Clear();

            for (int i = 0; i < Options.Length; i++)
            {
                if (i == SelectedOption)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(Options[i]);
                Console.ResetColor();
            }
        }

        public void HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    SelectedOption--;
                    break;

                case ConsoleKey.DownArrow:
                    SelectedOption++;
                    break;

                case ConsoleKey.Enter:
                    Open = false;
                    break;
            }
        }

        public int GetSelectedOption()
        {
            return SelectedOption;
        }

        public void OpenMenu()
        {
            Open = true;
        }
    }
}
