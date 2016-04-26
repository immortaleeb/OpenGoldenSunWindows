using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Characters;
using OpenGoldenSunWindows.Gui;

namespace OpenGoldenSunWindows.Utils
{
    public class GlobalReference
    {
        public static string[] CharacterNames = { "Isaac", "Garet", "Jenna", "Alex" };

        private static Icons[] elementIcons = { Icons.Venus, Icons.Mars, Icons.Jupiter, Icons.Mercury };
        public static Icons GetElementIcon (Element element)
        {
            return elementIcons [element.Index];
        }
    }
}

