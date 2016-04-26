using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui
{
    public enum TextAlignment
    {
        Left, Right
    }

    public class TextLabel : GuiItemBase
    {
        protected const int NormalizedLetterWidth = 8;
        protected const int NormalizedLetterHeight = 8;

        private static int[] LetterWidths = {
            5, 2, 6, 7, 6, 8, 8, 3, 4, 4, 0, 6, 3, 5, 3, 6, // ' ' - '/'
            7, 4, 7, 7, 7, 7, 7, 7, 7, 7, // '0' - '9'
            3, 3, 6, 5, 5, 6, 8, // ':' - '@'
            6, 6, 6, 6, 6, 6, 6, 6, 4, 6, 6, 6, 8, 6, 6, 6, 6, 6, 6, 6, 6, 6, 8, 6, 6, 6, // 'A' - 'Z'
            4, 0, 4, 7, 6, 0, // '[' - '_'
            6, 6, 6, 6, 6, 5, 6, 6, 4, 4, 5, 4, 8, 6, 6, 6, 6, 6, 6, 5, 6, 6, 8, 6, 6, 6, // 'a' - 'z'
            0, 2, 0, 7 // '{' - '~'
        };

        private static int[] LetterHeights = {
            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 0, 7, 4, 5, 2, 8,
            8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
            6, 6, 8, 6, 8, 8, 8,
            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
            8, 0, 8, 8, 2, 0,
            6, 8, 6, 8, 6, 8, 6, 8, 8, 8, 8, 8, 6, 6, 6, 6, 6, 6, 6, 8, 6, 6, 6, 6, 6, 6,
            0, 8, 0, 7
        };

        public static TextureAtlas Font;

        public Vector2 Position { get; set; }
        public virtual string Text { get; set; }
        public TextAlignment Alignment { get; set; }
        public bool CenterCharacters { get; set; }
        public Color? Color { get; set; }

        public TextLabel (Vector2 position, TextAlignment alignment = TextAlignment.Left, bool centerCharacters = false) : this ("", position, alignment, centerCharacters)
        {
        }

        public TextLabel (string text, Vector2 position, TextAlignment alignment = TextAlignment.Left, bool centerCharacters = false)
        {
            Text = text;
            Position = position;
            Alignment = alignment;
            CenterCharacters = centerCharacters;
        }

        public override void Load(ContentManager content)
        {
            // Load the font only once
            if (Font == null) {
                Texture2D fontTexture = content.Load<Texture2D> ("Sprites/font");
                Font = new TextureAtlas (fontTexture, NormalizedLetterWidth, NormalizedLetterHeight);
            }
        }

        private static int CharIndex(char c)
        {
            return (int)(c - ' ');
        }

        private void DrawCharacter(SpriteBatch spriteBatch, int index, Vector2 position)
        {
            if (index == 0)
                return; // Don't render spaces
            
            int letterWidth = LetterWidths [index];
            int letterHeight = LetterHeights [index];
            int letterXOffset = CenterCharacters ? (NormalizedLetterWidth - letterWidth) / 2 : 0;
            int letterYOffset = NormalizedLetterHeight - letterHeight;

            Vector2 drawPos = new Vector2 (position.X + letterXOffset, position.Y + letterYOffset);
            Rectangle relativeSource = new Rectangle (0, letterYOffset, letterWidth, letterHeight);

            Font.Draw (spriteBatch, index, drawPos, relativeSource, this.Color);
        }

        private void DrawLeftAligned(SpriteBatch spriteBatch)
        {
            Vector2 charPos = new Vector2 (Position.X, Position.Y);

            foreach (char c in Text) {
                int index = CharIndex (c);
                DrawCharacter (spriteBatch, index, charPos);
                charPos.X += CenterCharacters ? TextLabel.NormalizedLetterWidth : TextLabel.LetterWidths [index];
            }
        }

        private void DrawRightAligned(SpriteBatch spriteBatch)
        {
            Vector2 charPos = new Vector2 (Position.X, Position.Y);

            // Draw letters in reverse order
            for (int i = Text.Length-1; i >= 0; i--) {
                char c = Text [i];
                int index = CharIndex (c);
                charPos.X -= CenterCharacters ? TextLabel.NormalizedLetterWidth : TextLabel.LetterWidths [index];
                DrawCharacter (spriteBatch, index, charPos);

            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Text == null)
                return;
            
            if (Alignment == TextAlignment.Left) {
                DrawLeftAligned (spriteBatch);
            } else {
                DrawRightAligned (spriteBatch);
            }
        }

        protected override void OnHide ()
        {
            // Nothing to do
        }

        protected override void OnShow ()
        {
            // Nothing to do
        }

        public override void Update (GameTime gameTime)
        {
            // Nothing to do
        }
    }
}

