using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class StatusScreenController : ControllerBase
    {
        // A random selection of colors
        Color[] colors = { 
            WindowManager.DefaultColor, Color.Aqua, Color.DarkGray, Color.Honeydew, 
            Color.HotPink, Color.MintCream, Color.CornflowerBlue, Color.Chartreuse, 
            Color.BurlyWood, Color.Gold, Color.Gainsboro, Color.Teal, Color.Wheat };
        int currentColor;

        Reference<int> cursorPosition;
        Reference<Character> selectedCharacter;
        Party party;

        public StatusScreenController (Reference<int> cursorPosition, Reference<Character> selectedCharacter, Party party) : base()
        {
            this.currentColor = 0;
            this.cursorPosition = cursorPosition;
            this.selectedCharacter = selectedCharacter;
            this.party = party;

            // Sync cursor and selected character the first time
            selectedCharacter.Value = party.Characters[cursorPosition.Value];
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

            if (WasPressed(state, Keys.Left)) {
                MoveCursor (-1);
            } else if (WasPressed(state, Keys.Right)) {
                MoveCursor (1);
            }

            if (WasPressed (state, Keys.Up)) {
                CycleColor (1);
            } else if (WasPressed (state, Keys.Down)) {
                CycleColor (-1);
            }

            if (WasPressed (state, Keys.A)) {
                ScreenManager.ChangeScreen (Screens.Menu);
            }

            UpdateKeyboardState (state);
        }
    }
}

