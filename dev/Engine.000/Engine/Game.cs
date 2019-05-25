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
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private float elapsetime;
        private int choice = 0;
        private bool connected=false; //bool pour savoir si le joueur connecté
        private int connectedelaps=0;   // compteur pour afficher les joueurs avant de lancer la partie

        private ScreenBoot screenboot; // Ecran de boot
        private ScreenHome screenhome; // Ecran d'accueil
        private ScreenInstruction screeninstruction; // Ecran d'accueil
        private ScreenCredit screencredit; // Ecran de crédit
        private ScreenMenuMulti screenmenumulti; // Ecran du menu du selection du joueur
        private ScreenMenuMulti2 screenmenumulti2; //Ecran du menu multi
        private Session session; // Partie mono joueur
        private NetSession netsession; // Partie multi joueur

        private int timer; // timer à usage multiple


        // Récupération des constantes générales 
        Color backcolor = new Color(Constant.BKCOLOR_R, Constant.BKCOLOR_G, Constant.BKCOLOR_B);  // couleur du fond
        Color debug_font_color = new Color(Constant.FONT_DEBUG_COLOR_R, Constant.FONT_DEBUG_COLOR_G, Constant.FONT_DEBUG_COLOR_B); // couleur de la font DEBUG
       

        public enum GameState
        {
            //Tous les états possibles du jeu
            Boot, MainMenu, Instruction, Credit, PlayGame, Break, MultiMenu, Multi, PlayGameMulti
        }
        GameState CurrentGameState = GameState.Boot;


        /// <summary>
        ///  Variables nécessaires au calcul du framerate 
        /// </summary>
        int _total_frames = 0;
        float _elapsed_time = 0.0f;
        int _fps = 0;

        public Game() // Constructeur 
        {
            graphics = new GraphicsDeviceManager(this);

            /// <summary>
            /// suppression frame rate, sinon 60 FPS par défaut
            ///this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 100.0f); // fixe le FPS 
            ///graphics.SynchronizeWithVerticalRetrace = false;
            ///this.IsFixedTimeStep = true;
            /// <summary>


            /// <summary>
            /// Chargement et application des paramètres d'affichage 
            /// <summary>
            graphics.PreferredBackBufferHeight = Constant.MAIN_WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = Constant.MAIN_WINDOW_WIDTH;
            graphics.IsFullScreen = Constant.MAIN_WINDOW_FULLSCREEN;
            Window.Title = Constant.GAME_NAME;
            graphics.ApplyChanges();
            if (Constant.MAIN_WINDOWS_BORDERLESS) { this.Window.IsBorderlessEXT = Constant.MAIN_WINDOWS_BORDERLESS; } // A faire après le Applychanges !


            /// <summary>
            /// Désignation du répertoire de ressources
            /// <summary>
            Content.RootDirectory = Constant.CONTENT_DIR;

        }

        /// <summary>
        /// This function is automatically called when the game launches to initialize any non-graphic variables.
        /// </summary>
        protected override void Initialize()
        {
            timer = 0;
            base.Initialize();
        }

        /// <summary>
        /// Automatically called when your game launches to load any game assets (graphics, audio etc.)
        /// </summary>
        protected override void LoadContent()
        {
            // SpriteBatch, objet de gestion de l'affichage des sprites
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Chargement du contenu
            Art.Load(Content);

            screenboot = new ScreenBoot(Constant.GAME_BOOT);
            screenhome = new ScreenHome(Constant.GAME_NAME);
        
        }

        /// <summary>
        /// Called each frame to update the game. Games usually runs 60 frames per second.
        /// Each frame the Update function will run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            /// DEBUG: baisse du FPS : 
            ///System.Threading.Thread.Sleep(14);
           
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

            elapsetime = (float)gameTime.ElapsedGameTime.TotalMilliseconds; // calcul du temps passé depuis le dernier update

            Input.Update();  // Update entrée clavier du joueur

            switch (CurrentGameState)
            {
                case GameState.Boot:
                    timer += (int)elapsetime;
                    if (timer > Constant.GAME_BOOT_LAPS) CurrentGameState = GameState.MainMenu;
                    else screenboot.Update(elapsetime); 
                    break;

                case GameState.MainMenu:
                    if (Input.KeyPressed(Keys.Enter))
                    {
                        session = new Session();
                        CurrentGameState = GameState.PlayGame;
                        break;
                    }
                    if (Input.KeyPressed(Keys.Escape))
                    {
                        this.Exit();
                    }
                    if (Input.KeyPressed(Keys.H))
                    {
                        screeninstruction = new ScreenInstruction(Constant.GAME_INSTRUCTION);
                        CurrentGameState = GameState.Instruction;
                        break;
                    }
                    if (Input.KeyPressed(Keys.C))
                    {
                        screencredit = new ScreenCredit(Constant.GAME_CREDIT);
                        CurrentGameState = GameState.Credit;
                        break;
                    }
                    if (Input.KeyPressed(Keys.M))
                    {
                        screenmenumulti = new ScreenMenuMulti(Constant.GAME_MENUMULTI);
                        CurrentGameState = GameState.MultiMenu ;
                        break;
                    }
                    screenhome.Update(elapsetime);
                    break;

                case GameState.PlayGame:

                    if (Input.KeyPressed(Keys.Escape))
                    {
                        session.End();
                        session = null;
                        CurrentGameState = GameState.MainMenu;
                        break;
                    }
                    session.Update(elapsetime);
                    break;

                case GameState.Instruction:

                    if (Input.KeyPressed(Keys.Escape))
                    {
                        screeninstruction = null;
                        CurrentGameState = GameState.MainMenu;
                        break;
                    }
                    screeninstruction.Update(elapsetime);
                    break;

                case GameState.Credit:

                    if (Input.KeyPressed(Keys.Escape))
                    {
                        screencredit = null;
                        CurrentGameState = GameState.MainMenu;
                        break;
                    }
                    screencredit.Update(elapsetime);
                    break;

                case GameState.MultiMenu:
                    if (Input.KeyPressed(Keys.Escape))
                    {
                        screenmenumulti = null;
                        CurrentGameState = GameState.MainMenu;
                        break;
                    }
                    if (Input.KeyPressed(Keys.D1))
                    {
                        screenmenumulti.SetChoice(choice=1);
                        break;
                    }
                    if (Input.KeyPressed(Keys.D2))
                    {
                        screenmenumulti.SetChoice(choice=2);
                        break;
                    }
                    if (Input.KeyPressed(Keys.Enter) && choice != 0)
                    {
                        screenmenumulti = null;
                        screenmenumulti2 = new ScreenMenuMulti2(Constant.GAME_MENUMULTI2,choice,connected);
                        CurrentGameState = GameState.Multi;
                        break;
                    }
                    screenmenumulti.Update(elapsetime);
                    break;

                case GameState.Multi:
                    if (Input.KeyPressed(Keys.Escape))
                    {
                        screenmenumulti2 = null;
                        screenmenumulti = new ScreenMenuMulti(Constant.GAME_MENUMULTI);
                        connected = false;
                        connectedelaps = 0;
                        CurrentGameState = GameState.MultiMenu;
                        break;
                    }
                    if (Input.KeyPressed(Keys.Enter)) // là il faut lancer les couches réseau et tester la connexion à une partie ou à un joueur
                    {
                        connected = true;              
                    }
                    if (connected == true)
                    {
                        connectedelaps++;
                    }
                    if (connectedelaps>120)
                    {
                        screenmenumulti2 = null;
                        netsession = new NetSession();
                        CurrentGameState = GameState.PlayGameMulti;
                        break;
                    }
                    screenmenumulti2.SetConnected(connected);
                    screenmenumulti2.Update(elapsetime);

                    break;

                case GameState.PlayGameMulti:

                    if (Input.KeyPressed(Keys.Escape))
                    {
                        netsession.End();
                        netsession = null;
                        connected = false;
                        connectedelaps = 0;
                        CurrentGameState = GameState.MainMenu;
                        break;
                    }
                    netsession.Update(elapsetime);
                    break;
            }

            //Update base
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game is ready to draw to the screen, it's also called each frame.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            //Effacement du device
            GraphicsDevice.Clear(backcolor);

            // Incrément du compteur de frame quand entre dans la méthode Draw
            _total_frames++;

            // SpriteBatch START
            spriteBatch.Begin();


            switch (CurrentGameState)
            {
                case GameState.Boot:
                    screenboot.Draw(spriteBatch);
                    break;
                case GameState.MainMenu:
                   screenhome.Draw(spriteBatch);
                    break;
                case GameState.PlayGame:
                   session.Draw(spriteBatch);
                    break;          
                case GameState.Instruction:
                    screeninstruction.Draw(spriteBatch);
                    break;
                case GameState.Credit:
                    screencredit.Draw(spriteBatch);
                    break;
                case GameState.MultiMenu:
                    screenmenumulti.Draw(spriteBatch);
                    break;
                case GameState.Multi:
                    screenmenumulti2.Draw(spriteBatch);
                    break;
                case GameState.PlayGameMulti:
                    netsession.Draw(spriteBatch);
                    break;
            }

            // Affichage du compteur de frame si DEBUG
            if (Constant.ISDEBUG) { spriteBatch.DrawString(Art.Font_Debug, string.Format("FPS = {0}", _fps), new Vector2(10.0f, 10.0f), debug_font_color * Constant.FONT_DEBUG_COLOR_A); }

            // SpriteBatch END 
            spriteBatch.End();

            //Draw base
            base.Draw(gameTime);

        }
    }
}
