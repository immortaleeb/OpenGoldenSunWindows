using System;
using System.Collections.Generic;
using System.Collections;

namespace OpenGoldenSunWindows.Utils
{
    public class ObservableList<T> : Observable, IList<T>
    {
        private IList<T> list;

        public T this[int i]
        {
            get {
                return list [i];
            }

            set {
                list [i] = value;
                this.FireEvent ();
            }
        }

        public int Count { get { return list.Count; } }
        public bool IsReadOnly { get { return list.IsReadOnly; } }

        public ObservableList ()
        {
            this.list = new List<T> ();
        }

        public ObservableList (int capacity)
        {
            this.list = new List<T> (capacity);
        }

        public void Add (T item)
        {
            this.list.Add (item);
            this.FireEvent ();
        }

        public void Clear ()
        {
            this.list.Clear ();
            this.FireEvent ();
        }

        public bool Contains (T item)
        {
            return this.list.Contains (item);
        }

        public void CopyTo (T[] array, int arrayIndex)
        {
            this.list.CopyTo (array, arrayIndex);
            this.FireEvent ();
        }

        public IEnumerator<T> GetEnumerator ()
        {
            return this.list.GetEnumerator ();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf (T item)
        {
            return this.list.IndexOf (item);
        }

        public void Insert (int index, T item)
        {
            this.list.Insert (index, item);
            this.FireEvent ();
        }

        public bool Remove (T item)
        {
            bool res = this.list.Remove (item);
            this.FireEvent ();
            return res;
        }

        public void RemoveAt (int index)
        {
            this.list.RemoveAt (index);
            this.FireEvent ();
        }
    }
}

