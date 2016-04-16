using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public interface GuiItem
    {
        void Load (ContentManager content);

        void Start();

        void Stop();

        void Update (GameTime gameTime);

        void Draw (SpriteBatch spriteBatch, GameTime gameTime);
    }
}

