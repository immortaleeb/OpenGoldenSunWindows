using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui.MenuScreen;
using OpenGoldenSunWindows.Gui.StatusScreen;
using Microsoft.Xna.Framework;

namespace OpenGoldenSunWindows.Gui
{
    public class ScreenManager
    {
        public static Screen SelectedScreen;

        public static OpenGoldenSunWindows.Gui.MenuScreen.MenuScreen menuScreen;
        public static OpenGoldenSunWindows.Gui.StatusScreen.StatusScreen statusScreen;

        static ScreenManager ()
        {
        }

        private static void InitMenuScreen()
        {
            Icons[] menuItems = { Icons.Psynergy, Icons.Djinn, Icons.Item, Icons.Status };
            SelectedItem<Icons> selectedMenuItem = new SelectedItem<Icons> (0, menuItems);
            MenuController controller = new MenuController (selectedMenuItem);
            menuScreen = new OpenGoldenSunWindows.Gui.MenuScreen.MenuScreen (selectedMenuItem, controller);
        }

        private static void InitStatusScreen(Party party)
        {
            Reference<int> cursorPosition = new Reference<int> (0);
            Reference<Character> selectedCharacter = new Reference<Character> (null);
            StatusScreenController controller = new StatusScreenController (cursorPosition, selectedCharacter, party);
            statusScreen = new OpenGoldenSunWindows.Gui.StatusScreen.StatusScreen (controller, cursorPosition, selectedCharacter, party);
        }

        public static void Initialize(Party party)
        {
            InitMenuScreen ();
            InitStatusScreen (party);
            
            SelectedScreen = menuScreen;
        }

        public static void Load(ContentManager content)
        {
            menuScreen.Load (content);
            statusScreen.Load (content);
        }

        public static void Update(GameTime gameTime)
        {
            SelectedScreen.Update (gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            SelectedScreen.Draw(spriteBatch, gameTime);
        }
    }
}

