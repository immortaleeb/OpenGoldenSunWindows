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

            if (WasPressed (state, Controls.LeftKey)) {
                CycleMenu (-1);
            } else if (WasPressed (state, Controls.RightKey)) {
                CycleMenu (1);
            }

            if (WasPressed (state, Controls.ConfirmKey)) {
                ScreenManager.ChangeScreen (Screens.StatusMain);
            }

            if (WasPressed (state, Controls.RightTrigger)) {
                OpenGoldenSunGame.Party.RemoveCharacter (0);
            }

            UpdateKeyboardState (state);
        }

        public override void Reset ()
        {
            // Nothing to do
        }
    }
}

