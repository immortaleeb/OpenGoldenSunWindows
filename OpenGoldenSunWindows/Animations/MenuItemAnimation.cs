using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Animations
{
    public class MenuItemAnimation
    {
        const float FrameDuration = 0.12f;
        const int FrameCount = 2;
        float elapsedTime;
        int frame;

        private bool isRunning;

        Icons icon;
        Texture2D texture;
        SelectedItem<Icons> selectedMenuItem;

        public MenuItemAnimation (SelectedItem<Icons> selectedMenuItem, Icons icon)
        {
            this.selectedMenuItem = selectedMenuItem;
            this.icon = icon;
            elapsedTime = 0;
            frame = 0;
            isRunning = true;
        }

        public bool IsSelected()
        {
            return selectedMenuItem.Item == icon;
        }

        public void Load(ContentManager content)
        {
            texture = IconRenderer.GetIconTexture (icon);
        }

        public void Update(GameTime gameTime)
        {
            if (!isRunning)
                return;
            
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime >= FrameDuration) {
                elapsedTime -= FrameDuration;
                frame = (frame + 1) % FrameCount;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (!isRunning)
                return;
            
            if (IsSelected ()) {
                spriteBatch.Draw (texture, null, new Rectangle((int)position.X - 1 - frame, (int)position.Y - 4 - frame, 28 + frame, 28 + frame), null, null, 0);
            } else {
                spriteBatch.Draw (texture, position);
            }
        }

        public void Start ()
        {
            isRunning = true;
        }

        public void Stop ()
        {
            isRunning = false;
        }
    }
}

