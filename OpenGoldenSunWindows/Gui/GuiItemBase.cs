using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public abstract class GuiItemBase : GuiItem
    {
        private bool isVisible;
        public bool IsVisible { get { return isVisible; } }

        public abstract void Load (ContentManager content);

        protected virtual void OnShow ()
        {
            // Nothing to do by default
        }

        protected virtual void OnHide ()
        {
            // Nothing to do by default
        }

        public virtual void SetVisible(bool visible)
        {
            if (visible)
                OnShow ();
            else
                OnHide ();
            
            this.isVisible = visible;
        }

        public abstract void Update (GameTime gameTime);

        public abstract void Draw (SpriteBatch spriteBatch, GameTime gameTime);
    }
}

