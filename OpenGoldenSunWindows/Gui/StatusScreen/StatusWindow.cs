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

        PortraitImage portrait;

        TextLabel characterName;
        IntegerLabel characterLevel;
        IntegerLabel characterExp;

        IntegerLabel characterHp;
        IntegerLabel characterMaxHp;

        IntegerLabel characterPp;
        IntegerLabel characterMaxPp;

        IntegerLabel characterAttack;
        IntegerLabel characterDefense;
        IntegerLabel characterAgility;
        IntegerLabel characterLuck;

        TextLabel characterClass;
        TextLabel characterStatus;

        IntegerLabel earthDjinn;
        IntegerLabel waterDjinn;
        IntegerLabel fireDjinn;
        IntegerLabel windDjinn;

        public StatusWindow (Reference<Character> selectedCharacter, int x, int y, int width, int height) : base(x, y, width, height)
        {
            this.selectedCharacter = selectedCharacter;

            Add (portrait = new PortraitImage(selectedCharacter.Value, new Vector2(X + 8, Y + 8)));
            Add (characterName = new TextLabel (new Vector2 (X + 48, Y + 8)));
            Add (new TextLabel ("Lv", new Vector2 (X + 112, Y + 8)));
            Add (characterLevel = new IntegerLabel (new Vector2 (X + 150, Y + 8)));

            Add (new TextLabel ("Exp", new Vector2 (X + 48, Y + 16)));
            Add (characterExp = new IntegerLabel (new Vector2 (X + 150, Y + 16)));

            Add (new TextLabel ("HP", new Vector2 (X + 48, Y + 24)));
            Add (new TextLabel ("/", new Vector2 (X + 111, Y + 24)));
            Add (characterHp = new IntegerLabel (new Vector2 (X + 111, Y + 24)));
            Add (characterMaxHp = new IntegerLabel (new Vector2 (X + 150, Y + 24)));

            Add (new TextLabel ("PP", new Vector2 (X + 48, Y + 32)));
            Add (new TextLabel ("/", new Vector2 (X + 111, Y + 32)));
            Add (characterPp = new IntegerLabel (new Vector2 (X + 111, Y + 32)));
            Add (characterMaxPp = new IntegerLabel (new Vector2 (X + 150, Y + 32)));

            Add (new TextLabel ("Attack", new Vector2 (X + 160, Y + 8)));
            Add (characterAttack = new IntegerLabel (new Vector2 (X + 230, Y + 8)));

            Add (new TextLabel ("Defense", new Vector2 (X + 160, Y + 16)));
            Add (characterDefense = new IntegerLabel (new Vector2 (X + 230, Y + 16)));

            Add (new TextLabel ("Agility", new Vector2 (X + 160, Y + 24)));
            Add (characterAgility = new IntegerLabel (new Vector2 (X + 230, Y + 24)));

            Add (new TextLabel ("Luck", new Vector2 (X + 160, Y + 32)));
            Add (characterLuck = new IntegerLabel (new Vector2 (X + 230, Y + 32)));

            Add (characterClass = new TextLabel (new Vector2 (X + 8, Y + 40)));
            Add (characterStatus = new TextLabel (new Vector2 (X + 8, Y + 48)));

            Add (new TextLabel ("Djinn", new Vector2 (X + 72, Y + 96)));
            Add (earthDjinn = new IntegerLabel (new Vector2 (X + 136, Y + 96)));
            Add (waterDjinn = new IntegerLabel (new Vector2 (X + 168, Y + 96)));
            Add (fireDjinn = new IntegerLabel (new Vector2 (X + 200, Y + 96)));
            Add (windDjinn = new IntegerLabel (new Vector2 (X + 232, Y + 96)));
        }

        public override void Update (GameTime gameTime)
        {
            Character character = selectedCharacter.Value;

            portrait.Character = character;

            characterName.Text = character.Name;
            characterLevel.Number = character.Level;
            characterExp.Number = character.Exp;
            characterHp.Number = character.HP;
            characterMaxHp.Number = character.MaxHP;
            characterPp.Number = character.PP;
            characterMaxPp.Number = character.MaxPP;
            characterAttack.Number = character.Attack;
            characterDefense.Number = character.Defense;
            characterAgility.Number = character.Agility;
            characterLuck.Number = character.Luck;
            characterClass.Text = character.Clazz.Name;
            characterStatus.Text = character.StatusAilment.Name;

            earthDjinn.Number = character.Djinn.Count (d => d.Element == Element.Earth);
            waterDjinn.Number = character.Djinn.Count (d => d.Element == Element.Water);
            fireDjinn.Number = character.Djinn.Count (d => d.Element == Element.Fire);
            windDjinn.Number = character.Djinn.Count (d => d.Element == Element.Wind);

            base.Update (gameTime);
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime)
        {
            Character character = selectedCharacter.Value;

            // Djinni
            CharacterRenderer.GetDjinniTexture (Element.Earth).Draw(spriteBatch, new Vector2 (X + 115, Y + 58), null, 0, null, SpriteEffects.FlipHorizontally);
            CharacterRenderer.GetDjinniTexture (Element.Water).Draw(spriteBatch, new Vector2 (X + 147, Y + 58), null, 0, null, SpriteEffects.FlipHorizontally);
            CharacterRenderer.GetDjinniTexture (Element.Fire).Draw(spriteBatch, new Vector2 (X + 180, Y + 58), null, 0, null, SpriteEffects.FlipHorizontally);
            CharacterRenderer.GetDjinniTexture (Element.Wind).Draw(spriteBatch, new Vector2 (X + 211, Y + 58), null, 0, null, SpriteEffects.FlipHorizontally);

            Utils.IconRenderer.DrawElementIcon (Element.Earth, spriteBatch, new Vector2 (X + 129, Y + 89), Color.White);
            Utils.IconRenderer.DrawElementIcon (Element.Water, spriteBatch, new Vector2 (X + 161, Y + 89), Color.White);
            Utils.IconRenderer.DrawElementIcon (Element.Fire, spriteBatch, new Vector2 (X + 193, Y + 89), Color.White);
            Utils.IconRenderer.DrawElementIcon (Element.Wind, spriteBatch, new Vector2 (X + 225, Y + 89), Color.White);

            base.DrawContent (spriteBatch, gameTime);
        }
    }
}

