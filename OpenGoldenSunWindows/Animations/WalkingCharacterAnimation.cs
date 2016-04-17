using System;
using System.Collections.Generic;
using OpenGoldenSunWindows.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using OpenGoldenSunWindows.Characters;

namespace OpenGoldenSunWindows.Animations
{
    public class WalkingCharacterAnimation : AnimatedTextureAnimation
    {
        private static IDictionary<string, AnimatedTexture> characterTextures;

        public Character Character { get; set; }
        public override AnimatedTexture Texture { 
            get { 
                var name = this.Character?.Name;
                return name == null ? null : characterTextures [name]; 
            }
        }

        public WalkingCharacterAnimation (Vector2 position) : base (position)
        {
        }

        private void LoadCharacterTextures(ContentManager content, string name, float[] frameTimes)
        {
            var texture = new AnimatedTexture ();
            texture.Load (content, "Sprites/Characters/" + name, frameTimes.Length, frameTimes);
            characterTextures.Add(name, texture);
        }

        public override void Load (ContentManager content)
        {
            if (characterTextures == null) {
                characterTextures = new Dictionary<string, AnimatedTexture> ();

                LoadCharacterTextures(content, "Isaac", Enumerable.Repeat (0.5f, 16).ToArray ());
                LoadCharacterTextures(content, "Garet", Enumerable.Repeat (0.5f, 8).ToArray ());
                LoadCharacterTextures(content, "Jenna", Enumerable.Repeat (0.5f, 6).ToArray ());
            }
        }
    }
}

