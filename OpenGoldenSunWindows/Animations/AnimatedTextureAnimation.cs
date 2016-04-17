using System;
using OpenGoldenSunWindows.Utils;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Animations
{
    public abstract class AnimatedTextureAnimation : AnimationBase
    {
        public virtual AnimatedTexture Texture { get; set; }

        public AnimatedTextureAnimation (Vector2 position) : base (position)
        {
        }

        public abstract override void Load (ContentManager content);

        public override void Update (GameTime gameTime)
        {
            Texture?.Update (gameTime);
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture?.Draw (spriteBatch, Position);
        }

        public override void Play ()
        {
            Texture?.Play ();
        }

        public override void Pause ()
        {
            Texture?.Pause ();
        }

        public override void Reset ()
        {
            Texture?.Reset ();
        }

        public override void Stop ()
        {
            Texture?.Stop ();
        }
    }
}

