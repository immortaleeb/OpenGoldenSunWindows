using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public class WindowManager
    {
        public static Color DefaultColor = new Color (0, 96, 128);

        public static Color Color;
        public static GraphicsDevice Graphics;

        static WindowManager ()
        {
            Color = DefaultColor;
        }

        public static void Initialize(GraphicsDevice graphics)
        {
            Graphics = graphics;
        }

        public static void Load(ContentManager content)
        {
        }
    }
}

