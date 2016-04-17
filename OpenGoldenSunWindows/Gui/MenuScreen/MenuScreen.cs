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
        IList<MenuItemAnimation> menuItems;

        SelectedMenuWindow selectedMenuWindow;

        public MenuScreen (SelectedItem<Icons> selectedMenuItem, MenuController controller) : base(controller)
        {
            menuItems = new List<MenuItemAnimation> (4);
            menuItems.Add (new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Psynergy, new Vector2 (48, 136)));
            menuItems.Add (new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Djinn, new Vector2 (72, 136)));
            menuItems.Add (new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Item, new Vector2 (96, 136)));
            menuItems.Add (new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Status, new Vector2 (120, 136)));

            Add (selectedMenuWindow = new SelectedMenuWindow (selectedMenuItem));
        }

        public override void Load (Microsoft.Xna.Framework.Content.ContentManager content)
        {
            foreach (var item in menuItems) {
                item.Load (content);
            }

            base.Load (content);
        }

        public override void Start ()
        {
            foreach (var item in menuItems) {
                item.Play ();
            }

            base.Start ();
        }

        public override void Stop ()
        {
            foreach (var item in menuItems) {
                item.Stop ();
            }

            base.Stop ();
        }

        public override void Update (GameTime gameTime)
        {
            foreach (var item in menuItems) {
                item.Update (gameTime);
            }

            base.Update (gameTime);
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var item in menuItems) {
                item.Draw (spriteBatch, gameTime);
            }

            base.Draw (spriteBatch, gameTime);
        }
    }
}

