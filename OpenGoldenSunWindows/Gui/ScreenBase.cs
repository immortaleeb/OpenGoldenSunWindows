using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OpenGoldenSunWindows.Gui
{
    public abstract class ScreenBase : GuiItemCollection, Screen
    {
        public Controller Controller { get; }

        public ScreenBase (Controller controller)
        {
            Controller = controller;
        }

        public virtual void Update (GameTime gameTime)
        {
            Controller.Update (gameTime);

            base.Update (gameTime);
        }
    }
}

