using System;
using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Animations;
using Microsoft.Xna.Framework;

namespace OpenGoldenSunWindows.Gui.DjinnScreen
{
    public class DjinnListWindow : WindowBase, IObserver
    {
        private Party party;
        private ObservableReference<Character> selectedCharacter;
        private ObservableReference<Djinni> selectedDjinni;

        private AnimationLabel[] characterAnimations;
        private DjinnList[] djinnLists;

        public DjinnListWindow (Party party, ObservableReference<Character> selectedCharacter, ObservableReference<Djinni> selectedDjinni, int x, int y) : base(x, y, 240, 120)
        {
            this.party = party;
            this.selectedCharacter = selectedCharacter;
            this.selectedDjinni = selectedDjinni;

            GenerateCharacterAnimations ();
            GenerateDjinnLists ();

            party.Register (this);
        }

        public override void Load (Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.Load (content);
            OnEvent (party);
        }

        private void GenerateCharacterAnimations ()
        {
            characterAnimations = new AnimationLabel[4];

            for (int i = 0; i < characterAnimations.Length; i++) {
                characterAnimations [i] = new AnimationLabel (new WalkingCharacterAnimation (new Vector2 (X + 15 + 56 * i + Math.Min(1, i), Y - 9)));
                Add (characterAnimations [i]);
            }
        }

        private void GenerateDjinnLists ()
        {
            djinnLists = new DjinnList[4];
            for (int i = 0; i < djinnLists.Length; i++) {
                Add (djinnLists [i] = new DjinnList (new Vector2 (X + 17 + i * 56, Y + 24), 9));
            }
        }

        private void UpdateCharacters ()
        {
            var characters = party.Characters;
            if (characters == null)
                return;

            for (int i = 0; i < characters.Count; i++) {
                var label = characterAnimations [i];
                var animation = label.Animation as WalkingCharacterAnimation;
                animation.Character = characters [i];
            }
        }

        private void UpdateDjinn ()
        {
            var characters = party.Characters;
            if (characters == null)
                return;
            
            for (int i = 0; i < characters.Count; i++) {
                var character = characters [i];
                var djinn = character.Djinn;
                if (djinn == null)
                    continue;

                djinnLists [i].List = djinn;
            }
        }

        public void OnEvent (IObservable source)
        {
            UpdateCharacters ();
            UpdateDjinn ();
        }

        protected override void DrawContent (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            var characters = party.Characters;
            if (characters == null)
                return;

            for (int i = 0; i < characters.Count; i++) {
                characterAnimations [i].Draw (spriteBatch, gameTime);
                djinnLists [i].Draw (spriteBatch, gameTime);
            }
        }
    }
}

