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
        private DjinniLabel[,] djinnLabels;

        public DjinnListWindow (Party party, ObservableReference<Character> selectedCharacter, ObservableReference<Djinni> selectedDjinni, int x, int y) : base(x, y, 240, 120)
        {
            this.party = party;
            this.selectedCharacter = selectedCharacter;
            this.selectedDjinni = selectedDjinni;

            GenerateCharacterAnimations ();
            GenerateDjinnNames ();

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
                characterAnimations [i].SetVisible (false);
                Add (characterAnimations [i]);
            }
        }

        private void GenerateDjinnNames ()
        {
            djinnLabels = new DjinniLabel[4, 9];

            for (int i = 0; i < djinnLabels.GetLength(0); i++) {
                for (int j = 0; j < djinnLabels.GetLength (1); j++) {
                    djinnLabels [i, j] = new DjinniLabel (new Vector2 (X + 17 + i * 56, Y + 24 + j * 8));
                    djinnLabels [i, j].SetVisible (false);
                    Add (djinnLabels [i, j]);
                }
            }
        }

        private void UpdateCharacters ()
        {
            var characters = party.Characters;
            if (characters == null)
                return;

            foreach (var label in characterAnimations) {
                label.SetVisible (false);
            }
            
            for (int i = 0; i < characters.Count; i++) {
                var label = characterAnimations [i];
                var animation = label.Animation as WalkingCharacterAnimation;
                animation.Character = characters [i];
                label.SetVisible (true);
            }
        }

        private void UpdateDjinn ()
        {
            var characters = party.Characters;
            if (characters == null)
                return;

            foreach (var label in djinnLabels) {
                label.SetVisible (false);
            }

            for (int i = 0; i < characters.Count; i++) {
                var djinn = characters [i].Djinn;
                if (djinn == null)
                    continue;

                for (int j = 0; j < djinn.Count; j++) {
                    var label = djinnLabels [i, j];
                    label.Djinni = djinn [j];
                    label.SetVisible (true);
                }
            }
        }

        public void OnEvent (IObservable source)
        {
            UpdateCharacters ();
            UpdateDjinn ();
        }

        protected override void OnShow ()
        {
            UpdateCharacters ();
            UpdateDjinn ();
        }
    }
}

