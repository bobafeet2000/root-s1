using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    static class Program
    {

        /// Point d'entrée du programme
        static void Main(string[] args)
        {
            using (Game game = new Game())
            {
                game.Run();
            }
        }
    }
}
