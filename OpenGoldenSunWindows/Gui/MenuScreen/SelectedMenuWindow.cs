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
            textBox = new TextLabel (new Vector2 (0, 0));
        }

        public override void Load (ContentManager content)
        {
            base.Load (content);

            textBox.Load (content);
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime)
        {
            textBox.Text = Enum.GetName (typeof(Icons), selectedMenuItem.Item);
            textBox.Position = new Vector2 (X + 8, Y + 8);
            textBox.Draw (spriteBatch);
        }
    }
}

