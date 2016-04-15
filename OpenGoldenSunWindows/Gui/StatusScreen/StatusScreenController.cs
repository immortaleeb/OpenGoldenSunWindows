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
        Reference<int> cursorPosition;
        Reference<Character> selectedCharacter;
        Party party;
        KeyboardState oldState;

        public StatusScreenController (Reference<int> cursorPosition, Reference<Character> selectedCharacter, Party party)
        {
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

        public void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState ();
            if (state.IsKeyDown (Keys.Left) && !oldState.IsKeyDown(Keys.Left)) {
                MoveCursor (-1);
            } else if (state.IsKeyDown (Keys.Right) && !oldState.IsKeyDown(Keys.Right)) {
                MoveCursor (1);
            }

            oldState = state;
        }
    }
}

