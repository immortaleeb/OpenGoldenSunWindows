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
            Add (new TextLabel ("-", new Vector2 (X + 22, Y + 8)));
            Add (new TextLabel (":", new Vector2 (x + 42, y + 8)));
            Add (new TextLabel ("Rearrange", new Vector2 (x + 46, y + 8)));
            Add (new TextLabel (":", new Vector2 (x + 19, y + 16)));
            Add (new TextLabel ("Details", new Vector2 (x + 23, y + 16)));
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime)
        {
            // Button image placeholders
            Utils.IconRenderer.DrawLButton(spriteBatch, new Vector2(X + 8, Y + 8), Color.White);
            Utils.IconRenderer.DrawRButton(spriteBatch, new Vector2(X + 27, Y + 8), Color.White);
            Utils.IconRenderer.DrawAButton(spriteBatch, new Vector2(X + 9, Y + 16), Color.White);

            base.DrawContent (spriteBatch, gameTime);
        }
    }
}

