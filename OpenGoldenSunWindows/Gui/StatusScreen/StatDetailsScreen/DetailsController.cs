using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;

namespace OpenGoldenSunWindows.Gui.StatusScreen.StatDetailsScreen
{
    public class DetailsController : ControllerBase
    {
        private Party party;
        private ObservableReference<int> characterCursorPosition;
        private ObservableReference<Character> selectedCharacter;
        private ObservableReference<int> cursorPosition;
        private int menuSize;

        public DetailsController (Party party, ObservableReference<int> characterCursorPosition, ObservableReference<Character> selectedCharacter, ObservableReference<int> statCursorPosition, int menuSize)
        {
            this.party = party;
            this.characterCursorPosition = characterCursorPosition;
            this.selectedCharacter = selectedCharacter;
            this.cursorPosition = statCursorPosition;
            this.menuSize = menuSize;
        }

        private void MoveUpDown (int offset)
        {
            // -1 means we selected the character's status
            if (this.cursorPosition.Value != -1) {
                CycleStatMenu (offset);
            }
        }

        private void MoveLeftRight ()
        {
            this.cursorPosition.Value = (this.cursorPosition.Value == -1) ? 0 : -1;
        }

        private void CycleStatMenu (int offset)
        {
            this.cursorPosition.Value = (this.cursorPosition.Value + menuSize + offset) % menuSize;
        }

        private void ChangeCharacter (int offset)
        {
            var characters = party.Characters;
            var count = characters.Count;
            var index = this.characterCursorPosition.Value;
            index = (index + count + offset) % count;

            this.characterCursorPosition.Value = index;
            this.selectedCharacter.Value = characters [index];
        }

        public override void Update (GameTime gametime)
        {
            KeyboardState state = Keyboard.GetState ();

            if (WasPressed (state, Controls.CancelKey)) {
                ScreenManager.ChangeScreen (Screens.StatusMain);
            }

            Keys[] leftright = { Controls.LeftKey, Controls.RightKey };
            if (WasAnyPressed (state, leftright)) {
                MoveLeftRight ();
            } else if (WasPressed (state, Controls.UpKey)) {
                MoveUpDown (-1);
            } else if (WasPressed (state, Controls.DownKey)) {
                MoveUpDown (1);
            }

            if (WasPressed (state, Controls.LeftTrigger)) {
                ChangeCharacter (-1);
            } else if (WasPressed (state, Controls.RightTrigger)) {
                ChangeCharacter (1);
            }

            UpdateKeyboardState (state);
        }

        public override void Reset ()
        {
            this.cursorPosition.Value = -1;
        }
    }
}

