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
    public class Session 
    {
        public Player player { get; protected set; }
        public Background background { get; protected set; }
        public Background2 back { get; protected set; }
        public SoundEffectInstance sound_start { get; protected set; }
        public SoundEffectInstance sound_explosion { get; protected set; }


        public Session()
        {
            player = new Player();
            background = new Background();
            back = new Background2();

            sound_start = Art.Song_start.CreateInstance(); // on charge le son d'intro
            sound_start.Play();                            // on joue le son d'intro

            sound_explosion = Art.Song_explosion.CreateInstance(); // on charge le son sans le jouer
 

        }

        public void End()
        {
            sound_start.Stop();
            sound_explosion.Stop();
        }

 

        public void Update(float elapsetime)
        {
            player.Update(elapsetime);
            background.Update(elapsetime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }

    }


}
