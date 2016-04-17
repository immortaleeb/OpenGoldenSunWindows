using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Animations;
using OpenGoldenSunWindows.Utils;
using System.Collections.Generic;

namespace OpenGoldenSunWindows.Gui.MenuScreen
{
    public class MenuScreen : ScreenBase
    {
        public MenuScreen (SelectedItem<Icons> selectedMenuItem, MenuController controller) : base(controller)
        {
            Add (new SelectedMenuWindow (selectedMenuItem));

            Add (new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Psynergy, new Vector2 (48, 136)));
            Add (new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Djinn, new Vector2 (72, 136)));
            Add (new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Item, new Vector2 (96, 136)));
            Add (new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Status, new Vector2 (120, 136)));
        }
    }
}

