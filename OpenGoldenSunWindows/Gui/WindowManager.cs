using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    public class WindowManager
    {
        public static Color DefaultColor = new Color (0, 96, 128);

        public Color Color { get; set; }
        public GraphicsDevice Graphics { get { return graphics; } }
        GraphicsDevice graphics;

        public WindowManager ()
        {
            Color = DefaultColor;
        }

        public void Initialize(GraphicsDevice graphics)
        {
            this.graphics = graphics;
        }

        public void Load(ContentManager content)
        {
        }
    }
}

