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
        public StatusScreen (StatusScreenController controller, Reference<int> cursorPosition, Reference<Character> selectedCharacter, Party party) : base(controller)
        {
            Add (new PlayerWindow (party, cursorPosition, 0, 0, 104, 40));
            Add (new InfoWindow (104, 0, 136, 40));
            Add (new StatusWindow (selectedCharacter, 0, 40, 240, 120));
        }
    }
}

