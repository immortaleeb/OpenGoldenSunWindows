using System;

namespace OpenGoldenSunWindows.Utils
{
    public class SelectedItem<T>
    {
        public int Index { get; set; }
        public T Item { get { return Items [Index]; } }
        public T[] Items { get; }

        public SelectedItem(int index, T[] items)
        {
            Index = index;
            Items = items;
        }
    }
}

