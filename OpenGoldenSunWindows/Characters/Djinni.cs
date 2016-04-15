using System;

namespace OpenGoldenSunWindows.Characters
{
    public class Djinni
    {
        public string Name { get; }
        public Element Element { get; }

        public Djinni (string name, Element element)
        {
            Name = name;
            Element = element;
        }
    }
}

