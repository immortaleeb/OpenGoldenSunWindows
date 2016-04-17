using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace OpenGoldenSunWindows
{
    public interface IDrawableComponent
    {
        void Draw (SpriteBatch spriteBatch, GameTime gameTime);
    }
}

