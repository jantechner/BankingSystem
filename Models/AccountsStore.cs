using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Models
{
    public class AccountsStore : IDictionary<Customer, Account>
    {
        private Dictionary<Customer, Account> _accounts = new Dictionary<Customer, Account>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<Customer, Account>> GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }

        public void Add(KeyValuePair<Customer, Account> item)
        {
            _accounts.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _accounts.Clear();
        }

        public bool Contains(KeyValuePair<Customer, Account> item)
        {
            return _accounts.Contains(item);
        }

        public void CopyTo(KeyValuePair<Customer, Account>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Customer, Account> item)
        {
            return _accounts.Remove(item.Key);
        }

        public int Count
        {
            get { return _accounts.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(Customer key, Account value)
        {
            _accounts.Add(key, value);
        }

        public bool ContainsKey(Customer key)
        {
            return _accounts.ContainsKey(key);
        }

        public bool Remove(Customer key)
        {
            return _accounts.Remove(key);
        }

        public bool TryGetValue(Customer key, out Account value)
        {
            return _accounts.TryGetValue(key, out value);
        }

        public Account this[Customer key]
        {
            get { return _accounts[key]; }
            set { }
        }

        public ICollection<Customer> Keys
        {
            get { return _accounts.Keys; }
        }

        public ICollection<Account> Values
        {
            get { return _accounts.Values; }
        }
    }
}