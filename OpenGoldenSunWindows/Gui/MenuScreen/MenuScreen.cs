using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Animations;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.MenuScreen
{
    public class MenuScreen : ScreenBase
    {
        MenuItemAnimation psynergyMenuItem;
        MenuItemAnimation djinnMenuItem;
        MenuItemAnimation itemsMenuItem;
        MenuItemAnimation statusMenuItem;

        SelectedMenuWindow selectedMenuWindow;

        public MenuScreen (SelectedItem<Icons> selectedMenuItem, MenuController controller) : base(controller)
        {
            psynergyMenuItem = new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Psynergy);
            djinnMenuItem = new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Djinn);
            itemsMenuItem = new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Item);
            statusMenuItem = new MenuItemAnimation (selectedMenuItem, OpenGoldenSunWindows.Utils.Icons.Status);

            selectedMenuWindow = new SelectedMenuWindow (selectedMenuItem);
        }

        public override void Load (Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.Load (content);

            psynergyMenuItem.Load (content);
            djinnMenuItem.Load (content);
            itemsMenuItem.Load (content);
            statusMenuItem.Load (content);
        }

        public override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            psynergyMenuItem.Update (gameTime);
            djinnMenuItem.Update (gameTime);
            itemsMenuItem.Update (gameTime);
            statusMenuItem.Update (gameTime);

            selectedMenuWindow.Update (gameTime);
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            psynergyMenuItem.Draw(spriteBatch, new Vector2(48, 136));
            djinnMenuItem.Draw(spriteBatch, new Vector2(72, 136));
            itemsMenuItem.Draw(spriteBatch, new Vector2(96, 136));
            statusMenuItem.Draw(spriteBatch, new Vector2(120, 136));

            selectedMenuWindow.Draw (spriteBatch, gameTime, 144, 136);
        }
    }
}

