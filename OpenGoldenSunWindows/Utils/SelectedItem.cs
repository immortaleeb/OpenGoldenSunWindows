using System;

namespace OpenGoldenSunWindows.Utils
{
    public class SelectedItem<T> : Observable
    {
        private int index;
        public int Index { 
            get { return index; }
            set {
                if (value != this.index) {
                    this.index = value;
                    FireEvent ();
                }
            }
        }

        public T Item { get { return Items [Index]; } }
        public T[] Items { get; }

        public SelectedItem(int index, T[] items)
        {
            this.index = index;
            Items = items;
        }
    }
}

