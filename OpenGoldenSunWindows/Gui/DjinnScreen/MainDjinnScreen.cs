using System;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;

namespace OpenGoldenSunWindows.Gui.DjinnScreen
{
    public class MainDjinnScreen : ScreenBase
    {
        public MainDjinnScreen (ObservableReference<Character> selectedCharacter, ObservableReference<Djinni> selectedDjinni)
        {
            Add (new CharacterInfoWindow (selectedCharacter, 0, 0));
            Add (new DjinniInfoWindow (selectedCharacter, selectedDjinni, 104, 0));
        }
    }
}

