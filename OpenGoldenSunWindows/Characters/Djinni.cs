using System;

namespace OpenGoldenSunWindows.Characters
{
    public enum DjinniStatus
    {
        Standy, Set, Recovering
    }

    public class Djinni
    {
        public string Name { get; }
        public Element Element { get; }
        public DjinniStatus Status { get; }

        public Djinni (string name, Element element, DjinniStatus status = DjinniStatus.Set)
        {
            Name = name;
            Element = element;
            Status = status;
        }
    }
}

