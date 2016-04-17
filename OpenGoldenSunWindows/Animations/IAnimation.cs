using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Animations
{
    public interface IAnimation : ILoadableComponent, IUpdateableComponent, IDrawableComponent
    {
        void Load (ContentManager content);

        void Update (GameTime gameTime);

        void Draw (SpriteBatch spriteBatch, GameTime gameTime);

        void Play ();

        void Pause ();

        void Reset ();

        void Stop ();
    }
}

