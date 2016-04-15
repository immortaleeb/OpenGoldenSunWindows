using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui
{
    public abstract class WindowBase : Window
    {
        public int Width { get; }
        public int Height { get; }

        Color shadeColor = Color.Black;
        Color variantDifference = new Color(0, 8, 16);
        Color darkBorderColor = new Color (80, 80, 80);
        Color lightBorderColor = new Color (248, 248, 248);
        Color grayBorderColor = new Color (160, 160, 160);

        public WindowBase (int width, int height)
        {
            Width = width;
            Height = height;
        }

        private Color addColors(Color color1, Color color2)
        {
            return new Color (color1.ToVector3 () + color2.ToVector3 ());
        }

        private Color substrColors(Color color1, Color color2)
        {
            return new Color (color1.ToVector3 () - color2.ToVector3 ());
        }

        private void DrawOutsideBorder(SpriteBatch spriteBatch, int x, int y)
        {
            // Upper border
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(x + 2, y), Width - 4, darkBorderColor);
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(x + 2, y + 1), Width - 4, lightBorderColor);
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(x + 2, y + 2), Width - 5, grayBorderColor);

            // Upper left corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + 1, y + 1), darkBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + 1, y), shadeColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x, y + 1), shadeColor);

            // Upper right corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + Width - 2, y + 1), darkBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + Width - 2, y), shadeColor);

            // Lower border
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(x + 3, y + Height - 4), Width - 4, darkBorderColor);
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(x + 2, y + Height - 3), Width - 5, lightBorderColor);
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(x + 2, y + Height - 2), Width - 4, grayBorderColor);

            // Left border
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x, y + 2), Height - 3, darkBorderColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + 1, y + 2), Height - 4, lightBorderColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + 2, y + 2), Height - 5, grayBorderColor);

            // Bottom left corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + 1, y + Height - 3), grayBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + 1, y + Height - 2), darkBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x, y + Height - 2), shadeColor);

            // Right border
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + Width - 4, y + 3), Height - 6, darkBorderColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + Width - 3, y + 2), Height - 5, lightBorderColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + Width - 2, y + 2), Height - 3, grayBorderColor);

            // Bottom right corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + Width - 3, y + Height - 3), grayBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + Width - 2, y + Height - 2), darkBorderColor);

            // Border shadows
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(x + 1, y + Height - 1), Width - 2, shadeColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + Width - 1, y + 1), Height - 2, shadeColor);
        }

        private void DrawInsideDetails(SpriteBatch spriteBatch, int x, int y)
        {
            // Color variants
            Color lightVariant1 = addColors(WindowManager.Color, variantDifference);
            Color lightVariant2 = addColors(lightVariant1, variantDifference);
            Color lightVariant3 = addColors(lightVariant2, variantDifference);

            Color darkVariant1 = substrColors(WindowManager.Color, variantDifference);
            Color darkVariant2 = substrColors(darkVariant1, variantDifference);
            Color darkVariant3 = substrColors(darkVariant2, variantDifference);

            // Top left corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + 3, y + 3), darkBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + 4, y + 4), shadeColor);

            // Top right corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + Width - 5, y + 4), shadeColor);

            // Bottom left corner
            GraphicsHelper.SetPixel(spriteBatch, new Vector2(x + 4, y + Height - 5), shadeColor);

            // Bottom right corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (x + Width - 5, y + Height - 5), darkBorderColor);

            // Top rows
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(x + 4, y + 3), Width - 8, shadeColor);
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(x + 5, y + 4), Width - 10, darkVariant3);
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(x + 5, y + 5), Width - 10, darkVariant2);
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point (x + 6, y + 6), Width - 12, darkVariant1);

            // Left rows
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + 3, y + 4), Height - 8, shadeColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + 4, y + 5), Height - 10, darkVariant3);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + 5, y + 5), Height - 10, darkVariant2);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + 5, y + 5), Height - 10, darkVariant2);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + 6, y + 6), Height - 8, darkVariant1);

            // Bottom rows
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(x + 7, y + Height - 7), Width - 13, lightVariant1);
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(x + 6, y + Height - 6), Width - 12, lightVariant2);
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(x + 5, y + Height - 5), Width - 10, lightVariant3);

            // Right rows
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + Width - 7, y + 7), Height - 14, lightVariant1);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + Width - 6, y + 6), Height - 11, lightVariant2);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(x + Width - 5, y + 5), Height - 10, lightVariant3);

        }

        private void DrawFrame(SpriteBatch spriteBatch, GameTime gameTime, int x, int y)
        {
            // Fill the window content space with color
            GraphicsHelper.Clear (spriteBatch, new Rectangle(x + 3, y + 3, Width - 7, Height - 7), WindowManager.Color);

            // Draw the inside border details
            DrawInsideDetails(spriteBatch, x, y);

            // Draw the border around the window content
            DrawOutsideBorder (spriteBatch, x, y);
        }

        protected abstract void DrawContent (SpriteBatch spriteBatch, GameTime gameTime, int x, int y);

        public void Update (GameTime gameTime)
        {
            // Do nothing by default
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, int x, int y)
        {
            DrawFrame (spriteBatch, gameTime, x, y);
            DrawContent (spriteBatch, gameTime, x, y);
        }
    }
}

