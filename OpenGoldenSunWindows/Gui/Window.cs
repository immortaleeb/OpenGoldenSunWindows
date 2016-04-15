using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public interface Window
    {
        void Update (GameTime gameTime);

        void Draw (SpriteBatch spriteBatch, GameTime gameTime, int x, int y);
    }
}

