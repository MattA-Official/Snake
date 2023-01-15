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
        private static int Score;
        private static int HighScore;

        public static void Start()
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

            // Set the score to 0
            Score = 0;
            HighScore = 0;

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

        public static void Pause()
        {
            // Change the game state to paused
            gameState = GameState.PAUSED;
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
            // Save the score
            Score = snake.SnakeSegments.Count - 1;

            // Check if the score is higher than the high score
            if (Score > HighScore)
            {
                // Set the high score to the score
                HighScore = Score;
            }

            // Open the menu
            gameOverMenu.OpenMenu();

            // Draw the menu
            gameOverMenu.Draw($"Game Over! Score: {Score}, High Score: {HighScore}");

            // Handle input
            gameOverMenu.HandleInput();

            // Check if the menu is still open
            if (!gameOverMenu.Open)
            {
                // Reset the snake
                Reset();

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
