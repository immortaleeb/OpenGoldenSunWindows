using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Utils;
using Microsoft.Xna.Framework.Content;

namespace OpenGoldenSunWindows.Gui.MenuScreen
{
    public class SelectedMenuWindow : WindowBase
    {
        SelectedItem<Icons> selectedMenuItem;

        public SelectedMenuWindow (SelectedItem<Icons> selectedMenuItem) : base(144, 136, 72, 24)
        {
            this.selectedMenuItem = selectedMenuItem;
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime)
        {
            var name = Enum.GetName (typeof(Icons), selectedMenuItem.Item);
            FontRenderer.DrawString (name, spriteBatch, new Point (X + 8, Y + 8));
        }
    }
}

