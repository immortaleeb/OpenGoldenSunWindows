using System;
using Microsoft.Xna.Framework.Content;

namespace OpenGoldenSunWindows
{
    public interface ILoadableComponent
    {
        void Load (ContentManager content);
    }
}

