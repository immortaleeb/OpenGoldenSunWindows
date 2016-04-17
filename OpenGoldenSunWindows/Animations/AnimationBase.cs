using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Animations
{
    public abstract class AnimationBase : IAnimation
    {
        public Vector2 Position { get; set; }

        public AnimationBase (Vector2 position)
        {
            this.Position = position;
        }

        public abstract void Load (ContentManager content);

        public abstract void Update (GameTime gameTime);

        public abstract void Draw (SpriteBatch spriteBatch, GameTime gameTime);

        public virtual void Play ()
        {
        }

        public virtual void Pause ()
        {
        }

        public virtual void Reset ()
        {
            Stop ();
            Play ();
        }

        public virtual void Stop ()
        {
        }
    }
}

