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
        public const string GAME_NAME = "Back to the roots";
        public const string GAME_INTRO = "Get ready";
        public const int GAME_INTRO_LAPS = 7000;

        public const string GAME_BOOT = "Boot";
        public const int GAME_BOOT_LAPS = 3200;

        public static readonly string[] GAME_BOOT_MSG = { "mov bh , 32", "mov bl , 40", "mov si , WORD Descriptor", "mov ah , 0x89", "cli", "int 15h", "jmp backtotheroots" };

        public static readonly string[,] HIGH_SCORES_DEFAULT = new string[,]
       {
            {"75200", "Nasaboy"},
            {"63400", "Boba"},
            {"42000", "Belvedere"},
            {"200", "Jewny Halliday"},
            {"0", STRING_PLAYER}
       };

        public const string GAME_INSTRUCTION = "Instruction";
        public const string GAME_CREDIT = "CREDIT";
        public const string GAME_SCORE = "HIGH SCORE";
        public const string GAME_MENUMULTI = "Multiplayer";
        public const string GAME_MENUMULTI2 = "Looking for players";
        public const string GAME_OVER = "Game Over";
        public const string GAME_NEXT = "Next Level";

        public const string STRING_LIVES = "Energy";
        public const string STRING_LEVEL = "Level";
        public const string STRING_COIN = "Insert a Coin";
        public const string STRING_START_GAME = "Press ENTER to start the game";
        public const string STRING_INSTRUCT_DISPLAY = "Press H key to display instructions";
        public const string STRING_MOVE = "Press arrow keys to move your vessel";
        public const string STRING_SHOOT = "Press CTRL key to shoot the enemies";
        public const string STRING_QUIT = "Press ECHAP key to quit the game";
        public const string STRING_QUIT_MENU = "Press ECHAP key to return to the menu";
        public const string STRING_TRY = "Press the R to try again";
        public const string STRING_PLAYER_HOST = "Player 1 HOST";
        public const string STRING_PLAYER = "Player 1";
        public const string STRING_PLAYER2 = "Player 2";
        public const string STRING_SELECT = "Press 1 or 2 to select your player";
        public const string STRING_CONFIRM = "Game will start automatically";
        public const string STRING_DETECTED = " detected !";
        public const string STRING_START = "Press ENTER to start the game";

        public const string CONTENT_DIR = "Content";
        public const int MAIN_WINDOW_WIDTH = 448;               // 448 Résolution borne Galaga * 2
        public const int MAIN_WINDOW_HEIGHT = 576;              // 576 Résolution borne Galaga * 2
        public const bool MAIN_WINDOWS_BORDERLESS = false;
        public const bool MAIN_WINDOW_FULLSCREEN = false;

        public const int BACKGROUND_RANDOM_STAR = 4;         // Random max (une chance sur BACKGROUND_RANDOM_STAR de faire apparaitre une étoile)
        public const int BACKGROUND_BLINK_STAR = 300;         // Cycle de clignotement des étoiles en ms

        public const int STAR_1_COLOR_R = 255;
        public const int STAR_1_COLOR_G = 255;
        public const int STAR_1_COLOR_B = 255;
        public const float STAR_1_COLOR_A = 0.9f;

        public const int STAR_2_COLOR_R = 0;
        public const int STAR_2_COLOR_G = 0;
        public const int STAR_2_COLOR_B = 255;
        public const float STAR_2_COLOR_A = 0.9f;

        public const int STAR_3_COLOR_R = 0;
        public const int STAR_3_COLOR_G = 255;
        public const int STAR_3_COLOR_B = 0;
        public const float STAR_3_COLOR_A = 0.9f;

        public const int STAR_4_COLOR_R = 255;
        public const int STAR_4_COLOR_G = 255;
        public const int STAR_4_COLOR_B = 0;
        public const float STAR_4_COLOR_A = 0.9f;

        public const int STAR_5_COLOR_R = 255;
        public const int STAR_5_COLOR_G = 0;
        public const int STAR_5_COLOR_B = 0;
        public const float STAR_5_COLOR_A = 0.9f;

        public const int BKCOLOR_R = 0;
        public const int BKCOLOR_G = 0;
        public const int BKCOLOR_B = 0;

        public const string FONT_BOOT = "namco_18";
        public const int FONT_BOOT_COLOR_R = 20;
        public const int FONT_BOOT_COLOR_G = 148;
        public const int FONT_BOOT_COLOR_B = 20;
        public const float FONT_BOOT_COLOR_A = 0.5f;

        public const string FONT_DEBUG = "namco_18";
        public const int FONT_DEBUG_COLOR_R = 255;
        public const int FONT_DEBUG_COLOR_G = 255;
        public const int FONT_DEBUG_COLOR_B = 255;
        public const float FONT_DEBUG_COLOR_A = 0.5f;

        public const string FONT_GAME_SMALL = "namco_12";
        public const int FONT_GAME_SMALL_COLOR_R = 255;
        public const int FONT_GAME_SMALL_COLOR_G = 0;
        public const int FONT_GAME_SMALL_COLOR_B = 0;
        public const float FONT_GAME_SMALL_COLOR_A = 0.8f;

        public const string FONT_GAME = "namco_27";
        public const int FONT_GAME_COLOR_R = 200;
        public const int FONT_GAME_COLOR_G = 200;
        public const int FONT_GAME_COLOR_B = 200;
        public const float FONT_GAME_COLOR_A = 1f;

        public const string TEXTURE_PLAYER = "player";
        public const string TEXTURE_PLAYER2 = "player2";
        public const int PLAYER_SPEED = 5;                                                      // plus indice eleve moins ca va vite
        public const int PLAYER_NBTIR = 2;
        public const int PLAYER_SPEEDTIR = 1;
        public const int PLAYER_LIVES = 5;

        public const string TEXTURE_EXPLOSION = "Explosion";                        
        public const int FRAME_EXPLOSION_ENEMY = 4;

        public const int SPEEDTIR_ENEMY = 3;
        public const string TEXTURE_ENEMY1 = "enemy1";
        public const int CYCLE_ENEMY1 = 400;                                                      // Cycle en ms
        public const int FRAME_ENEMY1 = 2;

        public const string TEXTURE_ENEMY2 = "enemy2";
        public const int CYCLE_ENEMY2 = 400;                                                      // Cycle en ms
        public const int FRAME_ENEMY2 = 2;

        public const string TEXTURE_ENEMY3 = "enemy3";
        public const int CYCLE_ENEMY3 = 400;                                                      // Cycle en ms
        public const int FRAME_ENEMY3 = 2;

        public const string TEXTURE_ENEMY4 = "enemy4";
        public const int CYCLE_ENEMY4 = 100;                                                      // Cycle en ms
        public const int FRAME_ENEMY4 = 2;

        public const string TEXTURE_ENEMY1_1 = "enemy1_1";  // enemy nouveau skin 
        public const int CYCLE_ENEMY1_1 = 50;                                                      // Cycle en ms
        public const int FRAME_ENEMY1_1 = 4;

        public const string TEXTURE_STAR0 = "star0";
        public const string TEXTURE_STAR1 = "star1";
        public const string TEXTURE_STAR2 = "star2";
        public const string TEXTURE_TIR = "tir";
        public const string TEXTURE_TIR_ENEMY = "tirenemy";

        public const string SOUND_START = "song_start";
        public const string SOUND_EXPLOSION = "song_explosion";
        public const string SOUND_DEATH = "song_death";
        public const string SOUND_TIR = "song_tir";
        public const string SOUND_TIR_ENEMY = "song_tirenemy";
        public const string SOUND_BOOT_MSG = "song_beep";
        public const string SOUND_GAME_OVER = "song_gameover";


    }
}
