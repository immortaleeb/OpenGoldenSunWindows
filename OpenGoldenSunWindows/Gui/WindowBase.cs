using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Utils;
using Microsoft.Xna.Framework.Content;

namespace OpenGoldenSunWindows.Gui
{
    public abstract class WindowBase : GuiItemCollection, Window
    {
        public virtual int X { get; }
        public virtual int Y { get; }
        public virtual int Width { get; }
        public virtual int Height { get; }

        Color shadeColor = Color.Black;
        Color variantDifference = new Color(0, 8, 16);
        Color darkBorderColor = new Color (80, 80, 80);
        Color lightBorderColor = new Color (248, 248, 248);
        Color grayBorderColor = new Color (160, 160, 160);

        public WindowBase (int x, int y, int width, int height)
        {
            X = x;
            Y = y;
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

        private void DrawOutsideBorder(SpriteBatch spriteBatch)
        {
            // Upper border
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(X + 2, Y), Width - 4, darkBorderColor);
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(X + 2, Y + 1), Width - 4, lightBorderColor);
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(X + 2, Y + 2), Width - 5, grayBorderColor);

            // Upper left corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + 1, Y + 1), darkBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + 1, Y), shadeColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X, Y + 1), shadeColor);

            // Upper right corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + Width - 2, Y + 1), darkBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + Width - 2, Y), shadeColor);

            // Lower border
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(X + 3, Y + Height - 4), Width - 4, darkBorderColor);
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(X + 2, Y + Height - 3), Width - 5, lightBorderColor);
            GraphicsHelper.DrawHorizontalLine (spriteBatch, new Point(X + 2, Y + Height - 2), Width - 4, grayBorderColor);

            // Left border
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X, Y + 2), Height - 3, darkBorderColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + 1, Y + 2), Height - 4, lightBorderColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + 2, Y + 2), Height - 5, grayBorderColor);

            // Bottom left corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + 1, Y + Height - 3), grayBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + 1, Y + Height - 2), darkBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X, Y + Height - 2), shadeColor);

            // Right border
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + Width - 4, Y + 3), Height - 6, darkBorderColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + Width - 3, Y + 2), Height - 5, lightBorderColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + Width - 2, Y + 2), Height - 3, grayBorderColor);

            // Bottom right corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + Width - 3, Y + Height - 3), grayBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + Width - 2, Y + Height - 2), darkBorderColor);

            // Border shadows
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(X + 1, Y + Height - 1), Width - 2, shadeColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + Width - 1, Y + 1), Height - 2, shadeColor);
        }

        private void DrawInsideDetails(SpriteBatch spriteBatch)
        {
            // Color variants
            Color lightVariant1 = addColors(WindowManager.Color, variantDifference);
            Color lightVariant2 = addColors(lightVariant1, variantDifference);
            Color lightVariant3 = addColors(lightVariant2, variantDifference);

            Color darkVariant1 = substrColors(WindowManager.Color, variantDifference);
            Color darkVariant2 = substrColors(darkVariant1, variantDifference);
            Color darkVariant3 = substrColors(darkVariant2, variantDifference);

            // Top left corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + 3, Y + 3), darkBorderColor);
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + 4, Y + 4), shadeColor);

            // Top right corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + Width - 5, Y + 4), shadeColor);

            // Bottom left corner
            GraphicsHelper.SetPixel(spriteBatch, new Vector2(X + 4, Y + Height - 5), shadeColor);

            // Bottom right corner
            GraphicsHelper.SetPixel (spriteBatch, new Vector2 (X + Width - 5, Y + Height - 5), darkBorderColor);

            // Top rows
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(X + 4, Y + 3), Width - 8, shadeColor);
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(X + 5, Y + 4), Width - 10, darkVariant3);
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(X + 5, Y + 5), Width - 10, darkVariant2);
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point (X + 6, Y + 6), Width - 12, darkVariant1);

            // Left rows
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + 3, Y + 4), Height - 8, shadeColor);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + 4, Y + 5), Height - 10, darkVariant3);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + 5, Y + 5), Height - 10, darkVariant2);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + 5, Y + 5), Height - 10, darkVariant2);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + 6, Y + 6), Height - 8, darkVariant1);

            // Bottom rows
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(X + 7, Y + Height - 7), Width - 13, lightVariant1);
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(X + 6, Y + Height - 6), Width - 12, lightVariant2);
            GraphicsHelper.DrawHorizontalLine(spriteBatch, new Point(X + 5, Y + Height - 5), Width - 10, lightVariant3);

            // Right rows
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + Width - 7, Y + 7), Height - 14, lightVariant1);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + Width - 6, Y + 6), Height - 11, lightVariant2);
            GraphicsHelper.DrawVerticalLine(spriteBatch, new Point(X + Width - 5, Y + 5), Height - 10, lightVariant3);

        }

        private void DrawFrame(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // Fill the window content space with color
            GraphicsHelper.Clear (spriteBatch, new Rectangle(X + 3, Y + 3, Width - 7, Height - 7), WindowManager.Color);

            // Draw the inside border details
            DrawInsideDetails(spriteBatch);

            // Draw the border around the window content
            DrawOutsideBorder (spriteBatch);
        }

        protected virtual void DrawContent (SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw (spriteBatch, gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawFrame (spriteBatch, gameTime);
            DrawContent (spriteBatch, gameTime);
        }
    }
}

