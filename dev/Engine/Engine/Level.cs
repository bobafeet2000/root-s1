using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Engine
{
    class Level
    {
        public Player player { get; protected set; }
        public int nbtir { get; protected set; }
        public Enemy enemy { get; protected set; }
        public List<Tir> tirs { get; protected set; }
        public SoundEffectInstance sound_explosion { get; protected set; }
        public SoundEffectInstance sound_tir { get; protected set; }

        public Level()
        {
            player = new Player();
            enemy = new Enemy();
            tirs = new List<Tir>();
            
            nbtir = Constant.PLAYER_NBTIR;

            sound_explosion = Art.Song_explosion.CreateInstance(); // on charge le son sans le jouer
            sound_tir = Art.Song_tir.CreateInstance(); // on charge le son sans le jouer

        }
    }
}
