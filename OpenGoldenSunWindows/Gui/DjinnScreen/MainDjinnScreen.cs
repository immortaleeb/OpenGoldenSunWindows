using System;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;

namespace OpenGoldenSunWindows.Gui.DjinnScreen
{
    public class MainDjinnScreen : ScreenBase
    {
        public MainDjinnScreen (Party party, ObservableReference<Character> selectedCharacter, ObservableReference<Djinni> selectedDjinni)
        {
            Add (new CharacterInfoWindow (selectedCharacter, 0, 0));
            Add (new DjinniInfoWindow (selectedCharacter, selectedDjinni, 104, 0));
            Add (new DjinnListWindow (party, selectedCharacter, selectedDjinni, 0, 40));
        }
    }
}

