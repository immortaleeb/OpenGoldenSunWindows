using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Gui;

namespace OpenGoldenSunWindows.Animations
{
    public class MenuItemAnimation : TextureTransformAnimation
    {
        Icons icon;
        SelectedItem<Icons> selectedMenuItem;

        private Texture2D texture;
        public override Texture2D Texture { get { return texture; } }

        public MenuItemAnimation (SelectedItem<Icons> selectedMenuItem, Icons icon, Vector2 position)
            : base (position, 2, 0.12f)
        {
            this.selectedMenuItem = selectedMenuItem;
            this.icon = icon;
        }

        public bool IsSelected()
        {
            return selectedMenuItem.Item == icon;
        }

        public override void Load(ContentManager content)
        {
            texture = content.Load<Texture2D> ("Sprites/Icons/" + Enum.GetName (typeof(Icons), this.icon));
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!IsRunning)
                return;
            
            if (IsSelected ()) {
                spriteBatch.Draw (texture, null, new Rectangle((int)Position.X - 1 - Frame, (int)Position.Y - 4 - Frame, 28 + Frame, 28 + Frame), null, null, 0);
            } else {
                spriteBatch.Draw (texture, Position);
            }
        }
    }
}

