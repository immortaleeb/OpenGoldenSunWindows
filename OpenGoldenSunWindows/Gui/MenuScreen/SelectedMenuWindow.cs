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
        TextLabel textBox;

        public SelectedMenuWindow (SelectedItem<Icons> selectedMenuItem) : base(144, 136, 72, 24)
        {
            this.selectedMenuItem = selectedMenuItem;

            Add (textBox = new TextLabel (new Vector2 (X + 8, Y + 8)));
        }

        public override void Update (GameTime gameTime)
        {
            textBox.Text = Enum.GetName (typeof(Icons), selectedMenuItem.Item);

            base.Update (gameTime);
        }
    }
}

