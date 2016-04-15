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

        public PlayerWindow (Party party, Reference<int> selectedPlayer, int width, int height) : base(width, height)
        {
            this.party = party;
            this.selectedPlayer = selectedPlayer;
        }

        private bool IsPlayerSelected(int i)
        {
            return selectedPlayer.Value == i;
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime, int x, int y)
        {
            for (int i = 0; i < party.Characters.Count; i++) {
                var character = party.Characters [i];
                int yOffset = IsPlayerSelected (i) ? -4 : 0;

                CharacterRenderer.GetCharacterTexture (character).Draw (spriteBatch, new Vector2 (x - 1 + i * spacing, y + yOffset));

                if (IsPlayerSelected(i)) {
                    IconRenderer.DrawCursor (spriteBatch, new Vector2 (x - 1 + i * spacing, y + 23), Color.White);
                }
            }
        }
    }
}

