using System;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Utils;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace OpenGoldenSunWindows.Gui
{
    public class PortraitImage : GuiItemBase
    {
        private static IDictionary<string, Texture2D> textures;

        public Character Character { get; set; }
        public Vector2 Position { get; set; }

        public PortraitImage (Character character, Vector2 position)
        {
            this.Character = character;
            this.Position = position;
        }

        public override void Load (Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.Load (content);
            if (textures == null) {
                // TODO clean up the way these textures are loaded
                textures = new Dictionary<string, Texture2D> ();
                foreach (string name in GlobalReference.CharacterNames) {
                    textures.Add (name, content.Load<Texture2D> ("Sprites/Portraits/" + name));
                }
            }
        }

        public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw (spriteBatch, gameTime);

            var texture = textures [Character.Name];
            spriteBatch.Draw (texture, Position);
        }
    }
}

