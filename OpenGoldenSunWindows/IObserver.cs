using System;

namespace OpenGoldenSunWindows
{
    public interface IObserver
    {
        void OnEvent (IObservable source);
    }
}

