using System;
using System.Collections.Generic;

namespace OpenGoldenSunWindows.Characters
{
    public class Party : Observable
    {
        public IList<Character> Characters { get; }

        public Party (IList<Character> characters)
        {
            Characters = characters;
        }

        public void RemoveCharacter(int index)
        {
            Characters.RemoveAt (index);
            FireEvent ();
        }

        public void AddCharacter(Character character)
        {
            Characters.Add (character);
            FireEvent ();
        }
    }
}

