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
    public class Background
    {
        public List<Star> listestar { get; protected set; }
        private Random rnd;
        private int pos_X;
        private int blink;
        private int state;
        private int col;
        private Color color = Color.White;

        public Background()
        {
            listestar = new List<Star>();
            rnd = new Random();
            int pos_Y = 0;

            for (int i= 0;i<=(Constant.MAIN_WINDOW_HEIGHT);i++)
            {
                if (rnd.Next(0, Constant.BACKGROUND_RANDOM_STAR) == 0) // une chance sur BACKGROUND_RANDOM_STAR de mettre une étoile 
                {
                    pos_X = rnd.Next(0, Constant.MAIN_WINDOW_WIDTH - 1);
                    blink = rnd.Next(1, 9);
                    state = rnd.Next(0, 20);
                    col = rnd.Next(0, 5);
                    if (col == 0) color = new Color(Constant.STAR_1_COLOR_R, Constant.STAR_1_COLOR_G, Constant.STAR_1_COLOR_B)* Constant.STAR_1_COLOR_A;
                    if (col == 1) color = new Color(Constant.STAR_2_COLOR_R, Constant.STAR_2_COLOR_G, Constant.STAR_2_COLOR_B) * Constant.STAR_2_COLOR_A;
                    if (col == 2) color = new Color(Constant.STAR_3_COLOR_R, Constant.STAR_3_COLOR_G, Constant.STAR_3_COLOR_B) * Constant.STAR_3_COLOR_A;
                    if (col == 3) color = new Color(Constant.STAR_4_COLOR_R, Constant.STAR_4_COLOR_G, Constant.STAR_4_COLOR_B) * Constant.STAR_4_COLOR_A;
                    if (col == 4) color = new Color(Constant.STAR_5_COLOR_R, Constant.STAR_5_COLOR_G, Constant.STAR_5_COLOR_B) * Constant.STAR_5_COLOR_A;

                    listestar.Add(new Star(color, pos_X, pos_Y, state, blink));
                }
                pos_Y++;
            }
        }

        public virtual void Update(float elapsetime)
        {
            // update
            for (int i=listestar.Count-1; i>=0; i--)
            {
                listestar[i].Update(elapsetime);
                if (listestar[i].pos_Y > Constant.MAIN_WINDOW_HEIGHT)
                {
                    listestar.Remove(listestar[i]);
                } 
            }

            if (rnd.Next(0, Constant.BACKGROUND_RANDOM_STAR) == 0) // une chance sur 10 de mettre une étoile 
            {
                int pos_X = rnd.Next(0, Constant.MAIN_WINDOW_WIDTH - 1);
                int blink = rnd.Next(1, 9);
                int state = rnd.Next(0, 20);
                int col = rnd.Next(0, 5);
                if (col == 0) color = new Color(Constant.STAR_1_COLOR_R, Constant.STAR_1_COLOR_G, Constant.STAR_1_COLOR_B) * Constant.STAR_1_COLOR_A;
                if (col == 1) color = new Color(Constant.STAR_2_COLOR_R, Constant.STAR_2_COLOR_G, Constant.STAR_2_COLOR_B) * Constant.STAR_2_COLOR_A;
                if (col == 2) color = new Color(Constant.STAR_3_COLOR_R, Constant.STAR_3_COLOR_G, Constant.STAR_3_COLOR_B) * Constant.STAR_3_COLOR_A;
                if (col == 3) color = new Color(Constant.STAR_4_COLOR_R, Constant.STAR_4_COLOR_G, Constant.STAR_4_COLOR_B) * Constant.STAR_4_COLOR_A;
                if (col == 4) color = new Color(Constant.STAR_5_COLOR_R, Constant.STAR_5_COLOR_G, Constant.STAR_5_COLOR_B) * Constant.STAR_5_COLOR_A;

                listestar.Add(new Star(color, pos_X, 0, state, blink));
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Star element in listestar)
            {
                element.Draw(spriteBatch);
            }
        }
    }
}
