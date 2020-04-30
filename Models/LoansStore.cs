using System;
using System.Collections;
using System.Collections.Generic;

namespace Models
{
    public class LoansStore : IList<Loan>
    {
        private List<Loan> _loans = new List<Loan>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _loans.GetEnumerator();
        }

        public IEnumerator<Loan> GetEnumerator()
        {
            return _loans.GetEnumerator();
        }

        public void Add(Loan item)
        {
            _loans.Add(item);
        }

        public void Clear()
        {
            _loans.Clear();
        }

        public bool Contains(Loan item)
        {
            return _loans.Contains(item);
        }

        public void CopyTo(Loan[] array, int arrayIndex)
        {
            _loans.CopyTo(array, arrayIndex);
        }

        public bool Remove(Loan item)
        {
            return _loans.Remove(item);
        }

        public int Count => _loans.Count;
        public bool IsReadOnly => false;

        public int IndexOf(Loan item)
        {
            return _loans.IndexOf(item);
        }

        public void Insert(int index, Loan item)
        {
            _loans.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _loans.RemoveAt(index);
        }

        public Loan this[int index]
        {
            get => _loans[index];
            set => _loans[index] = value;
        }
    }
}