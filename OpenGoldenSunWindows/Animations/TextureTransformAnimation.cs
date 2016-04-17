using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace OpenGoldenSunWindows.Animations
{
    public abstract class TextureTransformAnimation : AnimationBase
    {
        private float elapsedTime;
        private int frame;
        private bool isRunning;

        public float FrameDuration { get; }
        public int FrameCount { get; }
        public bool IsRunning { get { return isRunning; } }
        public abstract Texture2D Texture { get; }
        public int Frame { get { return frame; } }

        public TextureTransformAnimation (Vector2 position, int frameCount, float frameDuration) : base(position)
        {
            this.FrameCount = frameCount;
            this.FrameDuration = frameDuration;
            this.elapsedTime = 0;
            this.frame = 0;
            this.isRunning = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (!isRunning)
                return;

            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime >= FrameDuration) {
                elapsedTime -= FrameDuration;
                frame = (frame + 1) % FrameCount;
            }
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw (this.Texture, this.Position);
        }

        public override void Play ()
        {
            isRunning = true;
        }

        public override void Pause ()
        {
            isRunning = false;
        }

        public override void Stop ()
        {
            Pause ();
        }
    }
}

