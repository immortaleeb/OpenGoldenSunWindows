using System;
using System.Collections.Generic;

namespace OpenGoldenSunWindows.Characters
{
    public class Character
    {
        public string Name { get; }

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

        public IList<Djinni> Djinn { get; }

        public Character (string name, CharacterClass clazz, int level, int exp, int hp, int maxHP, int pp, int maxPP, int attack, int defense, int agility, int luck, StatusAilment statusAilment)
        {
            Name = name;
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
            StatusAilment = statusAilment;
            Djinn = new List<Djinni> (8);
        }
    }
}

