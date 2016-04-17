using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public interface GuiItem : IDrawableComponent, IUpdateableComponent, ILoadableComponent
    {
        void Load (ContentManager content);

        bool IsVisible { get; }

        void SetVisible (bool visible);

        void Update (GameTime gameTime);

        void Draw (SpriteBatch spriteBatch, GameTime gameTime);
    }
}

