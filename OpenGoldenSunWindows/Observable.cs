using System;
using System.Collections.Generic;

namespace OpenGoldenSunWindows
{
    public abstract class Observable : IObservable
    {
        private IList<IObserver> observers;

        public Observable ()
        {
            observers = new List<IObserver> ();
        }

        public void Register(IObserver observer)
        {
            observers.Add (observer);
        }

        public void UnRegister(IObserver observer)
        {
            observers.Remove (observer);
        }

        public void FireEvent()
        {
            foreach (var observer in observers) {
                observer.OnEvent (this);
            }
        }
    }
}

