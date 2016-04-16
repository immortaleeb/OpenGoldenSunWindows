#region Using Statements
using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Gui.StatusScreen;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Gui.MenuScreen;

#endregion

namespace OpenGoldenSunWindows
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class OpenGoldenSunGame : Game
    {
        const int windowScale = 3;
        Point gbaWindowSize = new Point(240, 160);
        Point windowSize;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D target;

        Party party;

        public OpenGoldenSunGame ()
        {
            windowSize = new Point(gbaWindowSize.X * windowScale, gbaWindowSize.Y * windowScale);

            graphics = new GraphicsDeviceManager (this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = windowSize.X;
            graphics.PreferredBackBufferHeight = windowSize.Y;

            IsMouseVisible = true;

            Content.RootDirectory = "Content";
        }

        private void InitParty()
        {
            var flint = new Djinni ("Flint", Element.Earth);
            var scorch = new Djinni ("Scorch", Element.Fire);

            var isaac = new Character ("Isaac", new CharacterClass ("Squire"), 1, 0, 30, 30, 13, 13, 25, 13, 13, 3, StatusAilment.NORMAL);
            var garet = new Character ("Garet", new CharacterClass ("Brute"), 1, 0, 27, 33, 10, 23, 17, 12, 10, 5, StatusAilment.NORMAL);
            var jenna = new Character ("Jenna", new CharacterClass ("Flame User"), 1, 0, 32, 36, 24, 26, 19, 15, 15, 3, StatusAilment.NORMAL);

            isaac.Djinn.Add (flint);
            jenna.Djinn.Add (scorch);

            var characters = new List<Character>();
            characters.Add (isaac);
            characters.Add (garet);
            characters.Add (jenna);
            party = new Party(characters);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize ()
        {
            // Initialize the render target
            target = new RenderTarget2D(GraphicsDevice, 240, 160);

            // Create a party
            InitParty();


            // Initialize helpers
            GraphicsHelper.Initialize(GraphicsDevice);

            // Create the windows
            WindowManager.Initialize(GraphicsDevice);
            ScreenManager.Initialize (party);

            base.Initialize ();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent ()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch (GraphicsDevice);

            // Helpers
            CharacterRenderer.Load (Content);
            IconRenderer.Load (Content);

            // Window stuff
            WindowManager.Load (Content);
            ScreenManager.Load (Content);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update (GameTime gameTime)
        {
            // Update helpers
            CharacterRenderer.Update(gameTime);

            // Update screens
            ScreenManager.Update(gameTime);

            base.Update (gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw (GameTime gameTime)
        {
            // Render to the target
            GraphicsDevice.SetRenderTarget (target);
            spriteBatch.Begin (0, BlendState.AlphaBlend);
            {
                graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
                ScreenManager.Draw (spriteBatch, gameTime);
            }
            spriteBatch.End ();
            GraphicsDevice.SetRenderTarget (null);

            // Render the target to the window
            spriteBatch.Begin (0, null, SamplerState.PointClamp, null, null, null);
            {
                spriteBatch.Draw (target, new Rectangle(0, 0, windowSize.X, windowSize.Y), target.Bounds, Color.White);
            }
            spriteBatch.End ();

            base.Draw (gameTime);
        }
    }
}

