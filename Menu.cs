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

        public void Draw(string message)
        {
            Console.Clear();

            Console.WriteLine(message);

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
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (SelectedOption > 0)
                        SelectedOption--;
                    break;

                case ConsoleKey.DownArrow:
                    if (SelectedOption < Options.Length - 1)
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
