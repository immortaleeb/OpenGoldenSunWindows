using System;

namespace OpenGoldenSunWindows.Utils
{
    public class ObservableReference<T> : Observable
    {
        private Reference<T> reference;
        public T Value {
            get { return reference.Value; }
            set { 
                if (!value.Equals(reference.Value)) {
                    reference.Value = value;
                    this.FireEvent ();
                }
            }
        }

        public ObservableReference (T value) : base()
        {
            reference = new Reference<T> (value);
        }
    }
}

