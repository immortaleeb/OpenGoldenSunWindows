using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OpenGoldenSunWindows.Gui;
using OpenGoldenSunWindows.Utils;

namespace OpenGoldenSunWindows.Gui.StatusScreen.MainScreen
{
    public class InfoWindow : WindowBase
    {
        public InfoWindow (int x, int y) : base(x, y, 136, 40)
        {
            Add (new TextLabel ("-", new Vector2 (X + 22, Y + 8)));
            Add (new TextLabel (":", new Vector2 (x + 42, y + 8)));
            Add (new TextLabel ("Rearrange", new Vector2 (x + 46, y + 8)));
            Add (new TextLabel (":", new Vector2 (x + 19, y + 16)));
            Add (new TextLabel ("Details", new Vector2 (x + 23, y + 16)));

            Add (new IconLabel (Icons.LButton, new Vector2 (X + 8, Y + 8)));
            Add (new IconLabel (Icons.RButton, new Vector2 (X + 27, Y + 8)));
            Add (new IconLabel (Icons.AButton, new Vector2 (X + 9, Y + 16)));
        }
    }
}

