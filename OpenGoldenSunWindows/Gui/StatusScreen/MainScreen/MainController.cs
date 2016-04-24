using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen.MainScreen
{
    public class MainController : ControllerBase
    {
        // A random selection of colors
        Color[] colors = { 
            WindowManager.DefaultColor, Color.Aqua, Color.DarkGray, Color.Honeydew, 
            Color.HotPink, Color.MintCream, Color.CornflowerBlue, Color.Chartreuse, 
            Color.BurlyWood, Color.Gold, Color.Gainsboro, Color.Teal, Color.Wheat };
        int currentColor;

        ObservableReference<int> cursorPosition;
        ObservableReference<Character> selectedCharacter;
        Party party;

        public MainController (ObservableReference<int> cursorPosition, ObservableReference<Character> selectedCharacter, Party party) : base()
        {
            this.currentColor = 0;
            this.cursorPosition = cursorPosition;
            this.selectedCharacter = selectedCharacter;
            this.party = party;
        }

        private void MoveCursor(int offset)
        {
            var count = party.Characters.Count;
            cursorPosition.Value = (cursorPosition.Value + count + offset) % count;

            var character = party.Characters [cursorPosition.Value];
            selectedCharacter.Value = character;
        }
            
        private void CycleColor(int offset)
        {
            var length = colors.Length;
            currentColor = (currentColor + length + offset) % length;
            WindowManager.Color = colors [currentColor];
        }


        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState ();

            if (WasPressed(state, Controls.LeftKey)) {
                MoveCursor (-1);
            } else if (WasPressed(state, Controls.RightKey)) {
                MoveCursor (1);
            }

            if (WasPressed (state, Controls.UpKey)) {
                CycleColor (1);
            } else if (WasPressed (state, Controls.DownKey)) {
                CycleColor (-1);
            }

            if (WasPressed (state, Controls.CancelKey)) {
                ScreenManager.ChangeScreen (Screens.Menu);
                ResetCharacter ();
            } else if (WasPressed (state, Controls.ConfirmKey)) {
                ScreenManager.ChangeScreen (Screens.StatusStatDetails);
            } else if (WasPressed (state, Controls.RightTrigger)) {
                party.RemoveCharacter (0);
                if (cursorPosition.Value == party.Characters.Count)
                    cursorPosition.Value--;
                selectedCharacter.Value = party.Characters [cursorPosition.Value];
            }

            UpdateKeyboardState (state);
        }

        private void ResetCharacter ()
        {
            cursorPosition.Value = 0;
            selectedCharacter.Value = party.Characters [cursorPosition.Value];
        }

        public override void Reset ()
        {
            
        }
    }
}

