using GardenJournalDemoApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GardenJournalDemoApp.InterfacesAbstractClasses
{
    public class GardenList : IList<Garden>
    {
        private IList<Garden> _list = new List<Garden>();

        public Garden this[int index] { get => _list[index]; set => _list[index] = value; }

        public int Count => _list.Count;

        public bool IsReadOnly => _list.IsReadOnly;

        public void Add(Garden item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(Garden item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(Garden[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Garden> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(Garden item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, Garden item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(Garden item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
