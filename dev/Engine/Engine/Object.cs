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
    public abstract class Object
    {
        public Sprite sprite { get; protected set; }
        public Color color { get; protected set; }
        public int speed { get; protected set; }        // à implementer
        public int pos_X { get; protected set; }
        public int pos_Y { get; protected set; }
        public float rotation { get; protected set; }
        public float scale { get; protected set; }
        

        public Object()
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

    public class Player : Object
    {
        public Player()
        {

            this.color = Color.White;
            this.sprite = new Sprite(Art.Texture_Player, this.color);

            // Position de départ, à enlever d'ici à terme ?
            pos_Y = Constant.MAIN_WINDOW_HEIGHT - this.sprite.Rect.Height * 2 + this.sprite.Rect.Height / 2;
            pos_X = Constant.MAIN_WINDOW_WIDTH / 2 - (this.sprite.Rect.Width / 2);
        }

        public override void Update(float elapsetime)
        {

            int move = (int)(elapsetime / Constant.PLAYER_SPEED);

            if (Input.IsKeyDown(Keys.Right))
            {
                if (pos_X < Constant.MAIN_WINDOW_WIDTH - sprite.Rect.Width / 2 - move) pos_X = pos_X + move;
                else pos_X = Constant.MAIN_WINDOW_WIDTH - sprite.Rect.Width / 2;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (pos_X > sprite.Rect.Width / 2 + move) pos_X = pos_X - move;
                else pos_X = sprite.Rect.Width / 2;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
           // this.sprite.SetRotation(this.rotation);  // par exmeple rotation += 0.5f;
            this.sprite.SetPosition(new Vector2(this.pos_X, pos_Y));
            this.sprite.Draw(spriteBatch);
        }
    }

    public class Enemy : Object
    {
        public int direction { get; private set; }
        public int cycle { get; protected set; }
        public int frame { get; protected set; }
        public Rectangle rect { get; private set; }


        public Enemy(Texture2D texture , int frame)
        {
            this.cycle = 0;
            this.frame = frame;
            this.color = Color.White;
            this.sprite = new Sprite(texture, this.color);
            
           
            // A ENLEVER
            pos_Y = 150;
            pos_X = 250;
            direction = 1;
        }



        public override void Update(float elapsetime)
        {

            if (direction==1)
            {
                if (pos_X >= Constant.MAIN_WINDOW_WIDTH / 8) pos_X = pos_X - (int)(elapsetime / 5);
                else direction = 0;
            }
            else
            {
                if (pos_X < (Constant.MAIN_WINDOW_WIDTH / 10) * 8) pos_X = pos_X + (int)(elapsetime / 5);
                else direction = 1;
            }
            //
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // this.sprite.SetRotation(this.rotation);  // par exmeple rotation += 0.5f;
            this.sprite.SetPosition(new Vector2(this.pos_X, pos_Y));
            this.sprite.Draw(spriteBatch);
        }
    }

    public class Star : Object
    {

        public int blink { get; protected set; }
        public bool visible { get; protected set; }
        public int state { get; protected set; }
        public int laps { get; protected set; }

        public Star(Color color, int x, int y, int state, int blink, int size, int speed)
        {
            this.color = color;
            if (size ==1) this.sprite = new Sprite(Art.Texture_Star1,this.color);
            if (size == 2) this.sprite = new Sprite(Art.Texture_Star2, this.color);
            this.pos_Y = y;
            this.pos_X = x;
            this.blink = blink;
            this.visible = true;
            this.state = state;
            this.laps = 0;
            this.speed = speed;
        }

        public override void Update(float elapsetime)
        {
            pos_Y += (int)(elapsetime/speed);
            visible = (state % blink != 0);

            laps += (int)elapsetime;
            if (laps >Constant.BACKGROUND_BLINK_STAR)
            {
                laps = 0;
                state ++;
                if (state >= 10) state = 0;
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                this.sprite.SetPosition(new Vector2(this.pos_X, pos_Y));
                this.sprite.Draw(spriteBatch);
            }
        }
    }

    public class Tir : Object
    {

        public Tir(int x, int y)
        {
            this.color = Color.White;
            this.sprite = new Sprite(Art.Texture_Tir, this.color);
            this.pos_Y = y;
            this.pos_X = x;          
        }

        public override void Update(float elapsetime)
        {
            pos_Y -= (int)(elapsetime / Constant.PLAYER_SPEEDTIR);   

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
                this.sprite.SetPosition(new Vector2(this.pos_X, pos_Y));
                this.sprite.Draw(spriteBatch);
            
        }
    }
}
