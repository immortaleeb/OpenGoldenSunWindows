using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.MenuScreen
{
    public class SelectedMenuWindow : WindowBase
    {
        SelectedItem<Icons> selectedMenuItem;

        public SelectedMenuWindow (SelectedItem<Icons> selectedMenuItem) : base(72, 24)
        {
            this.selectedMenuItem = selectedMenuItem;
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime, int x, int y)
        {
            var name = Enum.GetName (typeof(Icons), selectedMenuItem.Item);
            FontRenderer.DrawString (name, spriteBatch, new Point (x + 8, y + 8));
        }
    }
}

