using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using OpenGoldenSunWindows.Animations;

namespace OpenGoldenSunWindows.Gui
{
    public class GuiItemCollection : GuiItem
    {
        public IList<GuiItem> Children { get; }
        public IList<IAnimation> Animations { get; }

        public GuiItemCollection ()
        {
            Children = new List<GuiItem> ();
            Animations = new List<IAnimation> ();
        }

        protected void Add(GuiItem child)
        {
            Children.Add (child);
        }

        protected void Add(IAnimation animation)
        {
            Animations.Add (animation);
        }

        public virtual void Load (ContentManager content)
        {
            foreach (var animation in Animations) {
                animation.Load (content);
            }

            foreach (var child in Children) {
                child.Load (content);
            }
        }

        public virtual void Start()
        {
            foreach (var animation in Animations) {
                animation.Play ();
            }

            foreach (var child in Children) {
                child.Start ();
            }
        }

        public virtual void Stop()
        {
            foreach (var animation in Animations) {
                animation.Stop ();
            }

            foreach (var child in Children) {
                child.Stop ();
            }
        }

        public virtual void Update (GameTime gameTime)
        {
            foreach (var animation in Animations) {
                animation.Update (gameTime);
            }

            foreach (var child in Children) {
                child.Update (gameTime);
            }
        }

        public virtual void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var animation in Animations) {
                animation.Draw (spriteBatch, gameTime);
            }

            foreach (var child in Children) {
                child.Draw (spriteBatch, gameTime);
            }
        }
    }
}

