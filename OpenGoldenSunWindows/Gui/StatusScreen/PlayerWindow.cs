using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Animations;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class PlayerWindow : WindowBase
    {
        Party party;
        Reference<int> selectedPlayer;
        const int spacing = 25;

        int previousSelectedPlayer = -1;

        WalkingCharacterAnimation[] characterSpots = new WalkingCharacterAnimation[4];
        IconLabel cursor;

        public PlayerWindow (Party party, Reference<int> selectedPlayer, int x, int y, int width, int height) : base(x, y, width, height)
        {
            this.party = party;
            this.selectedPlayer = selectedPlayer;

            for (int i = 0; i < characterSpots.Length; i++) {
                Add (characterSpots [i] = new WalkingCharacterAnimation (new Vector2 (X - 1 + i * spacing, Y)));
            }

            Add (cursor = new IconLabel (Icons.Cursor, new Vector2 (X - 1, Y + 23)));
        }

        private bool IsPlayerSelected(int i)
        {
            return selectedPlayer.Value == i;
        }

        private bool WasPlayerSelected (int i)
        {
            return previousSelectedPlayer == i;
        }

        public override void Update (GameTime gameTime)
        {
            for (int i = 0; i < party.Characters.Count; i++) {
                var character = party.Characters [i];

                // Set the character in that spot
                characterSpots [i].Character = character;

                // Offset selected player
                if (IsPlayerSelected (i) && !WasPlayerSelected (i)) {
                    Vector2 position = characterSpots [i].Position;
                    position.Y -= 4;
                    characterSpots [i].Position = position;
                } else if (WasPlayerSelected (i) && !IsPlayerSelected (i)) {
                    Vector2 position = characterSpots [i].Position;
                    position.Y += 4;
                    characterSpots [i].Position = position;
                }

                if (IsPlayerSelected (i)) {
                    cursor.Position = new Vector2 (X - 1 + i * spacing, Y + 23);
                }
            }

            previousSelectedPlayer = selectedPlayer.Value;

            base.Update (gameTime);
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < party.Characters.Count; i++) {
                characterSpots [i].Draw (spriteBatch, gameTime);
            }

            cursor.Draw (spriteBatch, gameTime);
        }
    }
}

