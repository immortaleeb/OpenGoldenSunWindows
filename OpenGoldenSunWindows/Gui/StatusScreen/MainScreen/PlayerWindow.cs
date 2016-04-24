using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Animations;

namespace OpenGoldenSunWindows.Gui.StatusScreen.MainScreen
{
    public class PlayerWindow : WindowBase, IObserver
    {
        Party party;
        ObservableReference<int> selectedPlayer;
        const int spacing = 25;

        int previousSelectedPlayer = -1;

        WalkingCharacterAnimation[] characterSpots = new WalkingCharacterAnimation[4];
        CursorAnimation cursor;

        public PlayerWindow (Party party, ObservableReference<int> selectedPlayer, int x, int y) : base(x, y, 104, 40)
        {
            this.party = party;
            this.selectedPlayer = selectedPlayer;
            party.Register (this);
            selectedPlayer.Register (this);

            for (int i = 0; i < characterSpots.Length; i++) {
                Add (characterSpots [i] = new WalkingCharacterAnimation (new Vector2 (X - 1 + i * spacing, Y)));
            }

            Add (cursor = new CursorAnimation (new Vector2 (X - 1, Y + 23)));

            // Force characters in the right spot
            OnEvent (selectedPlayer);
        }

        private bool IsPlayerSelected(int i)
        {
            return selectedPlayer.Value == i;
        }

        private bool WasPlayerSelected (int i)
        {
            return previousSelectedPlayer == i;
        }

        public void OnEvent (IObservable source)
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

