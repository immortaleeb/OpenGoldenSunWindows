using System;
using Microsoft.Xna.Framework;
using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Utils;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace OpenGoldenSunWindows.Gui
{
    public class PortraitImage : TextureLabel
    {
        private static IDictionary<string, Texture2D> textures;

        public override Texture2D Texture {
            get {
                var name = this.Character.Name;
                return name == null ? null : textures [name];
            }
        }
        public Character Character { get; set; }

        public PortraitImage (Character character, Vector2 position) : base (position)
        {
            this.Character = character;
        }

        public override void Load (Microsoft.Xna.Framework.Content.ContentManager content)
        {
            if (textures == null) {
                // TODO clean up the way these textures are loaded
                textures = new Dictionary<string, Texture2D> ();
                foreach (string name in GlobalReference.CharacterNames) {
                    textures.Add (name, content.Load<Texture2D> ("Sprites/Portraits/" + name));
                }
            }
        }
    }
}

