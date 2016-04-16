using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class InfoWindow : WindowBase
    {
        public InfoWindow (int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime)
        {
            // Button image placeholders
            Utils.IconRenderer.DrawLButton(spriteBatch, new Vector2(X + 8, Y + 8), Color.White);
            Utils.IconRenderer.DrawRButton(spriteBatch, new Vector2(X + 27, Y + 8), Color.White);
            Utils.IconRenderer.DrawAButton(spriteBatch, new Vector2(X + 9, Y + 16), Color.White);

            FontRenderer.DrawString ("-", spriteBatch, new Point(X + 22, Y + 8));

            FontRenderer.DrawString (":", spriteBatch, new Point(X + 42, Y + 8));
            FontRenderer.DrawString ("Rearrange", spriteBatch, new Point(X + 46, Y + 8));

            FontRenderer.DrawString (":", spriteBatch, new Point(X + 19, Y + 16));
            FontRenderer.DrawString ("Details", spriteBatch, new Point(X + 23, Y + 16));
        }
    }
}

