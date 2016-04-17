using System;
using Microsoft.Xna.Framework;

namespace OpenGoldenSunWindows.Gui
{
    public interface Controller : IUpdateableComponent
    {
        void Update(GameTime gametime);

        void Reset ();
    }
}

