using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class PlayerWindow : WindowBase
    {
        Party party;
        Reference<int> selectedPlayer;
        const int spacing = 25;

        public PlayerWindow (Party party, Reference<int> selectedPlayer, int x, int y, int width, int height) : base(x, y, width, height)
        {
            this.party = party;
            this.selectedPlayer = selectedPlayer;
        }

        private bool IsPlayerSelected(int i)
        {
            return selectedPlayer.Value == i;
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < party.Characters.Count; i++) {
                var character = party.Characters [i];
                int yOffset = IsPlayerSelected (i) ? -4 : 0;

                CharacterRenderer.GetCharacterTexture (character).Draw (spriteBatch, new Vector2 (X - 1 + i * spacing, Y + yOffset));

                if (IsPlayerSelected(i)) {
                    IconRenderer.DrawCursor (spriteBatch, new Vector2 (X - 1 + i * spacing, Y + 23), Color.White);
                }
            }
        }
    }
}

