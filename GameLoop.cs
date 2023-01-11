using System;
using System.Threading;

namespace Snake
{
    class GameLoop
    {
        private static GameState gameState;
        private static Menu menu;
        private static Snake snake;

        public void Start()
        {
            // Hide the cursor
            Console.CursorVisible = false;

            // Set initial game state
            gameState = GameState.MENU;

            // Create a new menu
            menu = new Menu(new string[] { "Start", "Exit" });

            // Create a new snake
            snake = new Snake();

            while (true)
            {
                switch (gameState)
                {
                    // TODO: Add code for each state
                    case GameState.MENU:
                        HandleMenu();
                        break;

                    case GameState.PLAYING:
                        HandlePlaying();
                        break;

                    case GameState.PAUSED:
                        throw new NotImplementedException();
                        break;

                    case GameState.GAMEOVER:
                        throw new NotImplementedException();
                        break;
                }

                // Limit the game loop to 6 frames per second
                Thread.Sleep(1000 / 6);
            }
        }

        // Method to handle the menu
        private static void HandleMenu()
        {
            // Open the menu
            menu.OpenMenu();

            // Draw the menu
            menu.Draw();

            // Handle input
            menu.HandleInput();

            // Check if the menu is still open
            if (!menu.Open)
            {
                // Check which option was selected
                switch (menu.GetSelectedOption())
                {
                    case 0:
                        // Start the game
                        gameState = GameState.PLAYING;
                        break;

                    case 1:
                        // Exit the game
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void HandlePlaying()
        {
            // Clear the console
            Console.Clear();

            // Draw the snake
            snake.Draw();

            // Handle input
            snake.HandleInput();

            // Move the snake
            snake.Move();

            // Check for a collision
            if (snake.CheckCollision())
            {
                // Change the game state to game over
                gameState = GameState.GAMEOVER;
            }
        }
    }
}
