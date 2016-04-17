using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using OpenGoldenSunWindows.Animations;

namespace OpenGoldenSunWindows.Gui
{
    public class GuiItemCollection : GuiItemBase
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

        protected void Add(IAnimation animation)
        {
            Children.Add (new AnimationLabel (animation));
        }

        protected void Remove(GuiItem child)
        {
            Children.Remove (child);
        }

        public override void Load (ContentManager content)
        {
            foreach (var child in Children) {
                child.Load (content);
            }
        }

        public override void SetVisible(bool visible)
        {
            foreach (var child in Children) {
                child.SetVisible (visible);
            }

            base.SetVisible (visible);
        }

        public override void Update (GameTime gameTime)
        {
            foreach (var child in Children) {
                if (child.IsVisible)
                    child.Update (gameTime);
            }
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var child in Children) {
                if (child.IsVisible)
                    child.Draw (spriteBatch, gameTime);
            }
        }
    }
}

