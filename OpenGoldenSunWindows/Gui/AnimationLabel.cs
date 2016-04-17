using System;
using OpenGoldenSunWindows.Animations;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public class AnimationLabel : GuiItem
    {
        public IAnimation Animation { get; }

        public AnimationLabel (IAnimation animation)
        {
            this.Animation = animation;
        }

        public virtual void Load (ContentManager content)
        {
            this.Animation.Load (content);
        }

        public virtual void Start()
        {
            this.Animation.Play ();
        }

        public virtual void Stop()
        {
            this.Animation.Stop ();
        }

        public virtual void Update (GameTime gameTime)
        {
            this.Animation.Update (gameTime);
        }

        public virtual void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Animation.Draw (spriteBatch, gameTime);
        }
    }
}
