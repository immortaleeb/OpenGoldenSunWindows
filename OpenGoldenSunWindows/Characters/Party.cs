using System;
using System.Collections.Generic;

namespace OpenGoldenSunWindows.Characters
{
    public class Party
    {
        public IList<Character> Characters { get; }

        public Party (IList<Character> characters)
        {
            Characters = characters;
        }
    }
}

