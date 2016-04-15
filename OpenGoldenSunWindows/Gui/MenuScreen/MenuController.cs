using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.MenuScreen
{
    public class MenuController : ControllerBase
    {
        SelectedItem<Icons> selectedItem;

        public MenuController (SelectedItem<Icons> selectedItem) : base()
        {
            this.selectedItem = selectedItem;
            selectedItem.Index = 0;
        }

        private void CycleMenu(int offset)
        {
            Console.WriteLine ("Move {0}", offset);
            var length = selectedItem.Items.Length;
            selectedItem.Index = (selectedItem.Index + length + offset) % length;
        }

        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState ();

            if (WasPressed (state, Keys.Left)) {
                CycleMenu (-1);
            } else if (WasPressed (state, Keys.Right)) {
                CycleMenu (1);
            }

            if (WasPressed (state, Keys.A)) {
                ScreenManager.SelectedScreen = ScreenManager.statusScreen;
            }

            UpdateKeyboardState (state);
        }
    }
}

