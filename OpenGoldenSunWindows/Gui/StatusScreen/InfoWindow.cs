using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class InfoWindow : WindowBase
    {
        TextLabel dashTextBox;
        TextLabel colinTextBox1;
        TextLabel colinTextBox2;
        TextLabel rearrangeTextBox;
        TextLabel detailsTextBox;

        public InfoWindow (int x, int y, int width, int height) : base(x, y, width, height)
        {
            dashTextBox = new TextLabel ("-", new Vector2 (X + 22, Y + 8));

            colinTextBox1 = new TextLabel (":", new Vector2 (x + 42, y + 8));
            rearrangeTextBox = new TextLabel ("Rearrange", new Vector2 (x + 46, y + 8));

            colinTextBox2 = new TextLabel (":", new Vector2 (x + 19, y + 16));
            detailsTextBox = new TextLabel ("Details", new Vector2 (x + 23, y + 16));
        }

        public override void Load (Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.Load (content);

            dashTextBox.Load (content);
            colinTextBox1.Load (content);
            colinTextBox2.Load (content);
            rearrangeTextBox.Load (content);
            detailsTextBox.Load (content);
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime)
        {
            // Button image placeholders
            Utils.IconRenderer.DrawLButton(spriteBatch, new Vector2(X + 8, Y + 8), Color.White);
            Utils.IconRenderer.DrawRButton(spriteBatch, new Vector2(X + 27, Y + 8), Color.White);
            Utils.IconRenderer.DrawAButton(spriteBatch, new Vector2(X + 9, Y + 16), Color.White);

            dashTextBox.Draw (spriteBatch);
            colinTextBox1.Draw (spriteBatch);
            colinTextBox2.Draw (spriteBatch);
            rearrangeTextBox.Draw (spriteBatch);
            detailsTextBox.Draw (spriteBatch);
        }
    }
}

