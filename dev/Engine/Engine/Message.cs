using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Message
    {
        public static string msglog;    // messages log serveur
        public static string msgdata;   // messages données reçues
        public static int players;      // nombre de joueurs

        public const int useport = 14242;
        public const string connectstring = "galaganetgame";
    }
}
