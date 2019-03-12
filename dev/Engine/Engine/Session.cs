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
        public Background background1 { get; protected set; }
        public Background background2 { get; protected set; }
        public SoundEffectInstance sound_start { get; protected set; }
        public ScreenText screen_intro { get; protected set; }
        public Level mylevel { get; protected set; }
        public int num_level = 1;
        private int intro = 0;
        private bool intro_sound = false;
        public int blink_text = 0;

        public enum SessionState
        {
            //Tous les états possibles de la partie
            Intro, Game,
        }
        SessionState CurrentSessionState = SessionState.Intro;

        public Session()
        {
            background1 = new Background(1,8);
            background2 = new Background(2,4);
            screen_intro = new ScreenText(Constant.GAME_INTRO);
           
            sound_start = Art.Song_start.CreateInstance(); // on charge le son d'intro         
        }

        public void End()
        {
            sound_start.Stop();
        }

        public void Update(float elapsetime)
        {
             background1.Update(elapsetime);
             background2.Update(elapsetime);  
             
             switch (CurrentSessionState)
             {
                case SessionState.Intro:

                    if (!intro_sound)
                    {
                        sound_start.Play();
                        intro_sound = true;
                    }

                    screen_intro.Update(elapsetime);
                    blink_text += (int)elapsetime;
                    intro += (int)elapsetime;

                    if (intro > Constant.GAME_INTRO_LAPS)
                    {
                        CurrentSessionState = SessionState.Game;
                        screen_intro = null;
                        mylevel = new Level(num_level);

                    } 
                    break;

                case SessionState.Game:
                    {
                        mylevel.Update(elapsetime); 
                        break;
                    }
             }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background1.Draw(spriteBatch);
            background2.Draw(spriteBatch);

            switch (CurrentSessionState)
            {
                case SessionState.Intro:
                    if ((blink_text < 600)) screen_intro.Draw(spriteBatch);
                    else if (blink_text > 1200) blink_text = 0;


                    break;
                case SessionState.Game:
                    mylevel.Draw(spriteBatch);
                    break;  
            }
        }
    }
}
