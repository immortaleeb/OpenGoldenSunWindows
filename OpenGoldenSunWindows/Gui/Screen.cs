using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OpenGoldenSunWindows.Gui
{
    public interface Screen
    {
        void Load (ContentManager content);

        void Update (GameTime gameTime);

        void Draw (SpriteBatch spriteBatch, GameTime gameTime);
    }
}

