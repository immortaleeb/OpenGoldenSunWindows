using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Gui;

namespace OpenGoldenSunWindows.Animations
{
    public class MenuItemAnimation : AnimationBase
    {
        const float FrameDuration = 0.12f;
        const int FrameCount = 2;
        float elapsedTime;
        int frame;

        private bool isRunning;

        Icons icon;
        Texture2D texture;
        SelectedItem<Icons> selectedMenuItem;

        public MenuItemAnimation (SelectedItem<Icons> selectedMenuItem, Icons icon, Vector2 position) : base (position)
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

        public override void Load(ContentManager content)
        {
            texture = content.Load<Texture2D> ("Sprites/Icons/" + Enum.GetName (typeof(Icons), this.icon));
        }

        public override void Update(GameTime gameTime)
        {
            if (!isRunning)
                return;
            
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime >= FrameDuration) {
                elapsedTime -= FrameDuration;
                frame = (frame + 1) % FrameCount;
            }
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!isRunning)
                return;
            
            if (IsSelected ()) {
                spriteBatch.Draw (texture, null, new Rectangle((int)Position.X - 1 - frame, (int)Position.Y - 4 - frame, 28 + frame, 28 + frame), null, null, 0);
            } else {
                spriteBatch.Draw (texture, Position);
            }
        }

        public override void Play ()
        {
            isRunning = true;
        }

        public override void Pause ()
        {
            isRunning = false;
        }

        public override void Stop ()
        {
            Pause ();
        }
    }
}

