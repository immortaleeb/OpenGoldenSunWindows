using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class InfoWindow : WindowBase
    {
        public InfoWindow (int width, int height) : base(width, height)
        {
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime, int x, int y)
        {
            // Button image placeholders
            Utils.IconRenderer.DrawLButton(spriteBatch, new Vector2(x + 8, y + 8), Color.White);
            Utils.IconRenderer.DrawRButton(spriteBatch, new Vector2(x + 27, y + 8), Color.White);
            Utils.IconRenderer.DrawAButton(spriteBatch, new Vector2(x + 9, y + 16), Color.White);

            FontRenderer.DrawString ("-", spriteBatch, new Point(x + 22, y + 8));

            FontRenderer.DrawString (":", spriteBatch, new Point(x + 42, y + 8));
            FontRenderer.DrawString ("Rearrange", spriteBatch, new Point(x + 46, y + 8));

            FontRenderer.DrawString (":", spriteBatch, new Point(x + 19, y + 16));
            FontRenderer.DrawString ("Details", spriteBatch, new Point(x + 23, y + 16));
        }
    }
}

