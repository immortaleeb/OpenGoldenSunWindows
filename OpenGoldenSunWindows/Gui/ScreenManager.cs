using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui.MenuScreen;
using OpenGoldenSunWindows.Gui.StatusScreen;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using OpenGoldenSunWindows.Gui.DjinnScreen;

namespace OpenGoldenSunWindows.Gui
{
    public enum Screens
    {
        None,
        Menu,

        StatusMain,
        StatusStatDetails,

        DjinnMain
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
            // Models
            ObservableReference<int> characterCursorPosition = new ObservableReference<int> (0);
            ObservableReference<Character> selectedCharacter = new ObservableReference<Character> (party.Characters[0]);
            ObservableReference<int> statCursorPosition = new ObservableReference<int> (-1);

            // Controllers
            var mainController = new StatusScreen.MainScreen.MainController (characterCursorPosition, selectedCharacter, party);
            var detailsController = new StatusScreen.StatDetailsScreen.DetailsController (
                party, characterCursorPosition, selectedCharacter, statCursorPosition, 
                StatusScreen.StatDetailsScreen.StatDetailsWindow.SelectableAreas.Length - 1);

            // Screens
            var mainStatusScreen = new StatusScreen.MainScreen.MainStatusScreen (characterCursorPosition, selectedCharacter, party);
            var detailsScreen = new StatusScreen.StatDetailsScreen.DetailsScreen (selectedCharacter, statCursorPosition);

            RegisterScreen (Screens.StatusMain, mainStatusScreen, mainController);
            RegisterScreen (Screens.StatusStatDetails, detailsScreen, detailsController);
        }

        private static void InitDjinnScreen(Party party)
        {
            // Models
            var firstCharacter = party.Characters[0];
            var firstDjinni = firstCharacter.Djinn.Count > 0 ? firstCharacter.Djinn [0] : null;

            ObservableReference<Character> selectedCharacter = new ObservableReference<Character> (firstCharacter);
            ObservableReference<Djinni> selectedDjinni = new ObservableReference<Djinni> (firstDjinni);

            // Controllers
            var mainController = new MainDjinnScreenController();

            // Screens
            var mainDjinnScreen = new MainDjinnScreen(party, selectedCharacter, selectedDjinni);

            RegisterScreen (Screens.DjinnMain, mainDjinnScreen, mainController);
        }

        public static void Initialize(Party party)
        {
            InitMenuScreen (party);
            InitStatusScreen (party);
            InitDjinnScreen (party);

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
            SelectedController?.Update (gameTime);
            SelectedScreen?.Update (gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            SelectedScreen?.Draw(spriteBatch, gameTime);
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

