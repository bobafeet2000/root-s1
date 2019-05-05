using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Engine
{
    static class Art
    {
        // Textures
        public static Texture2D Texture_Player { get; private set; }
        public static Texture2D Texture_Enemy1 { get; private set; }
        public static Texture2D Texture_Enemy2 { get; private set; }
        public static Texture2D Texture_Enemy3 { get; private set; }
        public static Texture2D Texture_Enemy4 { get; private set; }

        // Textures nouveau skin
        public static Texture2D Texture_Enemy1_1 { get; private set; }

        public static Texture2D Texture_Star1 { get; private set; }
        public static Texture2D Texture_Star0 { get; private set; }
        public static Texture2D Texture_Star2 { get; private set; }
        public static Texture2D Texture_Tir { get; private set; }
        public static Texture2D Texture_Tir_Enemy { get; private set; }
        // Font
        public static SpriteFont Font_Debug { get; private set; }
        public static SpriteFont Font_Boot { get; private set; }
        public static SpriteFont Font_Game { get; private set; }
        public static SpriteFont Font_Game_small { get; private set; }
        // Sound
        public static SoundEffect Song_start { get; private set; }
        public static SoundEffect Song_tir { get; private set; }
        public static SoundEffect Song_tir_enemy { get; private set; }
        public static SoundEffect Song_explosion { get; private set; }
        public static SoundEffect Song_death { get; private set; }
        public static SoundEffect Song_boot_msg { get; private set; }


        public static void Load(ContentManager content)
        {
            if (Constant.ISDEBUG) { Font_Debug = content.Load<SpriteFont>(Constant.FONT_DEBUG); }

            // Sprite player
            Texture_Player = content.Load<Texture2D>(Constant.TEXTURE_PLAYER);
            // Sprite enemy
            Texture_Enemy1 = content.Load<Texture2D>(Constant.TEXTURE_ENEMY1);
            Texture_Enemy2 = content.Load<Texture2D>(Constant.TEXTURE_ENEMY2);
            Texture_Enemy3 = content.Load<Texture2D>(Constant.TEXTURE_ENEMY3);
            Texture_Enemy4 = content.Load<Texture2D>(Constant.TEXTURE_ENEMY4);
            Texture_Enemy1_1 = content.Load<Texture2D>(Constant.TEXTURE_ENEMY1_1); 
            // Sprite star
            Texture_Star0 = content.Load<Texture2D>(Constant.TEXTURE_STAR0);
            Texture_Star1 = content.Load<Texture2D>(Constant.TEXTURE_STAR1);
            Texture_Star2 = content.Load<Texture2D>(Constant.TEXTURE_STAR2);
            // Sprite tir player et enemy
            Texture_Tir = content.Load<Texture2D>(Constant.TEXTURE_TIR);
            Texture_Tir_Enemy = content.Load<Texture2D>(Constant.TEXTURE_TIR_ENEMY);

            // Font
            Font_Game = content.Load<SpriteFont>(Constant.FONT_GAME);
            Font_Game_small = content.Load<SpriteFont>(Constant.FONT_GAME_SMALL);
            Font_Boot = content.Load<SpriteFont>(Constant.FONT_BOOT);

            // Song effect
            Song_start = content.Load<SoundEffect>(Constant.SOUND_START);
            Song_explosion = content.Load<SoundEffect>(Constant.SOUND_EXPLOSION);
            Song_death = content.Load<SoundEffect>(Constant.SOUND_DEATH);
            Song_tir = content.Load<SoundEffect>(Constant.SOUND_TIR);
            Song_tir_enemy = content.Load<SoundEffect>(Constant.SOUND_TIR_ENEMY);
            Song_boot_msg = content.Load<SoundEffect>(Constant.SOUND_BOOT_MSG);

        }
    }


}
