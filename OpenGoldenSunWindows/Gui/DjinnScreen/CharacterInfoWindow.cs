using System;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;

namespace OpenGoldenSunWindows.Gui.DjinnScreen
{
    public class CharacterInfoWindow : WindowBase, IObserver
    {
        private ObservableReference<Character> selectedCharacter;

        private TextLabel characterName;
        private TextLabel characterClass;
        private IntegerLabel characterLevel;

        public CharacterInfoWindow (ObservableReference<Character> selectedCharacter, int x, int y) : base (x, y, 104, 40)
        {
            this.selectedCharacter = selectedCharacter;

            Add (characterName = new TextLabel (new Vector2 (X + 8, Y + 8)));
            Add (characterClass = new TextLabel (new Vector2 (X + 8, Y + 16)));

            Add (new TextLabel("Lv", new Vector2(X + 56, Y + 8)));
            Add (characterLevel = new IntegerLabel (new Vector2 (X + 95, Y + 8)));

            Add (new IconLabel (Icons.LButton, new Vector2 (X + 8, Y + 24)));
            Add (new TextLabel(":", new Vector2(X + 23, Y + 24)));
            Add (new TextLabel("Char.", new Vector2(X + 27, Y + 24)));
            Add (new TextLabel("Status", new Vector2(X + 60, Y + 24)));

            selectedCharacter.Register (this);
            OnEvent (selectedCharacter);
        }

        public void OnEvent(IObservable source)
        {
            var character = selectedCharacter.Value;
            if (character == null)
                return;

            characterName.Text = character.Name;
            characterClass.Text = character.Clazz.Name;
            characterLevel.Number = character.Level;
        }
    }
}

