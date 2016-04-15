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
        static string[] characterNames = { "Isaac", "Garet", "Jenna" };
        static IDictionary<string, AnimatedTexture> characterTextures;
        static IDictionary<string, Texture2D> portraitTextures;
        static AnimatedTexture[] djinnTextures = new AnimatedTexture[Element.All.Length];

        static CharacterRenderer()
        {
            characterTextures = new Dictionary<string, AnimatedTexture> ();
            portraitTextures = new Dictionary<string, Texture2D> ();
            foreach (string name in characterNames) {
                characterTextures.Add(name, new AnimatedTexture());
            }

            foreach (Element element in Element.All) {
                djinnTextures [element.Index] = new AnimatedTexture ();
            }
        }

        private static void LoadCharacterTextures(ContentManager content, string name, float[] frameTimes)
        {
            characterTextures[name].Load (content, "Sprites/Characters/" + name, frameTimes.Length, frameTimes);
            portraitTextures.Add (name, content.Load<Texture2D> ("Sprites/Portraits/" + name));
        }

        private static void LoadDjinniTextures(ContentManager content, Element element, float[] frameTimes)
        {
            djinnTextures [element.Index].Load(content, "Sprites/Djinn/" + element.Name + "_Djinn", frameTimes.Length, frameTimes);
        }

        public static void Load(ContentManager content)
        {
            // Load character textures
            LoadCharacterTextures(content, "Isaac", Enumerable.Repeat (0.5f, 16).ToArray ());
            LoadCharacterTextures(content, "Garet", Enumerable.Repeat (0.5f, 8).ToArray ());
            LoadCharacterTextures(content, "Jenna", Enumerable.Repeat (0.5f, 6).ToArray ());

            // Load djinni textures
            LoadDjinniTextures(content, Element.Earth, Enumerable.Repeat (0.5f, 4).ToArray());
            LoadDjinniTextures(content, Element.Fire, Enumerable.Repeat (0.5f, 4).ToArray());
            LoadDjinniTextures(content, Element.Wind, Enumerable.Repeat (0.5f, 3).ToArray());
            LoadDjinniTextures(content, Element.Water, Enumerable.Repeat (0.5f, 3).ToArray());
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var texture in characterTextures.Values) {
                texture.Update (gameTime);
            }

            foreach (var texture in djinnTextures) {
                texture.Update (gameTime);
            }
        }

        public static AnimatedTexture GetCharacterTexture(Character character)
        {
            return characterTextures [character.Name];
        }

        public static AnimatedTexture GetDjinniTexture(Djinni djinni)
        {
            return GetDjinniTexture (djinni.Element);
        } 

        public static AnimatedTexture GetDjinniTexture(Element element)
        {
            return djinnTextures [element.Index];
        }

        public static void DrawPortrait(Character character, SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            var texture = portraitTextures [character.Name];
            spriteBatch.Draw (texture, position, color);
        }
    }
}

