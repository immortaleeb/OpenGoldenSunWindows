using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class StatusScreenController : Controller
    {
        // A random selection of colors
        Color[] colors = { 
            WindowManager.DefaultColor, Color.Aqua, Color.DarkGray, Color.Honeydew, 
            Color.HotPink, Color.MintCream, Color.CornflowerBlue, Color.Chartreuse, 
            Color.BurlyWood, Color.Gold, Color.Gainsboro, Color.Teal, Color.Wheat };

        WindowManager windowManager;
        int currentColor;

        Reference<int> cursorPosition;
        Reference<Character> selectedCharacter;
        Party party;
        KeyboardState oldState;

        public StatusScreenController (WindowManager windowManager, Reference<int> cursorPosition, Reference<Character> selectedCharacter, Party party)
        {
            this.windowManager = windowManager;
            this.currentColor = 0;
            this.cursorPosition = cursorPosition;
            this.selectedCharacter = selectedCharacter;
            this.party = party;
            this.oldState = Keyboard.GetState ();

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
            windowManager.Color = colors [currentColor];
        }

        private bool WasPressed(KeyboardState state, Keys key)
        {
            return state.IsKeyUp (key) && !oldState.IsKeyUp (key);
        }

        public void Update(GameTime gameTime)
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

            oldState = state;
        }
    }
}

