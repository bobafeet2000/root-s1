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
        public Texture2D Texture { get; private set; } // Texture sprite, lecture seule   
        public Color Color { get; private set; } // Texture sprite, lecture seule   
        public Vector2 Position { get; private set; } // Position sprite, lecture seule
        public float Rotation { get; private set; } // Rotation sprite, lecture seule;
        public Vector2 Origin { get; private set; } // Origine sprite, lecture seule;
        public Rectangle Rect { get; private set; } // Rectangle sprite, lecture seule;
        public Vector2 ScaleFactor { get; private set; } // Scale sprite, lecture seule;

        // ========================================================================
        // Creates a new sprite using the given texture
        // ========================================================================
        public Sprite(Texture2D texture, Color color)
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

        // ========================================================================
        // Draws the sprite onto a spritebatch using its settings
        // ========================================================================
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Rect, this.Color, Rotation,
                              Origin, ScaleFactor, SpriteEffects.None, 0.0f);
        }

        // ========================================================================
        // Position modifiers
        // ========================================================================
        /// Sets the sprite's position given a Vector2
        public void SetPosition(Vector2 pos) { Position = pos; }

        /// Adds to the sprite's position given a Vector2 delta
        public void Move(Vector2 deltaPos) { Position += deltaPos; }

        // ========================================================================
        // Rotation modifiers
        // ========================================================================
        /// Sets the sprite's rotation given a float
        public void SetRotation(float rotation) { Rotation = rotation; }

        /// Adds to the sprite's rotation given a float delta
        public void Turn(float deltarotation) { Rotation += deltarotation; }

        // ========================================================================
        // Origin modifiers
        // ========================================================================
        /// Sets the sprite's origin given a Vector2
        public void SetOrigin(Vector2 origin) { this.Origin = origin; }

        // ========================================================================
        // Rect modifiers
        // ========================================================================
        /// Sets the sprite's source rectangle given a new Rectangle
        public void SetRect(Rectangle newRect) { Rect = newRect; }

        // ========================================================================
        // Scale modifiers
        // ========================================================================
        /// Sets the sprite's scale given a new Vector2 factor
        public void SetScale(Vector2 scale) { this.ScaleFactor = scale; }

        /// Scales the sprite's current scale by the given Vector2 factor
        public void Scale(Vector2 scale) { ScaleFactor *= scale; }
    }
}
