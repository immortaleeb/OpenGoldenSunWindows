using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui.MenuScreen;
using OpenGoldenSunWindows.Gui.StatusScreen;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace OpenGoldenSunWindows.Gui
{
    public enum Screens
    {
        None,
        Menu,
        Status
    }

    public class ScreenManager
    {
        private static Screens selectedScreenIndex;

        public static Screens SelectedScreenIndex { get { return selectedScreenIndex; } }
        public static Screen SelectedScreen { get { return screens [(int)selectedScreenIndex]; } }
        public static Controller SelectedController { get { return controllers [(int)selectedScreenIndex]; } }

        private static Screen[] screens;
        private static Controller[] controllers;

        static ScreenManager ()
        {
            int length = Enum.GetValues (typeof(Screens)).Length;
            screens = new Screen[length];
            controllers = new Controller[length];
        }

        private static void RegisterScreen(Screens screenIndex, Screen screen, Controller controller)
        {
            int index = (int)screenIndex;
            screens [index] = screen;
            controllers [index] = controller;
        }

        private static void InitMenuScreen(Party party)
        {
            Icons[] menuItems = { Icons.Psynergy, Icons.Djinn, Icons.Item, Icons.Status };
            SelectedItem<Icons> selectedMenuItem = new SelectedItem<Icons> (0, menuItems);
            var controller = new MenuController (selectedMenuItem);
            var menuScreen = new OpenGoldenSunWindows.Gui.MenuScreen.MenuScreen (party, selectedMenuItem);

            RegisterScreen (Screens.Menu, menuScreen, controller);
        }

        private static void InitStatusScreen(Party party)
        {
            Reference<int> cursorPosition = new Reference<int> (0);
            Reference<Character> selectedCharacter = new Reference<Character> (null);
            var controller = new StatusScreenController (cursorPosition, selectedCharacter, party);
            var statusScreen = new OpenGoldenSunWindows.Gui.StatusScreen.StatusScreen (cursorPosition, selectedCharacter, party);

            RegisterScreen (Screens.Status, statusScreen, controller);
        }

        public static void Initialize(Party party)
        {
            InitMenuScreen (party);
            InitStatusScreen (party);

            ChangeScreen (Screens.Menu);
        }

        public static void Load(ContentManager content)
        {
            foreach (Screen screen in screens)
            {
                screen?.Load (content);
            }
        }

        public static void Update(GameTime gameTime)
        {
            SelectedController.Update (gameTime);
            SelectedScreen.Update (gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            SelectedScreen.Draw(spriteBatch, gameTime);
        }

        public static void ChangeScreen(Screens newScreenIndex)
        {
            Screen oldScreen = SelectedScreen;
            Screen newScreen = screens [(int)newScreenIndex];
            Controller newController = controllers [(int)newScreenIndex];

            oldScreen?.SetVisible (false);
            newController?.Reset ();
            newScreen?.SetVisible (true);

            selectedScreenIndex = newScreenIndex;
        }
    }
}

