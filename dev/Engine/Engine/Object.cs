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
        public bool dead { get; protected set; }

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

        public virtual void Setpos(int x,int y)
        {
            this.pos_X = x;
            this.pos_Y = y;
        }

        public virtual void Setrotation(float r)
        {
            this.rotation = r;
        }

        public virtual void Isdead()
        {
            this.dead = true;
        }
    }

    public class Player : Object
    {
        public Player()
        {

            this.color = Color.White;
            this.sprite = new Sprite(Art.Texture_Player, this.color);

            // Position de départ
            pos_Y = Constant.MAIN_WINDOW_HEIGHT - this.sprite.Rect.Height * 2;
            pos_X = Constant.MAIN_WINDOW_WIDTH / 2 - (this.sprite.Rect.Width / 2) ;
        }

        public Rectangle rectangle
        {
            get { return new Rectangle(pos_X+4, pos_Y+4, sprite.Texture.Width-8, sprite.Texture.Height-8); }
        }

        public override void Update(float elapsetime)
        {

            int move = (int)(elapsetime / Constant.PLAYER_SPEED);

            if (Input.IsKeyDown(Keys.Right) || (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickRight)))
            {

                if (pos_X < Constant.MAIN_WINDOW_WIDTH - sprite.Rect.Width - move) pos_X = pos_X + move;
                else pos_X = Constant.MAIN_WINDOW_WIDTH - sprite.Rect.Width;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) || (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickLeft)))
            {

                if (pos_X > move) pos_X = pos_X - move;
                else pos_X = 0;
            }

            this.sprite.SetPosition(new Vector2(this.pos_X, pos_Y));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }
    }

    public class Player2 : Object
    {
        public Player2()
        {

            this.color = Color.White;
            this.sprite = new Sprite(Art.Texture_Player2, this.color);

            // Position de départ
            pos_Y = Constant.MAIN_WINDOW_HEIGHT - this.sprite.Rect.Height * 2;
            pos_X = Constant.MAIN_WINDOW_WIDTH / 2 - (this.sprite.Rect.Width / 2);
        }

        public Rectangle rectangle
        {
            get { return new Rectangle(pos_X + 4, pos_Y + 4, sprite.Texture.Width - 8, sprite.Texture.Height - 8); }
        }

        public override void Update(float elapsetime)
        {
            this.sprite.SetPosition(new Vector2(this.pos_X, pos_Y));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }
    }
    public class Enemy : Object
    {
        public int direction { get; private set; } // a faire évoluer en Vector2
        public int cmp { get; private set; }
        public int cycle { get; private set; }
        public int frame { get; private set; }
        public int frame_courante { get; private set; }

        public Enemy(Texture2D texture, int frame, int cycle)
        {
            this.cmp = 0;
            this.color = Color.White;
            this.frame = frame;      
            this.frame_courante = 1;
            this.cycle = cycle;
            this.sprite = new Sprite(texture, this.color);
            this.sprite.SetRect(new Rectangle(0, 0, (sprite.Texture.Width / this.frame), sprite.Texture.Height)); // on fixe le premier rectangle à afficher par la sprite
            this.sprite.SetOrigin(new Vector2((sprite.Texture.Width / frame) / 2, (sprite.Texture.Height / 2))); // on fixe le centre pour la rotation

            this.direction = 1; // à enlever à terme
        }

        public Rectangle rectangle
        {
            // Version en prenant tout le rectangle sprite (même si l'énemie ne rempli pas tout la surface
            //get { return new Rectangle(pos_X - (sprite.Texture.Width / this.frame) / 2, pos_Y - (sprite.Texture.Height) / 2, (sprite.Texture.Width / this.frame), sprite.Texture.Height); }

            // Version en réduisant le rectangle de colision de 6 de tous les cotés (au lieu de faire 30 sur 30 il fait 18 sur 18)
            get { return new Rectangle((pos_X - (sprite.Texture.Width / this.frame) / 2) + 6, pos_Y - (sprite.Texture.Height) / 2, (sprite.Texture.Width / this.frame) - 12, sprite.Texture.Height - 6); }
        }

        public override void Update(float elapsetime)
        {
            cmp += (int)elapsetime;
            if (cmp > (this.cycle))
            {
                cmp = 0;
                frame_courante++;
                if (frame_courante > frame) frame_courante = 1;
            }

            this.sprite.SetRect(new Rectangle((frame_courante - 1) * (sprite.Texture.Width / frame), 0, (sprite.Texture.Width / frame) , sprite.Texture.Height));  


            // mouvement de test, à enlever à terme (les évolutions de positions sont à implémenter au niveau level
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
            // fin test

            this.sprite.SetPosition(new Vector2(this.pos_X, pos_Y));

            this.sprite.SetRotation(this.rotation);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {

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
            if (size == 0) this.sprite = new Sprite(Art.Texture_Star0, this.color);
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
        //private string direction_tir;

        public Tir(int x, int y)
        {
            this.color = Color.White;
            this.sprite = new Sprite(Art.Texture_Tir, this.color);
            this.pos_Y = y;
            this.pos_X = x;
        }

        public Rectangle rectangle
        {
            get { return new Rectangle(pos_X, pos_Y, 6, 16); }
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

    public class Tirenemy : Object
    {
        private string direction_tir;

        public Tirenemy(int x, int y, string direction)
        {
            this.color = Color.White;
            this.sprite = new Sprite(Art.Texture_Tir_Enemy, this.color);
            this.pos_Y = y;
            this.pos_X = x;
            this.direction_tir = direction;
        }

        public Rectangle rectangle
        {
            get { return new Rectangle(pos_X, pos_Y, 6, 16); }
        }

        public override void Update(float elapsetime)
        {

            pos_Y += (int)(elapsetime / Constant.SPEEDTIR_ENEMY);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.SetPosition(new Vector2(this.pos_X, pos_Y));
            this.sprite.Draw(spriteBatch);

        }
    }

    public class Explosion : Object
    {
        public int cmp { get; private set; }
        public int cycle { get; private set; }
        public int frame { get; private set; }
        public int frame_courante { get; private set; }
        new public int pos_X { get; set; }
        new public int pos_Y { get; set; }

        public Explosion(int frame, int cycle)
        {
            this.cmp = 0;
            this.color = Color.White;
            this.frame = frame;
            this.frame_courante = 1;
            this.cycle = cycle;
            this.sprite = new Sprite(Art.Texture_Explosion, this.color);
            this.sprite.SetOrigin(new Vector2((sprite.Texture.Width / frame) / 2, (sprite.Texture.Height / 2))); // on fixe le centre pour la rotation


        }
        public override void Update(float elapsetime)
        {
            cmp += (int)elapsetime;
            if (cmp > (this.cycle))
            {
                cmp = 0;
                frame_courante++;
                if (frame_courante > frame) frame_courante = 1;
            }

            this.sprite.SetRect(new Rectangle((frame_courante - 1) * (sprite.Texture.Width / frame), 0, (sprite.Texture.Width / frame), sprite.Texture.Height));

            this.sprite.SetPosition(new Vector2(this.pos_X, pos_Y));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            this.sprite.Draw(spriteBatch);
        }
    }

}