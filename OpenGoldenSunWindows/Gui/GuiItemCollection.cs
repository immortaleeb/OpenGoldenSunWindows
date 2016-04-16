using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace OpenGoldenSunWindows
{
    public class GuiItemCollection : GuiItem
    {
        public IList<GuiItem> Children { get; }

        public GuiItemCollection ()
        {
            Children = new List<GuiItem> ();
        }

        protected void Add(GuiItem child)
        {
            Children.Add (child);
        }

        public virtual void Load (ContentManager content)
        {
            foreach (var child in Children) {
                child.Load (content);
            }
        }

        public virtual void Start()
        {
            foreach (var child in Children) {
                child.Start ();
            }
        }

        public virtual void Stop()
        {
            foreach (var child in Children) {
                child.Stop ();
            }
        }

        public virtual void Update (GameTime gameTime)
        {
            foreach (var child in Children) {
                child.Update (gameTime);
            }
        }

        public virtual void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var child in Children) {
                child.Draw (spriteBatch, gameTime);
            }
        }
    }
}

