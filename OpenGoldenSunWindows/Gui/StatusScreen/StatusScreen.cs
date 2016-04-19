using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class StatusScreen : ScreenBase
    {
        public StatusScreen (ObservableReference<int> cursorPosition, ObservableReference<Character> selectedCharacter, Party party)
        {
            Add (new PlayerWindow (party, cursorPosition, 0, 0, 104, 40));
            Add (new InfoWindow (104, 0, 136, 40));
            Add (new StatusWindow (selectedCharacter, 0, 40, 240, 120));
        }
    }
}

