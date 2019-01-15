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
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spritefont;
        Color backcolor;

        // a enlever
        Texture2D player;
        int posx,posy;
        int largeur;

        /// <summary>
        ///  Variables nécessaires au calcul du framerate 
        /// </summary>
        int _total_frames = 0;
        float _elapsed_time = 0.0f;
        int _fps = 0;

        public Game(int width, int height, bool isfullscreen) // Constructeur avec la taille de la fenetre en parametre
        {
            graphics = new GraphicsDeviceManager(this);

            /// <summary>
            /// suppression frame rate, sinon 60 FPS par défaut
            ///graphics.SynchronizeWithVerticalRetrace = false;
            ///IsFixedTimeStep = false;
            /// <summary>


            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.IsFullScreen = isfullscreen;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            // a enlever
            largeur = width;
            posx = width / 2;
            posy = height - 50;
        }

        /// <summary>
        /// This function is automatically called when the game launches to initialize any non-graphic variables.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Automatically called when your game launches to load any game assets (graphics, audio etc.)
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // a enlever
            player = this.Content.Load<Texture2D>("player");

            // Création d'un new SpriteFont
            //spritefont = Content.Load<SpriteFont>("arial");
#if DEBUG
            spritefont = Content.Load<SpriteFont>("debug_text");
#endif

        }

        /// <summary>
        /// Called each frame to update the game. Games usually runs 60 frames per second.
        /// Each frame the Update function will run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            /// <summary>
            /// Calcul du framerate
            /// <summary> 
            _elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsed_time >= 1000.0f)
            {
                _fps = _total_frames;
                _total_frames = 0;
                _elapsed_time = 0;
            }

            // ESC = Sortie du programme
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // a enlever
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (posx >= largeur - player.Width)
                    posx = largeur - player.Width;
                    else posx += 2;
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (posx <= 0) posx = 0;
                else posx -= 2;
            }
               

            //Update the things FNA handles for us underneath the hood:
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game is ready to draw to the screen, it's also called each frame.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            //This will clear what's on the screen each frame, if we don't clear the screen will look like a mess:
            GraphicsDevice.Clear(Color.Black);

            // Incrément du compteur de frame quand entre dans la méthode Draw
            _total_frames++;

            // SpriteBatch START
            spriteBatch.Begin();

            // a enlaver
            spriteBatch.Draw(player, new Vector2(posx, posy), null, Color.White);

#if DEBUG
            // Affichage du compteur de frame
            spriteBatch.DrawString(spritefont, string.Format("FPS={0}", _fps), new Vector2(10.0f, 10.0f), Color.White);
#endif

            // SpriteBatch END 
            spriteBatch.End();

            //Draw the things FNA handles for us underneath the hood:
            base.Draw(gameTime);

        }
    }
}
