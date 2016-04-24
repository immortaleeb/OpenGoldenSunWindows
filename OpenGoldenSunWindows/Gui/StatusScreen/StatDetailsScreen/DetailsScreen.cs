using System;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;

namespace OpenGoldenSunWindows.Gui.StatusScreen.StatDetailsScreen
{
    public class DetailsScreen : ScreenBase
    {
        public DetailsScreen (ObservableReference<Character> selectedCharacter, ObservableReference<int> cursorPosition)
        {
            Add (new StatExplanationWindow ());
            Add (new StatDetailsWindow (selectedCharacter, cursorPosition, 0, 40));
        }
    }
}

