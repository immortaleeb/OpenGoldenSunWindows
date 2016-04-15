using System;

namespace OpenGoldenSunWindows.Characters
{
    public class Element
    {
        public static Element Earth = new Element(0, "Venus");
        public static Element Fire = new Element(1, "Mars");
        public static Element Wind = new Element(2, "Jupiter");
        public static Element Water = new Element(3, "Mercury");

        public static Element[] All = { Earth, Fire, Wind, Water };

        public int Index { get; }
        public string Name { get; }

        private Element(int index, string name)
        {
            Index = index;
            Name = name;
        }
    }
}

