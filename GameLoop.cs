using System;
using System.Threading;

namespace Snake
{
    class GameLoop
    {
        private static GameState gameState;
        private static Menu menu;
        private static Menu gameOverMenu;
        private static Menu pauseMenu;
        private static Snake snake;

        public void Start()
        {
            // Hide the cursor
            Console.CursorVisible = false;

            // Set initial game state
            gameState = GameState.MENU;

            // Create a new menu
            menu = new Menu(new string[] { "Start", "Exit" });
            gameOverMenu = new Menu(new string[] { "Try Again", "Return to main menu" });
            pauseMenu = new Menu(new string[] { "Resume", "Return to main menu" });

            // Create a new snake
            snake = new Snake();

            while (true)
            {
                switch (gameState)
                {
                    case GameState.MENU:
                        HandleMenu();
                        break;

                    case GameState.PLAYING:
                        HandlePlaying();
                        break;

                    case GameState.PAUSED:
                        // TODO: Add a way to pause the game
                        HandlePause();
                        break;

                    case GameState.GAMEOVER:
                        HandleGameOver();
                        break;
                }

                // Limit the game loop to 6 frames per second
                Thread.Sleep(1000 / 6);
            }
        }

        private static void Reset()
        {
            // Create a new snake
            snake = new Snake();
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

        private static void HandleGameOver()
        {
            Reset();

            // Open the menu
            gameOverMenu.OpenMenu();

            // Draw the menu
            gameOverMenu.Draw("Game Over!");

            // Handle input
            gameOverMenu.HandleInput();

            // Check if the menu is still open
            if (!gameOverMenu.Open)
            {
                // Check which option was selected
                switch (gameOverMenu.GetSelectedOption())
                {
                    case 0:
                        // Start the game
                        gameState = GameState.PLAYING;
                        break;

                    case 1:
                        // Return to the main menu
                        gameState = GameState.MENU;
                        break;
                }
            }
        }

        private static void HandlePause()
        {
            // Open the menu
            pauseMenu.OpenMenu();

            // Draw the menu
            pauseMenu.Draw("Game Paused...");

            // Handle input
            pauseMenu.HandleInput();

            // Check if the menu is still open
            if (!pauseMenu.Open)
            {
                // Check which option was selected
                switch (pauseMenu.GetSelectedOption())
                {
                    case 0:
                        // Start the game
                        gameState = GameState.PLAYING;
                        break;

                    case 1:
                        // Return to the main menu
                        Reset();
                        gameState = GameState.MENU;
                        break;
                }
            }
        }
    }
}
