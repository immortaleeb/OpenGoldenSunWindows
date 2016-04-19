using System;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Characters;

namespace OpenGoldenSunWindows.Gui.MenuScreen
{
    public class PartySummaryWindow : WindowBase, IObserver
    {
        private Party party;
        private CharacterHpPpPane[] panes = new CharacterHpPpPane[4];

        private int x;
        private int width;

        public override int X { get { return x; } }
        public override int Width { get { return width; } }

        public PartySummaryWindow (Party party) : base (0, 0, 0, 39)
        {
            this.party = party;

            InitializePanes ();
            SetWindowProperties ();

            party.Register (this);
        }

        public void OnEvent (IObservable source)
        {
            // Party changed, change window position and size
            this.SetWindowProperties ();
        }

        private void InitializePanes ()
        {
            for (int i = 0; i < panes.Length; i++) {
                Add (panes [i] = new CharacterHpPpPane (new Vector2 (X, Y)));
            }
        }

        private void SetWindowProperties ()
        {
            var characters = this.party.Characters;
            var count = characters.Count;

            // Set window position and size
            // FIXME really ugly hack
            this.width = count * 48 + count + 5;
            this.x = 240 - this.width;

            for (int i = 0; i < panes.Length; i++) {
                Remove (panes [i]);
                Add (panes [i] = new CharacterHpPpPane (new Vector2 (X + 8 + 48 * i, Y + 8)));
            }

            // Change the panes' content
            for (int i = 0; i < panes.Length; i++) {
                var pane = panes [i];
                if (i < characters.Count) {
                    pane.SetVisible (true);
                    pane.Character = characters [i];
                } else {
                    pane.SetVisible (false);
                    pane.Character = null;
                }
            }
        }
    }
}

