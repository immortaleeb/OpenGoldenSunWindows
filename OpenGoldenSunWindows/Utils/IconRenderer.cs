using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OpenGoldenSunWindows.Characters;

namespace OpenGoldenSunWindows.Utils
{
    public enum Icons
    {
        Psynergy = 0,
        Djinn,
        Item,
        Status
    }

    public class IconRenderer
    {
        static Texture2D cursorTexture;
        static Texture2D LButtonTexture;
        static Texture2D RButtonTexture;
        static Texture2D AButtonTexture;
        static Texture2D[] elementTextures = new Texture2D[Element.All.Length];
        static Texture2D[] generalIconTextures = new Texture2D[Enum.GetValues (typeof(Icons)).Length];

        static IconRenderer()
        {
        }

        public static void Load(ContentManager content)
        {
            cursorTexture = content.Load<Texture2D> ("Sprites/Icons/cursor");
            LButtonTexture = content.Load<Texture2D> ("Sprites/Icons/button_L");
            RButtonTexture = content.Load<Texture2D> ("Sprites/Icons/button_R");
            AButtonTexture = content.Load<Texture2D> ("Sprites/Icons/button_A");

            foreach (Element element in Element.All) {
                elementTextures [element.Index] = content.Load<Texture2D> ("Sprites/Icons/" + element.Name);
            }

            string[] icons = Enum.GetNames (typeof(Icons));
            for (int i = 0; i < icons.Length; i++) {
                generalIconTextures [i] = content.Load<Texture2D> ("Sprites/Icons/" + icons [i]);
            }
        }

        public static void DrawCursor(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw (cursorTexture, position, color);
        }

        public static void DrawLButton(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw (LButtonTexture, position, color);
        }

        public static void DrawRButton(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw (RButtonTexture, position, color);
        }

        public static void DrawAButton(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw (AButtonTexture, position, color);
        }

        public static void DrawElementIcon(Element element, SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw (elementTextures [element.Index], position, color);
        }

        public static Texture2D GetIconTexture(Icons icon)
        {
            return generalIconTextures[(int)icon];
        }
    }
}

