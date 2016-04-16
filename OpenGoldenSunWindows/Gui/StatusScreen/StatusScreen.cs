using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class StatusScreen : ScreenBase
    {
        Window playerWindow;
        Window infoWindow;
        Window statusWindow;

        public StatusScreen (StatusScreenController controller, Reference<int> cursorPosition, Reference<Character> selectedCharacter, Party party) : base(controller)
        {
            playerWindow = new PlayerWindow (party, cursorPosition, 0, 0, 104, 40);
            infoWindow = new InfoWindow (104, 0, 136, 40);
            statusWindow = new StatusWindow (selectedCharacter, 0, 40, 240, 120);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update (gameTime);
            playerWindow.Update (gameTime);
            infoWindow.Update (gameTime);
            statusWindow.Update (gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            playerWindow.Draw (spriteBatch, gameTime);
            infoWindow.Draw (spriteBatch, gameTime);
            statusWindow.Draw (spriteBatch, gameTime);
        }
    }
}

