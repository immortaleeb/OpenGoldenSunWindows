using System;
using System.Linq;
using System.Collections.Generic;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Characters
{
    public class Character
    {
        public string Name { get; }

        public Element Element { get; }

        public CharacterClass Clazz { get; }

        public int Level { get { return level; } }
        int level;

        public int Exp { get { return exp; } }
        int exp;

        // Current HP out of maximum HP
        public int HP { get { return hp; } }
        int hp;

        // Maximum HP
        public int MaxHP { get { return maxHP; } }
        int maxHP;

        // Current PP out of maximum PP
        public int PP { get { return pp; } }
        int pp;

        public int MaxPP { get { return maxPP; } }
        int maxPP;

        public int Attack { get { return attack; } }
        int attack;

        public int Defense { get { return defense; } }
        int defense;

        public int Agility { get { return agility; } }
        int agility;

        public int Luck { get { return luck; } }
        int luck;

        public StatusAilment StatusAilment { get; }

        public ObservableList<Djinni> Djinn { get; }

        // Contains the elemental power and resistance in order of each element's index
        private int[] baseElementalPower;
        private int[] baseElementalResistance;

        public Character (
            string name, Element element, CharacterClass clazz, 
            int level, int exp, int hp, int maxHP, int pp, int maxPP, int attack, int defense, int agility, int luck, 
            int[] baseElementalPower, int[] baseElementalResistance,
            StatusAilment statusAilment)
        {
            Name = name;
            Element = element;
            Clazz = clazz;

            this.level = level;
            this.exp = exp;
            this.hp = hp;
            this.maxHP = maxHP;
            this.pp = pp;
            this.maxPP = maxPP;
            this.attack = attack;
            this.defense = defense;
            this.agility = agility;
            this.luck = luck;

            this.baseElementalPower = baseElementalPower;
            this.baseElementalResistance = baseElementalResistance;

            StatusAilment = statusAilment;
            Djinn = new ObservableList<Djinni> (8);
        }

        public int ElementalLevel (Element element)
        {
            int level = element == this.Element ? 5 : 0;
            level += this.Djinn.Count (d => d.Element == element && d.Status == DjinniStatus.Set);
            return level;
        }

        public int ElementalPower (Element element)
        {
            return baseElementalPower [element.Index] + 5 * ElementalLevel (element);
        }

        public int ElementalResistance (Element element)
        {
            return baseElementalResistance [element.Index] + 5 * ElementalLevel (element);
        }
    }
}

