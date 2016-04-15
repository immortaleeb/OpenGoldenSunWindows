using System;

namespace OpenGoldenSunWindows.Utils
{
    public class Reference<T>
    {
        T value;
        public T Value {
            get { return value; }
            set { this.value = value; }
        }

        public Reference (T value)
        {
            this.value = value;
        }
    }
}

