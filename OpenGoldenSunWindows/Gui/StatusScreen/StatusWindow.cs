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

        TextLabel characterName;
        TextLabel lvText;
        IntegerLabel characterLevel;

        TextLabel expText;
        IntegerLabel characterExp;

        TextLabel hpText;
        TextLabel hpSeparator;
        IntegerLabel characterHp;
        IntegerLabel characterMaxHp;

        TextLabel ppText;
        TextLabel ppSeparator;
        IntegerLabel characterPp;
        IntegerLabel characterMaxPp;

        TextLabel attackText;
        IntegerLabel characterAttack;

        TextLabel defenseText;
        IntegerLabel characterDefense;

        TextLabel agilityText;
        IntegerLabel characterAgility;

        TextLabel luckText;
        IntegerLabel characterLuck;

        TextLabel characterClass;
        TextLabel characterStatus;

        TextLabel djinnText;

        IntegerLabel earthDjinn;
        IntegerLabel waterDjinn;
        IntegerLabel fireDjinn;
        IntegerLabel windDjinn;

        public StatusWindow (Reference<Character> selectedCharacter, int x, int y, int width, int height) : base(x, y, width, height)
        {
            this.selectedCharacter = selectedCharacter;

            characterName = new TextLabel (new Vector2 (X + 48, Y + 8));
            lvText = new TextLabel ("Lv", new Vector2 (X + 112, Y + 8));
            characterLevel = new IntegerLabel (new Vector2 (X + 150, Y + 8));

            expText = new TextLabel ("Exp", new Vector2 (X + 48, Y + 16));
            characterExp = new IntegerLabel (new Vector2 (X + 150, Y + 16));

            hpText = new TextLabel ("HP", new Vector2 (X + 48, Y + 24));
            hpSeparator = new TextLabel ("/", new Vector2 (X + 111, Y + 24));
            characterHp = new IntegerLabel (new Vector2 (X + 111, Y + 24));
            characterMaxHp = new IntegerLabel (new Vector2 (X + 150, Y + 24));

            ppText = new TextLabel ("PP", new Vector2 (X + 48, Y + 32));
            ppSeparator = new TextLabel ("/", new Vector2 (X + 111, Y + 32));
            characterPp = new IntegerLabel (new Vector2 (X + 111, Y + 32));
            characterMaxPp = new IntegerLabel (new Vector2 (X + 150, Y + 32));

            attackText = new TextLabel ("Attack", new Vector2 (X + 160, Y + 8));
            characterAttack = new IntegerLabel (new Vector2 (X + 230, Y + 8));

            defenseText = new TextLabel ("Defense", new Vector2 (X + 160, Y + 16));
            characterDefense = new IntegerLabel (new Vector2 (X + 230, Y + 16));

            agilityText = new TextLabel ("Agility", new Vector2 (X + 160, Y + 24));
            characterAgility = new IntegerLabel (new Vector2 (X + 230, Y + 24));

            luckText = new TextLabel ("Luck", new Vector2 (X + 160, Y + 32));
            characterLuck = new IntegerLabel (new Vector2 (X + 230, Y + 32));

            characterClass = new TextLabel (new Vector2 (X + 8, Y + 40));
            characterStatus = new TextLabel (new Vector2 (X + 8, Y + 48));

            djinnText = new TextLabel("Djinn", new Vector2(X + 72, Y + 96));
            earthDjinn = new IntegerLabel (new Vector2 (X + 136, Y + 96));
            waterDjinn = new IntegerLabel (new Vector2 (X + 168, Y + 96));
            fireDjinn = new IntegerLabel (new Vector2 (X + 200, Y + 96));
            windDjinn = new IntegerLabel (new Vector2 (X + 232, Y + 96));
        }
         
        public override void Load (Microsoft.Xna.Framework.Content.ContentManager content)
        {
            base.Load (content);

            // TODO: load all textboxes
            characterName.Load (content);
        }

        public override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            Character character = selectedCharacter.Value;
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
        }

        protected override void DrawContent (SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            Character character = selectedCharacter.Value;
            CharacterRenderer.DrawPortrait (character, spriteBatch, new Vector2 (X + 8, Y + 8), Color.White);

            // Stats
            characterName.Draw (spriteBatch);
            lvText.Draw (spriteBatch);
            characterLevel.Draw (spriteBatch);

            expText.Draw (spriteBatch);
            characterExp.Draw (spriteBatch);

            hpText.Draw (spriteBatch);
            characterHp.Draw (spriteBatch);
            hpSeparator.Draw (spriteBatch);
            characterMaxHp.Draw (spriteBatch);

            ppText.Draw (spriteBatch);
            characterPp.Draw (spriteBatch);
            ppSeparator.Draw (spriteBatch);
            characterMaxPp.Draw (spriteBatch);

            attackText.Draw (spriteBatch);
            characterAttack.Draw (spriteBatch);

            defenseText.Draw (spriteBatch);
            characterDefense.Draw (spriteBatch);

            agilityText.Draw (spriteBatch);
            characterAgility.Draw (spriteBatch);

            luckText.Draw (spriteBatch);
            characterLuck.Draw (spriteBatch);

            characterClass.Draw (spriteBatch);
            characterStatus.Draw (spriteBatch);

            // Djinni
            djinnText.Draw (spriteBatch);

            CharacterRenderer.GetDjinniTexture (Element.Earth).Draw(spriteBatch, new Vector2 (X + 115, Y + 58), null, 0, null, SpriteEffects.FlipHorizontally);
            CharacterRenderer.GetDjinniTexture (Element.Water).Draw(spriteBatch, new Vector2 (X + 147, Y + 58), null, 0, null, SpriteEffects.FlipHorizontally);
            CharacterRenderer.GetDjinniTexture (Element.Fire).Draw(spriteBatch, new Vector2 (X + 180, Y + 58), null, 0, null, SpriteEffects.FlipHorizontally);
            CharacterRenderer.GetDjinniTexture (Element.Wind).Draw(spriteBatch, new Vector2 (X + 211, Y + 58), null, 0, null, SpriteEffects.FlipHorizontally);

            Utils.IconRenderer.DrawElementIcon (Element.Earth, spriteBatch, new Vector2 (X + 129, Y + 89), Color.White);
            Utils.IconRenderer.DrawElementIcon (Element.Water, spriteBatch, new Vector2 (X + 161, Y + 89), Color.White);
            Utils.IconRenderer.DrawElementIcon (Element.Fire, spriteBatch, new Vector2 (X + 193, Y + 89), Color.White);
            Utils.IconRenderer.DrawElementIcon (Element.Wind, spriteBatch, new Vector2 (X + 225, Y + 89), Color.White);

            earthDjinn.Draw (spriteBatch);
            waterDjinn.Draw (spriteBatch);
            fireDjinn.Draw (spriteBatch);
            windDjinn.Draw (spriteBatch);
        }
    }
}

