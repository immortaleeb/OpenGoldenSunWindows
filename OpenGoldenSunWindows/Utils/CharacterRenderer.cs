using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Characters;

namespace OpenGoldenSunWindows.Utils
{
    public class CharacterRenderer
    {
        public static string[] CharacterNames = { "Isaac", "Garet", "Jenna" };
        static IDictionary<string, AnimatedTexture> characterTextures;

        static CharacterRenderer()
        {
            characterTextures = new Dictionary<string, AnimatedTexture> ();
            foreach (string name in CharacterNames) {
                characterTextures.Add(name, new AnimatedTexture());
            }
        }

        private static void LoadCharacterTextures(ContentManager content, string name, float[] frameTimes)
        {
            characterTextures[name].Load (content, "Sprites/Characters/" + name, frameTimes.Length, frameTimes);
        }

        public static void Load(ContentManager content)
        {
            // Load character textures
            LoadCharacterTextures(content, "Isaac", Enumerable.Repeat (0.5f, 16).ToArray ());
            LoadCharacterTextures(content, "Garet", Enumerable.Repeat (0.5f, 8).ToArray ());
            LoadCharacterTextures(content, "Jenna", Enumerable.Repeat (0.5f, 6).ToArray ());
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var texture in characterTextures.Values) {
                texture.Update (gameTime);
            }
        }

        public static AnimatedTexture GetCharacterTexture(Character character)
        {
            return characterTextures [character.Name];
        }
    }
}

