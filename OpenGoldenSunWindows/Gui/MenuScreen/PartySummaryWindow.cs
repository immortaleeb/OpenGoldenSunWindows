using System;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Characters;

namespace OpenGoldenSunWindows.Gui.MenuScreen
{
    public class PartySummaryWindow : WindowBase
    {
        private Party party;
        private CharacterHpPpPane[] panes = new CharacterHpPpPane[4];

        public PartySummaryWindow (Party party) : base (0, 0, 240, 39)
        {
            this.party = party;

            for (int i = 0; i < panes.Length; i++) {
                Add (panes[i] = new CharacterHpPpPane (new Vector2 (X + 8 + 48 * i, Y + 8)));
            }
        }

        public override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            var characters = this.party.Characters;
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

