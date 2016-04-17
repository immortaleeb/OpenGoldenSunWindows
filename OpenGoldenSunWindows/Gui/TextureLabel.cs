using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace OpenGoldenSunWindows.Gui
{
    public abstract class TextureLabel : GuiItemBase
    {
        public Vector2 Position { get; set; }
        public virtual Texture2D Texture { get; set; }

        public TextureLabel(Vector2 position)
        {
            this.Position = position;
        }

        public override abstract void Load(ContentManager content);

        public override void Update (GameTime gameTime)
        { 
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw (Texture, Position);
        }
    }
}

