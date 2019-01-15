using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    static class Program
    {
        /// Constantes 
        public const int MAIN_WINDOW_WIDTH = 448;
        public const int MAIN_WINDOW_HEIGHT = 576;
        public const bool MAIN_WINDOW_FULLSCREEN = false;

        /// The main entry point for the application.
        static void Main(string[] args)
        {
            using (Game game = new Game(MAIN_WINDOW_WIDTH,MAIN_WINDOW_HEIGHT,MAIN_WINDOW_FULLSCREEN))
            {
                game.Run();
            }
        }
    }
}
