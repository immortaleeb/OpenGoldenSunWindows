using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen.MainScreen
{
    public class MainStatusScreen : ScreenBase
    {
        public MainStatusScreen (ObservableReference<int> cursorPosition, ObservableReference<Character> selectedCharacter, Party party)
        {
            Add (new PlayerWindow (party, cursorPosition, 0, 0));
            Add (new InfoWindow (104, 0));
            Add (new StatusWindow (selectedCharacter, 0, 40));
        }
    }
}

