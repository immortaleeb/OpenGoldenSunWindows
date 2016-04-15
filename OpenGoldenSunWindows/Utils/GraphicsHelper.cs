using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Utils
{
    public class GraphicsHelper
    {
        private static Texture2D pixel;

        /**
         * This method should be called before using the other
         * methods in this class
         */
        public static void Initialize(GraphicsDevice graphics)
        {
            // Initialize a white pixel
            pixel = new Texture2D (graphics, 1, 1);
            Color[] colorData = { Color.White };
            pixel.SetData<Color> (colorData);
        }

        /**
         * Clears a given area with a given color.
         * Note: SpriteBatch.begin() has to be called before calling this method.
         */
        public static void Clear(SpriteBatch spriteBatch, Rectangle rectangle, Color color)
        {
            spriteBatch.Draw (pixel, rectangle, color);
        }

        /**
         * Sets the color of a single pixel at the given position.
         * Note: SpriteBatch.begin() has to be called before calling this method.
         */
        public static void SetPixel(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw (pixel, position, color);
        }

        /**
         * Draws a horizontal line.
         * Note: SpriteBatch.begin() has to be called before calling this method.
         */
        public static void DrawHorizontalLine(SpriteBatch spriteBatch, Point start, int length, int thickness, Color color)
        {
            Clear (spriteBatch, new Rectangle(start.X, start.Y, length, thickness), color);
        }

        /**
         * Draws a horizontal line.
         * Note: SpriteBatch.begin() has to be called before calling this method.
         */
        public static void DrawHorizontalLine(SpriteBatch spriteBatch, Point start, int length, Color color)
        {
            DrawHorizontalLine (spriteBatch, start, length, 1, color);
        }

        /**
         * Draws a vertical line.
         * Note: SpriteBatch.begin() has to be called before calling this method.
         */
        public static void DrawVerticalLine(SpriteBatch spriteBatch, Point start, int length, int thickness, Color color)
        {
            Clear (spriteBatch, new Rectangle(start.X, start.Y, thickness, length), color);
        }

        /**
         * Draws a vertical line.
         * Note: SpriteBatch.begin() has to be called before calling this method.
         */
        public static void DrawVerticalLine(SpriteBatch spriteBatch, Point start, int length, Color color)
        {
            DrawVerticalLine (spriteBatch, start, length, 1, color);
        }
    }
}

