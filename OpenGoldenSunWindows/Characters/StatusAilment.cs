using System;

namespace OpenGoldenSunWindows.Characters
{
    public class StatusAilment
    {
        public static StatusAilment NORMAL = new StatusAilment ("Normal");

        public string Name { get; }

        public StatusAilment (string name)
        {
            Name = name;
        }
    }
}

