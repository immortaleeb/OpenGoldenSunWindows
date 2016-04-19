using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Animations
{
    public class CursorAnimation : TextureTransformAnimation
    {
        private static int[] offsets = { 0, 1, 2, -1 };

        private Vector2 drawPosition;
        private Texture2D texture;
        public override Texture2D Texture { get { return texture; } }

        public CursorAnimation (Vector2 position) 
            : base(position, 4, 0.10f)
        {
            this.drawPosition = new Vector2 (this.Position.X, this.Position.Y);
        }

        public override void Load (Microsoft.Xna.Framework.Content.ContentManager content)
        {
            texture = content.Load<Texture2D> ("Sprites/Icons/Cursor");
        }

        public override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            this.drawPosition = new Vector2 (this.Position.X, this.Position.Y);
            this.drawPosition.X += offsets[Frame];
            this.drawPosition.Y -= offsets[Frame];
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw (this.Texture, this.drawPosition);
        }
    }
}

