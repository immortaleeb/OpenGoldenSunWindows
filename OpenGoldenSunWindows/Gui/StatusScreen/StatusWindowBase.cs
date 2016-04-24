using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;
using OpenGoldenSunWindows.Animations;

namespace OpenGoldenSunWindows.Gui.StatusScreen
{
    public abstract class StatusWindowBase : WindowBase, IObserver
    {
        protected ObservableReference<Character> selectedCharacter;

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

        public StatusWindowBase (ObservableReference<Character> selectedCharacter, int x, int y) : base(x, y, 240, 120)
        {
            this.selectedCharacter = selectedCharacter;
            this.selectedCharacter.Register (this);

            // Characters stats
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
        }

        public virtual void OnEvent (IObservable source)
        {
            if (source != this.selectedCharacter)
                return;
            
            // Update character info
            Character character = selectedCharacter.Value;
            if (character == null)
                return;

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
        }
    }
}

