using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Utils;
using Microsoft.Xna.Framework.Content;

namespace OpenGoldenSunWindows.Gui.MenuScreen
{
    public class SelectedMenuWindow : WindowBase, IObserver
    {
        SelectedItem<Icons> selectedMenuItem;
        TextLabel textBox;

        public SelectedMenuWindow (SelectedItem<Icons> selectedMenuItem) : base(144, 136, 72, 24)
        {
            this.selectedMenuItem = selectedMenuItem;
            selectedMenuItem.Register (this);

            Add (textBox = new TextLabel (new Vector2 (X + 8, Y + 8)));

            // Force a text change
            OnEvent (selectedMenuItem);
        }

        public void OnEvent (IObservable source)
        {
            textBox.Text = Enum.GetName (typeof(Icons), selectedMenuItem.Item);
        }
    }
}

