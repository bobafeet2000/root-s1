using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;


namespace Engine
{
    static class Constant
    {
       
        public const bool ISDEBUG = true;
        public const string GAME_NAME = "Galaga 2019";
        public const string GAME_BOOT = "Boot";
        public const string CONTENT_DIR = "Content";
        public const int MAIN_WINDOW_WIDTH = 448;               // Résolution borne Galaga * 2
        public const int MAIN_WINDOW_HEIGHT = 576;              // Résolution borne Galaga * 2
        public const bool MAIN_WINDOWS_BORDERLESS = false;
        public const bool MAIN_WINDOW_FULLSCREEN = true; //false;

        public const int BACKGROUND_RANDOM_STAR = 5;         // Random max (une chance sur BACKGROUND_RANDOM_STAR de faire apparaitre une étoile)
        public const int BACKGROUND_BLINK_STAR = 600;         // Cycle de clignotement des étoiles en ms

        public const int STAR_1_COLOR_R = 255;
        public const int STAR_1_COLOR_G = 255;
        public const int STAR_1_COLOR_B = 255;
        public const float STAR_1_COLOR_A = 0.6f;

        public const int STAR_2_COLOR_R = 0;
        public const int STAR_2_COLOR_G = 0;
        public const int STAR_2_COLOR_B = 255;
        public const float STAR_2_COLOR_A = 0.6f;

        public const int STAR_3_COLOR_R = 0;
        public const int STAR_3_COLOR_G = 255;
        public const int STAR_3_COLOR_B = 0;
        public const float STAR_3_COLOR_A = 0.6f;

        public const int STAR_4_COLOR_R = 255;
        public const int STAR_4_COLOR_G = 255;
        public const int STAR_4_COLOR_B = 0;
        public const float STAR_4_COLOR_A = 0.6f;

        public const int STAR_5_COLOR_R = 255;
        public const int STAR_5_COLOR_G = 0;
        public const int STAR_5_COLOR_B = 0;
        public const float STAR_5_COLOR_A = 0.6f;

        public const int BKCOLOR_R = 0;
        public const int BKCOLOR_G = 0;
        public const int BKCOLOR_B = 0;


        public const string FONT_DEBUG = "namco_18";
        public const int FONT_DEBUG_COLOR_R = 255;
        public const int FONT_DEBUG_COLOR_G = 255;
        public const int FONT_DEBUG_COLOR_B = 255;
        public const float FONT_DEBUG_COLOR_A = 0.5f;

        public const string FONT_GAME = "namco_27";
        public const int FONT_GAME_COLOR_R = 200;
        public const int FONT_GAME_COLOR_G = 200;
        public const int FONT_GAME_COLOR_B = 200;
        public const float FONT_GAME_COLOR_A = 1f;

        public const string TEXTURE_PLAYER = "player";
        public const string TEXTURE_STAR = "star";

        public const string SOUND_START = "song_start";
        public const string SOUND_EXPLOSION = "song_explosion";


    }
}
