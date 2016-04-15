using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public abstract class ScreenBase : Screen
    {
        public Controller Controller { get; }

        public ScreenBase (Controller controller)
        {
            Controller = controller;
        }

        public virtual void Update (GameTime gameTime)
        {
            Controller.Update (gameTime);
        }

        public abstract void Draw (SpriteBatch spriteBatch, GameTime gameTime);
    }
}

