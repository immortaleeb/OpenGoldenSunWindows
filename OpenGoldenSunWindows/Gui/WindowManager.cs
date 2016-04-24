using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public class WindowManager
    {
        public static Color DefaultColor = new Color (0, 96, 128);

        private static Color color;
        public static Color Color { 
            get { return color; }
            set { 
                if (color != value) {
                    color = value;
                    UpdateColors ();
                }
            }
        }

        private static Color selectionColor;
        public static Color SelectionColor { get { return selectionColor; } }
        public static GraphicsDevice Graphics;

        static WindowManager ()
        {
            Color = DefaultColor;
        }

        private static void UpdateColors ()
        {
            selectionColor = new Color (Color.R + 74, Color.G + 74, Color.B + 74);
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

