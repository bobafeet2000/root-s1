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
        public Color font_color_game;
        public Color font_color_boot;
        public int pos_X { get; protected set; }
        public int pos_Y { get; protected set; }
        public Background background1 { get; protected set; }
        public Background background2 { get; protected set; }
        public int timer { get; protected set; }

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
        public SoundEffectInstance sound_boot_msg { get; protected set; }

        public ScreenBoot(String name)
        {
            this.name = name;
            pos_X = (int)(Constant.MAIN_WINDOW_WIDTH / 2 - Art.Font_Game.MeasureString(name).Length() / 2);
            pos_Y = Constant.MAIN_WINDOW_HEIGHT / 2;
            font_color_game = new Color(Constant.FONT_GAME_COLOR_R, Constant.FONT_GAME_COLOR_G, Constant.FONT_GAME_COLOR_B); // couleur de la font game
            font_color_boot = new Color(Constant.FONT_BOOT_COLOR_R, Constant.FONT_BOOT_COLOR_G, Constant.FONT_BOOT_COLOR_B); // couleur de la font boot msg
            sound_boot_msg = Art.Song_boot_msg.CreateInstance();
        }

        public override void Update(float elapsetime)
        {
            timer += (int)elapsetime;

            if ((timer >1000 && timer <1060) || (timer > 1200 && timer < 1260) || (timer > 1400 && timer < 1460) || (timer > 1600 && timer < 1660) || (timer > 1800 && timer < 1860) || (timer > 2000 && timer < 2060) || (timer > 2200 && timer < 2260)) sound_boot_msg.Play();

        }
        public override void Draw(SpriteBatch spriteBatch)
        {          
            if (timer<1000) spriteBatch.DrawString(Art.Font_Game, this.name, new Vector2(this.pos_X, this.pos_Y), font_color_game * Constant.FONT_GAME_COLOR_A); // Affichage du titre de l'écran
            if (timer >1000) spriteBatch.DrawString(Art.Font_Boot, Constant.GAME_BOOT_MSG[0], new Vector2(10, 100), font_color_boot * Constant.FONT_GAME_COLOR_A);
            if (timer > 1200) spriteBatch.DrawString(Art.Font_Boot, Constant.GAME_BOOT_MSG[1], new Vector2(10, 120), font_color_boot * Constant.FONT_GAME_COLOR_A);
            if (timer > 1400) spriteBatch.DrawString(Art.Font_Boot, Constant.GAME_BOOT_MSG[2], new Vector2(10, 140), font_color_boot * Constant.FONT_GAME_COLOR_A);
            if (timer > 1600) spriteBatch.DrawString(Art.Font_Boot, Constant.GAME_BOOT_MSG[3], new Vector2(10, 160), font_color_boot * Constant.FONT_GAME_COLOR_A);
            if (timer > 1800) spriteBatch.DrawString(Art.Font_Boot, Constant.GAME_BOOT_MSG[4], new Vector2(10, 180), font_color_boot * Constant.FONT_GAME_COLOR_A);
            if (timer > 2000) spriteBatch.DrawString(Art.Font_Boot, Constant.GAME_BOOT_MSG[5], new Vector2(10, 200), font_color_boot * Constant.FONT_GAME_COLOR_A);
            if (timer > 2200) spriteBatch.DrawString(Art.Font_Boot, Constant.GAME_BOOT_MSG[6], new Vector2(10, 220), font_color_boot * Constant.FONT_GAME_COLOR_A);

        }
    }

    public class ScreenHome : Screen
    {
        public ScreenHome(String name)
        {
            this.name = name;
            pos_X = (int)(Constant.MAIN_WINDOW_WIDTH / 2 - Art.Font_Game.MeasureString(name).Length() / 2);
            pos_Y = Constant.MAIN_WINDOW_HEIGHT / 2;
            font_color_game = new Color(Constant.FONT_GAME_COLOR_R, Constant.FONT_GAME_COLOR_G, Constant.FONT_GAME_COLOR_B); // couleur de la font 
  
            background1 = new Background(1, 8);
            background2 = new Background(2, 4);

        }

        public override void Update(float elapsetime)
        {
            background1.Update(elapsetime);
            background2.Update(elapsetime);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            background1.Draw(spriteBatch);
            background2.Draw(spriteBatch);
            spriteBatch.DrawString(Art.Font_Game, this.name, new Vector2(this.pos_X, this.pos_Y), font_color_game * Constant.FONT_GAME_COLOR_A); // Affichage du titre de l'écran

        }
    }

    public class ScreenInstruction : Screen
    {
        public ScreenInstruction(String name)
        {
            this.name = name;
            pos_X = (int)(Constant.MAIN_WINDOW_WIDTH / 2 - Art.Font_Game.MeasureString(name).Length() / 2);
            pos_Y = Constant.MAIN_WINDOW_HEIGHT / 2;
            font_color_game = new Color(Constant.FONT_GAME_COLOR_R, Constant.FONT_GAME_COLOR_G, Constant.FONT_GAME_COLOR_B); // couleur de la font 

            background1 = new Background(1, 8);
            background2 = new Background(2, 4);

        }

        public override void Update(float elapsetime)
        {
            background1.Update(elapsetime);
            background2.Update(elapsetime);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            background1.Draw(spriteBatch);
            background2.Draw(spriteBatch);
            spriteBatch.DrawString(Art.Font_Game, this.name, new Vector2(this.pos_X, this.pos_Y), font_color_game * Constant.FONT_GAME_COLOR_A); // Affichage du titre de l'écran

        }
    }

        public class ScreenText : Screen
        {
            public ScreenText(String name)
            {
                this.name = name;
                pos_X = (int)(Constant.MAIN_WINDOW_WIDTH / 2 - Art.Font_Game.MeasureString(name).Length() / 2);
                pos_Y = Constant.MAIN_WINDOW_HEIGHT / 2;
                font_color_game = new Color(Constant.FONT_GAME_COLOR_R, Constant.FONT_GAME_COLOR_G, Constant.FONT_GAME_COLOR_B); // couleur de la font 
            }

            public override void Update(float elapsetime)
            {
               
            }
            public override void Draw(SpriteBatch spriteBatch)
            {
                
                spriteBatch.DrawString(Art.Font_Game, this.name, new Vector2(this.pos_X, this.pos_Y), font_color_game * Constant.FONT_GAME_COLOR_A); // Affichage du titre de l'écran

            }
        }

    }

