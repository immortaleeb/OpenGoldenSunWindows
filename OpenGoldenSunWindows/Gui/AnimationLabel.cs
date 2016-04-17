using System;
using OpenGoldenSunWindows.Animations;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public class AnimationLabel : GuiItemBase
    {
        public IAnimation Animation { get; }

        public AnimationLabel (IAnimation animation)
        {
            this.Animation = animation;
        }

        public override void Load (ContentManager content)
        {
            this.Animation.Load (content);
        }

        protected override void OnShow ()
        {
            this.Animation.Play ();
        }

        protected override void OnHide ()
        {
            this.Animation.Stop ();
        }

        public override void Update (GameTime gameTime)
        {
            this.Animation.Update (gameTime);
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Animation.Draw (spriteBatch, gameTime);
        }
    }
}
