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
        public static Texture2D Texture_Star1 { get; private set; }
        public static Texture2D Texture_Star2 { get; private set; }
        public static Texture2D Texture_Tir { get; private set; }
        // Font
        public static SpriteFont Font_Debug { get; private set; }
        public static SpriteFont Font_Game { get; private set; }
        // Sound
        public static SoundEffect Song_start { get; private set; }
        public static SoundEffect Song_tir { get; private set; }
        public static SoundEffect Song_explosion { get; private set; }


        public static void Load(ContentManager content)
        {
            if (Constant.ISDEBUG) { Font_Debug = content.Load<SpriteFont>(Constant.FONT_DEBUG); }

            Texture_Player = content.Load<Texture2D>(Constant.TEXTURE_PLAYER);
            Texture_Enemy1 = content.Load<Texture2D>(Constant.TEXTURE_ENEMY1);
            Texture_Star1 = content.Load<Texture2D>(Constant.TEXTURE_STAR1);
            Texture_Star2 = content.Load<Texture2D>(Constant.TEXTURE_STAR2);
            Texture_Tir = content.Load<Texture2D>(Constant.TEXTURE_TIR);
            Font_Game = content.Load<SpriteFont>(Constant.FONT_GAME);
            Song_start = content.Load<SoundEffect>(Constant.SOUND_START);
            Song_explosion = content.Load<SoundEffect>(Constant.SOUND_EXPLOSION);
            Song_tir = content.Load<SoundEffect>(Constant.SOUND_TIR);


        }
    }


}
