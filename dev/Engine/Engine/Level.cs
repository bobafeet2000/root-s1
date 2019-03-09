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
    public class Level
    {
        public Player player { get; protected set; }
        public int nbtir { get; protected set; }
        public Enemy enemy { get; protected set; }
        public List<Tir> tirs { get; protected set; }
        public SoundEffectInstance sound_explosion { get; protected set; }
        public SoundEffectInstance sound_tir1 { get; protected set; }
        public SoundEffectInstance sound_tir2 { get; protected set; }
        public int level_num;
        



        public enum LevelState
        {
            //Tous les états possibles de la partie
            Game,
        }
        LevelState CurrentLevelState = LevelState.Game;

        public Level(int x)
        {
            level_num = x;
            player = new Player();
            enemy = new Enemy();
            tirs = new List<Tir>();
            nbtir = Constant.PLAYER_NBTIR;

            sound_explosion = Art.Song_explosion.CreateInstance(); // on charge le son sans le jouer
            sound_tir1 = Art.Song_tir.CreateInstance(); // on charge le son sans le jouer
            sound_tir2 = Art.Song_tir.CreateInstance();
        }

        public void End()
        {
            sound_explosion.Stop();
            sound_tir1.Stop();
            sound_tir2.Stop();
        }

        public void Update(float elapsetime)
        {
            switch (CurrentLevelState)
            {
                case LevelState.Game:

                    if (Input.KeyPressed(Keys.LeftControl))
                    {
                        if (tirs.Count() < nbtir)
                        {
                            tirs.Add(new Tir(player.pos_X, player.pos_Y));
                            if (tirs.Count() == 1)
                            {
                                sound_tir1.Stop();
                                sound_tir1.Play();
                            }
                            if (tirs.Count() == 2)
                            {
                                sound_tir2.Stop();
                                sound_tir2.Play();
                            }

                        }
                    }

                    if (tirs.Count() > 0) for (int i = 0; i < tirs.Count(); i++)
                        {
                            tirs[i].Update(elapsetime);
                            if (tirs[i].pos_Y < 0)
                            {
                                tirs.Remove(tirs[i]);
                            }
                        }

                    player.Update(elapsetime);
                    enemy.Update(elapsetime);

                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (CurrentLevelState)
            {
                case LevelState.Game:
                    if (tirs.Count() > 0) for (int i = 0; i < tirs.Count(); i++) tirs[i].Draw(spriteBatch);
                    enemy.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    break;
            }
        }
    }
}
