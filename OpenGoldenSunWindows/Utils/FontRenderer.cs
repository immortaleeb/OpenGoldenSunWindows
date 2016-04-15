using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OpenGoldenSunWindows.Utils
{
    public class FontRenderer
    {
        const int normalizedLetterWidth = 8;
        const int normalizedLetterHeight = 8;

        static Texture2D font;
        static int lettersPerRow;
        static int lettersPerColumn;

        // The widths of each letter
        static int[] letterWidths = {
            8, 2, 6, 7, 6, 8, 8, 3, 4, 4, 0, 6, 3, 5, 3, 6, // ' ' - '/'
            7, 4, 7, 7, 7, 7, 7, 7, 7, 7, // '0' - '9'
            3, 3, 6, 5, 5, 6, 8, // ':' - '@'
            6, 6, 6, 6, 6, 6, 6, 6, 4, 6, 6, 6, 8, 6, 6, 6, 6, 6, 6, 6, 6, 6, 8, 6, 6, 6, // 'A' - 'Z'
            4, 0, 4, 7, 6, 0, // '[' - '_'
            6, 6, 6, 6, 6, 5, 6, 6, 4, 4, 5, 4, 8, 6, 6, 6, 6, 6, 6, 5, 6, 6, 8, 6, 6, 6, // 'a' - 'z'
            0, 2, 0, 7 // '{' - '~'
        };

        static int[] letterHeights = {
            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 0, 7, 4, 5, 2, 8,
            8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
            6, 6, 8, 6, 8, 8, 8,
            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
            8, 0, 8, 8, 2, 0,
            6, 8, 6, 8, 6, 8, 6, 8, 8, 8, 8, 8, 6, 6, 6, 6, 6, 6, 6, 8, 6, 6, 6, 6, 6, 6,
            0, 8, 0, 7
        };

        public static void LoadContent(ContentManager content)
        {
            font = content.Load<Texture2D>("Sprites/font");
            lettersPerRow = font.Width / normalizedLetterWidth;
            lettersPerColumn = font.Height / normalizedLetterHeight;
        }

        private static int CharIndex(char c)
        {
            return (int)(c - ' ');
        }

        public static void DrawString(string text, SpriteBatch spriteBatch, Point position, bool center = false)
        {
            int lineCount = 0;
            int xOffset = 0;

            // Draw each letter one at a time
            foreach(char c in text)
            {
                if (c == '\n') {
                    xOffset = 0;
                    lineCount++;
                } else {
                    // Calculate the position of this letter in the font texture
                    int index = CharIndex (c);
                    int row = index / lettersPerRow;
                    int column = index % lettersPerRow;

                    int letterWidth = letterWidths [index];
                    int letterHeight = letterHeights [index];
                    int letterXOffset = center ? (normalizedLetterWidth - letterWidth) / 2 : 0;
                    int letterHeightDifference = normalizedLetterHeight - letterHeight;

                    // Draw the letter unless it's a space
                    if (c != ' ') {
                        spriteBatch.Draw (font,
                            new Rectangle (
                                position.X + xOffset + letterXOffset,
                                position.Y + lineCount * normalizedLetterHeight + letterHeightDifference,
                                letterWidth, letterHeight),
                            new Rectangle (
                                column * normalizedLetterWidth,
                                row * normalizedLetterHeight + letterHeightDifference,
                                letterWidth, letterHeight),
                            Color.White);
                    }

                    xOffset += center ? normalizedLetterWidth : letterWidth;
                }
            }
        }

        public static void DrawStringAlignedRight(string text, SpriteBatch spriteBatch, Point alignPosition, bool center = false)
        {
            int xOffset = 0;

            // Draw each letter one at a time
            for (int i = text.Length-1; i >= 0; i--) {
                char c = text [i];

                // Calculate the position of this letter in the font texture
                int index = CharIndex (c);
                int row = index / lettersPerRow;
                int column = index % lettersPerRow;

                int letterWidth = letterWidths [index];
                int letterHeight = letterHeights [index];
                int letterXOffset = center ? (normalizedLetterWidth - letterWidth) / 2 : 0;
                int letterHeightDifference = normalizedLetterHeight - letterHeight;

                // Draw the letter unless it's a space
                if (c != ' ') {
                    xOffset += center ? normalizedLetterWidth : letterWidth;

                    spriteBatch.Draw (font,
                        new Rectangle (
                            alignPosition.X - xOffset + letterXOffset,
                            alignPosition.Y + letterHeightDifference,
                            letterWidth, letterHeight),
                        new Rectangle (
                            column * normalizedLetterWidth,
                            row * normalizedLetterHeight + letterHeightDifference,
                            letterWidth, letterHeight),
                        Color.White);
                }
            }
        }
    }
}

