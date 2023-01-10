using System;
using System.Threading;

namespace Snake
{
    class GameLoop
    {
        static void Start()
        {
            gameState gameState = gameState.MENU;

            while (true)
            {
                switch (gameState)
                {
                    // TODO: Add code for each state
                    case gameState.MENU:

                        break;

                    case gameState.PLAYING:

                        break;

                    case gameState.PAUSED:

                        break;

                    case gameState.GAMEOVER:

                        break;
                }

                // Limit the game loop to 60 frames per second
                Thread.Sleep(1000 / 60);
            }
        }
    }
}
