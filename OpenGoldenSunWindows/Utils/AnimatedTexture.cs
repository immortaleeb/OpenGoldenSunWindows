using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Utils
{
    public class AnimatedTexture
    {
        Texture2D texture;
        Rectangle sourceRectangle;
        int frameCount;
        float[] timesPerFrame;
        float totalElapsed;
        int currentFrame;

        public int FrameWidth { get { return FrameWidth; } }
        int frameWidth;
        public int FrameHeight { get { return FrameHeight; } }
        int frameHeight;

        private bool Paused;

        public AnimatedTexture ()
        {
        }

        public void Load(ContentManager content, string asset, int frameCount, float[] timesPerFrame)
        {
            Texture2D texture = content.Load<Texture2D> (asset);
            Rectangle sourceRectangle = new Rectangle (0, 0, texture.Width, texture.Height);
            Load (texture, sourceRectangle, frameCount, timesPerFrame);
        }

        public void Load(Texture2D texture, Rectangle sourceRectangle, int frameCount, float[] timesPerFrame)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
            this.frameCount = frameCount;
            this.timesPerFrame = timesPerFrame;
            this.totalElapsed = 0;
            this.currentFrame = 0;
            this.frameWidth = sourceRectangle.Width / frameCount;
            this.frameHeight = sourceRectangle.Height;
            Paused = false;
        }

        public void Update(GameTime gameTime)
        {
            if (Paused)
                return;

            totalElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (totalElapsed > timesPerFrame[currentFrame]) {
                totalElapsed -= timesPerFrame [currentFrame];
                currentFrame = (currentFrame + 1) % frameCount;
            }
        }

        // TODO refactor method
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2? origin = null, float rotation = 0, Color? color = null, SpriteEffects spriteEffects = SpriteEffects.None)
        {
            Rectangle source = new Rectangle (
                                   sourceRectangle.X + frameWidth * currentFrame,
                                   sourceRectangle.Y,
                                   frameWidth, frameHeight);
            
            spriteBatch.Draw(texture, position, null, source, origin, rotation, null, color, spriteEffects);
        }

        public bool IsPaused
        {
            get { return Paused; }
        }
        public void Reset()
        {
            currentFrame = 0;
            totalElapsed = 0f;
        }
        public void Stop()
        {
            Pause();
            Reset();
        }
        public void Play()
        {
            Paused = false;
        }
        public void Pause()
        {
            Paused = true;
        }
    }
}

