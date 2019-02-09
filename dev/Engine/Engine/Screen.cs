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
    public abstract class Screen
    {
        public String name { get; protected set; }
        public Color font_color_name;
        public int pos_X { get; protected set; }
        public int pos_Y { get; protected set; }
        public Background background { get; protected set; }

        public Screen()
        {
            // constructeur
        }

        public virtual void Update(float elapsetime)
        {
            // update
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // draw
        }
    }

    public class ScreenBoot : Screen
    {
        public ScreenBoot(String name)
        {
            this.name = name;
            pos_X = (int)(Constant.MAIN_WINDOW_WIDTH / 2 - Art.Font_Game.MeasureString(name).Length() / 2);
            pos_Y = Constant.MAIN_WINDOW_HEIGHT / 2;
            font_color_name = new Color(Constant.FONT_GAME_COLOR_R, Constant.FONT_GAME_COLOR_G, Constant.FONT_GAME_COLOR_B); // couleur de la font 
        }

        public override void Update(float elapsetime)
        {
            // à implementer

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Art.Font_Game, this.name, new Vector2(this.pos_X, this.pos_Y), font_color_name * Constant.FONT_GAME_COLOR_A); // Affichage du titre de l'écran
        }
    }

    public class ScreenHome : Screen
    {
        public ScreenHome(String name)
        {
            this.name = name;
            pos_X = (int)(Constant.MAIN_WINDOW_WIDTH / 2 - Art.Font_Game.MeasureString(name).Length() / 2);
            pos_Y = Constant.MAIN_WINDOW_HEIGHT / 2;
            font_color_name = new Color(Constant.FONT_GAME_COLOR_R, Constant.FONT_GAME_COLOR_G, Constant.FONT_GAME_COLOR_B); // couleur de la font 

            background = new Background();

        }

        public override void Update(float elapsetime)
        {
            background.Update(elapsetime);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            spriteBatch.DrawString(Art.Font_Game, this.name, new Vector2(this.pos_X, this.pos_Y), font_color_name * Constant.FONT_GAME_COLOR_A); // Affichage du titre de l'écran

        }
    }

}
