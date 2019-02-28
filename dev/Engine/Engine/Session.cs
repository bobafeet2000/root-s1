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
        public int nbtir { get; protected set; }
        public Enemy enemy { get; protected set; }
        public List<Tir> tirs { get; protected set; }
        public Background background1 { get; protected set; }
        public Background background2 { get; protected set; }
        public SoundEffectInstance sound_start { get; protected set; }
        public SoundEffectInstance sound_explosion { get; protected set; }
        public SoundEffectInstance sound_tir { get; protected set; }

        public enum SessionState
        {
            //Tous les états possibles de la partie
            Intro, Game,
        }
        SessionState CurrentSessionState = SessionState.Game;



        public Session()
        {
            player = new Player();
            enemy = new Enemy();
            tirs = new List<Tir>();
            background1 = new Background(1,1);
            background2 = new Background(2,2);
            nbtir = Constant.PLAYER_NBTIR;

            sound_start = Art.Song_start.CreateInstance(); // on charge le son d'intro
            sound_start.Play();                            // on joue le son d'intro

            sound_explosion = Art.Song_explosion.CreateInstance(); // on charge le son sans le jouer
            sound_tir = Art.Song_tir.CreateInstance(); // on charge le son sans le jouer


        }

        public void End()
        {
            sound_start.Stop();
            sound_explosion.Stop();
            sound_tir.Stop();
        }

 

        public void Update(float elapsetime)
        {
            switch (CurrentSessionState)
            {
                case SessionState.Game :

                    if (Input.KeyPressed(Keys.LeftControl))
                    {
                        if (tirs.Count() < nbtir)
                        {
                            tirs.Add(new Tir(player.pos_X, player.pos_Y));
                            sound_tir.Play();
                        }
                    }

                    if (tirs.Count() > 0) for (int i = 0; i < tirs.Count(); i++)
                        {
                            tirs[i].Update(elapsetime);
                            if (tirs[i].pos_Y < 0) tirs.Remove(tirs[i]);
                        }
                    player.Update(elapsetime);
                    enemy.Update(elapsetime);
                    background1.Update(elapsetime);
                    background2.Update(elapsetime);

                    break;
                    
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (CurrentSessionState)
            {
                case SessionState.Game:
                    background1.Draw(spriteBatch);
                    background2.Draw(spriteBatch);
                    if (tirs.Count() > 0) for (int i = 0; i < tirs.Count(); i++) tirs[i].Draw(spriteBatch);
                    enemy.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    break;
            }
        }

    }


}
