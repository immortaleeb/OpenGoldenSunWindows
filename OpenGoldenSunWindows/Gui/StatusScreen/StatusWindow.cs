using System;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public class StatusWindow : WindowBase
    {
        Reference<Character> selectedCharacter;

        public StatusWindow (WindowManager manager, Reference<Character> selectedCharacter, int width, int height) : base(manager, width, height)
        {
            this.selectedCharacter = selectedCharacter;
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime, int x, int y)
        {
            Character character = selectedCharacter.Value;

            CharacterRenderer.DrawPortrait (character, spriteBatch, new Vector2 (x + 8, y + 8), Color.White);

            // Stats
            FontRenderer.DrawString (character.Name, spriteBatch, new Point(x + 48, y + 8));
            FontRenderer.DrawString ("Lv", spriteBatch, new Point(x + 112, y + 8));
            FontRenderer.DrawStringAlignedRight (character.Level.ToString (), spriteBatch, new Point (x + 150, y + 8), true);

            FontRenderer.DrawString ("Exp\nHP\nPP", spriteBatch, new Point(x + 48, y + 16));
            FontRenderer.DrawStringAlignedRight (character.Exp.ToString(), spriteBatch, new Point (x + 150, y + 16), true);
            FontRenderer.DrawStringAlignedRight (character.HP + "/", spriteBatch, new Point (x + 119, y + 24), true);
            FontRenderer.DrawStringAlignedRight (character.MaxHP.ToString(), spriteBatch, new Point (x + 150, y + 24), true);
            FontRenderer.DrawStringAlignedRight (character.PP + "/", spriteBatch, new Point (x + 119, y + 32), true);
            FontRenderer.DrawStringAlignedRight (character.MaxPP.ToString(), spriteBatch, new Point (x + 150, y + 32), true);

            FontRenderer.DrawString ("Attack\nDefense\nAgility\nLuck", spriteBatch, new Point(x + 160, y + 8));
            FontRenderer.DrawStringAlignedRight (character.Attack.ToString(), spriteBatch, new Point (x + 230, y + 8), true);
            FontRenderer.DrawStringAlignedRight (character.Defense.ToString(), spriteBatch, new Point (x + 230, y + 16), true);
            FontRenderer.DrawStringAlignedRight (character.Agility.ToString(), spriteBatch, new Point (x + 230, y + 24), true);
            FontRenderer.DrawStringAlignedRight (character.Luck.ToString(), spriteBatch, new Point (x + 230, y + 32), true);

            FontRenderer.DrawString (character.Clazz.Name, spriteBatch, new Point (x + 8, y + 40));
            FontRenderer.DrawString (character.StatusAilment.Name, spriteBatch, new Point (x + 8, y + 48));

            // Djinni
            FontRenderer.DrawString ("Djinn", spriteBatch, new Point (x + 72, y + 96));

            CharacterRenderer.GetDjinniTexture (Element.Earth).Draw(spriteBatch, new Vector2 (x + 115, y + 58), null, 0, null, SpriteEffects.FlipHorizontally);
            CharacterRenderer.GetDjinniTexture (Element.Water).Draw(spriteBatch, new Vector2 (x + 147, y + 58), null, 0, null, SpriteEffects.FlipHorizontally);
            CharacterRenderer.GetDjinniTexture (Element.Fire).Draw(spriteBatch, new Vector2 (x + 180, y + 58), null, 0, null, SpriteEffects.FlipHorizontally);
            CharacterRenderer.GetDjinniTexture (Element.Wind).Draw(spriteBatch, new Vector2 (x + 211, y + 58), null, 0, null, SpriteEffects.FlipHorizontally);

            Utils.IconRenderer.DrawElementIcon (Element.Earth, spriteBatch, new Vector2 (x + 129, y + 89), Color.White);
            Utils.IconRenderer.DrawElementIcon (Element.Water, spriteBatch, new Vector2 (x + 161, y + 89), Color.White);
            Utils.IconRenderer.DrawElementIcon (Element.Fire, spriteBatch, new Vector2 (x + 193, y + 89), Color.White);
            Utils.IconRenderer.DrawElementIcon (Element.Wind, spriteBatch, new Vector2 (x + 225, y + 89), Color.White);

            FontRenderer.DrawStringAlignedRight (character.Djinn.Count (d => d.Element == Element.Earth).ToString (), spriteBatch, new Point (x + 136, y + 96), true);
            FontRenderer.DrawStringAlignedRight (character.Djinn.Count (d => d.Element == Element.Water).ToString (), spriteBatch, new Point (x + 168, y + 96), true);
            FontRenderer.DrawStringAlignedRight (character.Djinn.Count (d => d.Element == Element.Fire).ToString (), spriteBatch, new Point (x + 200, y + 96), true);
            FontRenderer.DrawStringAlignedRight (character.Djinn.Count (d => d.Element == Element.Wind).ToString (), spriteBatch, new Point (x + 232, y + 96), true);
        }
    }
}

