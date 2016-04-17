using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Animations
{
    public class CursorAnimation : TextureTransformAnimation
    {
        private static int[] offsets = { 0, 1, 2, -1 };

        private Texture2D texture;
        public override Texture2D Texture { get { return texture; } }

        public CursorAnimation (Vector2 position) 
            : base(position, 4, 0.10f)
        {
        }

        public override void Load (Microsoft.Xna.Framework.Content.ContentManager content)
        {
            texture = content.Load<Texture2D> ("Sprites/Icons/Cursor");
        }

        public override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            Vector2 pos = this.Position;
            pos.X += offsets[Frame];
            pos.Y -= offsets[Frame];
            this.Position = pos;
        }
    }
}

