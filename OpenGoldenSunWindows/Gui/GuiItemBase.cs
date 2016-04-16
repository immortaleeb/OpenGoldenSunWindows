using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public abstract class GuiItemBase : GuiItem
    {
        public virtual void Load (ContentManager content)
        {
        }

        public virtual void Start()
        {
        }

        public virtual void Stop()
        {
        }

        public virtual void Update (GameTime gameTime)
        {
        }

        public virtual void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
        }
    }
}

