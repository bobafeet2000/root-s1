using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Engine
{
    public class Sprite
    {
        public Texture2D Texture { get; private set; }    
        public Color Color { get; private set; }   
        public Vector2 Position { get; private set; } 
        public float Rotation { get; private set; }
        public Vector2 Origin { get; private set; } 
        public Rectangle Rect { get; private set; } 
        public Vector2 ScaleFactor { get; private set; }
        


        public Sprite(Texture2D texture, Color color) // constructeur
        {
            this.Texture = texture;
            this.Color = color;
            Position = Vector2.Zero;        
            Rotation = 0.0f;
            // origin = Vector2.Zero;
            Origin = new Vector2(texture.Width / 2, texture.Height / 2); // Coordonnées sprite positionnées au centre
            Rect = new Rectangle(0, 0, texture.Width, texture.Height);
            ScaleFactor = Vector2.One;
        }


        public void Draw(SpriteBatch spriteBatch) // draw du sprite
        {
            spriteBatch.Draw(Texture, Position, Rect, this.Color, Rotation,
                              Origin, ScaleFactor, SpriteEffects.None, 0.0f);
        }

        public void SetPosition(Vector2 pos) { Position = pos; } // définit la posistion en absolu

        public void Move(Vector2 deltaPos) { Position += deltaPos; } // définit la posistion en delta

        public void SetRotation(float rotation) { Rotation = rotation; } // définit la rotation en absolu

        public void Turn(float deltarotation) { Rotation += deltarotation; } // définit la rotation en delta

        public void SetOrigin(Vector2 origin) { this.Origin = origin; } // fixe le centre de la sprite (pour rotation)

        public void SetRect(Rectangle newRect) { Rect = newRect; } // définit la zone du fichier ressource (si plusieurs sprite dans le fichier)

        public void SetScale(Vector2 scale) { this.ScaleFactor = scale; } // définit l'échelle en absolu

        public void Scale(Vector2 scale) { ScaleFactor *= scale; } // définit l'échelle via un vector2
    }
}
