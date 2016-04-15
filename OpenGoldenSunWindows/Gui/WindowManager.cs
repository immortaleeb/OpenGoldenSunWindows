using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OpenGoldenSunWindows.Gui
{
    /**
     * A window manager is responsible for loading all window related textures
     * and contains methods for creating new windows.
     */
    public class WindowManager
    {
        public Color Color { get; set; }
        public GraphicsDevice Graphics { get { return graphics; } }
        GraphicsDevice graphics;

        public WindowManager ()
        {
            Color = new Color (0, 96, 128);
        }

        public void Initialize(GraphicsDevice graphics)
        {
            this.graphics = graphics;
        }

        public void LoadContent(ContentManager content)
        {
        }
    }
}

