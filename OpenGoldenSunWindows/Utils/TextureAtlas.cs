using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace OpenGoldenSunWindows.Utils
{
    public class TextureAtlas
    {
        private Texture2D texture;

        public int Width { get { return texture.Width; } }
        public int Height { get { return texture.Height; } }

        public int RegionWidth { get; }
        public int RegionHeight { get; }

        public int Rows { get { return Height / RegionHeight; } }
        public int Columns { get { return Width / RegionWidth; } }

        public TextureAtlas (Texture2D texture, int regionWidth, int regionHeight)
        {
            this.texture = texture;
            RegionWidth = regionWidth;
            RegionHeight = regionHeight;
        }

        public void Draw(SpriteBatch spriteBatch, int index, Vector2 position, Color? color = null)
        {
            Draw (spriteBatch, index / Columns, index % Columns, position, color);
        }

        public void Draw(SpriteBatch spriteBatch, int row, int col, Vector2 position, Color? color = null)
        {
            Rectangle source = new Rectangle (RegionWidth * col, RegionHeight * row, RegionWidth, RegionHeight);
            spriteBatch.Draw (texture, position, null, source, null, 0, null, color);
        }

        public void Draw(SpriteBatch spriteBatch, int index, Vector2 position, Rectangle relativeSource, Color? color = null)
        {
            Draw (spriteBatch, index / Columns, index % Columns, position, relativeSource, color);
        }

        public void Draw(SpriteBatch spriteBatch, int row, int col, Vector2 position, Rectangle relativeSource, Color? color = null)
        {
            Rectangle source = new Rectangle (
                RegionWidth * col + relativeSource.X, 
                RegionHeight * row + relativeSource.Y, 
                relativeSource.Width, relativeSource.Height);
            
            spriteBatch.Draw (texture, position, null, source, null, 0, null, color);
        }
    }
}

