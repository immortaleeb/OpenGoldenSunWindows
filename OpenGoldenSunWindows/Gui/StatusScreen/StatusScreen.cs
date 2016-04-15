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

        public StatusScreen (StatusScreenController controller, WindowManager windowManager, Reference<int> cursorPosition, Reference<Character> selectedCharacter, Party party) : base(controller)
        {
            playerWindow = new PlayerWindow (windowManager, party, cursorPosition, 104, 40);
            infoWindow = new InfoWindow (windowManager, 136, 40);
            statusWindow = new StatusWindow (windowManager, selectedCharacter, 240, 120);
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
            playerWindow.Draw (spriteBatch, gameTime, 0, 0);
            infoWindow.Draw (spriteBatch, gameTime, 104, 0);
            statusWindow.Draw (spriteBatch, gameTime, 0, 40);
        }
    }
}

