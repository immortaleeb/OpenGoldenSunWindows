using System;
using Microsoft.Xna.Framework;

namespace OpenGoldenSunWindows.Gui
{
    public class IntegerLabel : TextLabel
    {
        public int Number { get; set; }

        public override string Text {
            get { return "" + Number; }
            set { 
                int res;
                int.TryParse (value, out res);
                Number = res;
            }
        }

        public IntegerLabel(Vector2 topRightCorner) : base(topRightCorner, TextAlignment.Right, true)
        {
        }
    }
}

