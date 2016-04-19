using System;

namespace OpenGoldenSunWindows
{
    public interface IObservable
    {
        void Register (IObserver observer);

        void UnRegister (IObserver observer);
    }
}

