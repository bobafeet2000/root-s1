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
        public Background background0 { get; protected set; }
        public Background background1 { get; protected set; }
        public Background background2 { get; protected set; }
        public SoundEffectInstance sound_start { get; protected set; }
        public ScreenText screen_intro { get; protected set; }
        public Level mylevel { get; protected set; }
        public int num_level = 0;
        private int intro = 0;
        private bool intro_sound = false;
        public int blink_text = 0;

        public enum SessionState
        {
            //Tous les états possibles de la partie
            Intro, Game, Break
        }
        SessionState CurrentSessionState = SessionState.Intro;

        public Session()
        {
            background0 = new Background(0,16);
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
             background0.Update(elapsetime);
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
                        if (Input.KeyPressed(Keys.P))
                        {
                            CurrentSessionState = SessionState.Break;
                        }
                        if (Input.KeyPressed(Keys.R))
                        {
                            //TODO: Quand on appuie sur la touche R, lancer une nouvelle partie
                        }
                        mylevel.Update(elapsetime);
                        
                        break;
                    }

                case SessionState.Break:
                    {
                        if (Input.KeyPressed(Keys.P))
                        {
                            CurrentSessionState = SessionState.Game;
                        }
                        break;
                    }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background0.Draw(spriteBatch);
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

                case SessionState.Break:
                    mylevel.Draw(spriteBatch);
                    string name = "PAUSE";
                    int pos_X = (int)(Constant.MAIN_WINDOW_WIDTH / 2 - Art.Font_Game.MeasureString(name).Length() / 2);
                    int pos_Y = Constant.MAIN_WINDOW_HEIGHT / 2 - 100;
                    Color font_color_game = new Color(Constant.FONT_GAME_COLOR_R, Constant.FONT_GAME_COLOR_G, Constant.FONT_GAME_COLOR_B);
                    spriteBatch.DrawString(Art.Font_Game, name, new Vector2(pos_X, pos_Y), font_color_game * Constant.FONT_GAME_COLOR_A);
                    break;
            }
        }
    }
}
