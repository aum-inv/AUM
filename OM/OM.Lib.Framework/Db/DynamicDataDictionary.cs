using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace OM.Lib.Framework.Db
{
    [Serializable]
    public class DynamicDataDictionary : IDictionary<string, string>, ICollection<KeyValuePair<string, string>>, IEnumerable<KeyValuePair<string, string>>, IEnumerable
    {
        private readonly Dictionary<string, string> _innerDictionary;

       // private object _model;

        public DynamicDataDictionary() : this(null) { }

        public DynamicDataDictionary(string model)
        {
            this._innerDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public string this[string key]
        {
            get
            {
                string obj2;
                this._innerDictionary.TryGetValue(key, out obj2);
                return obj2;
            }
            set
            {
                this._innerDictionary[key] = value;
            }
        }

        public int Count
        {
            get
            {
                return this._innerDictionary.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public ICollection<string> Keys
        {
            get
            {
                return this._innerDictionary.Keys;
            }
        }

        public ICollection<string> Values
        {
            get
            {
                return this._innerDictionary.Values;
            }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            return;
        }

        public void Add(string key, string value)
        {
            if (this._innerDictionary.ContainsKey(key))
                this._innerDictionary[key] = value;
            else
                this._innerDictionary.Add(key, value);
        }

        public void Clear()
        {
            this._innerDictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return this._innerDictionary.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return this._innerDictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            return;
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return this._innerDictionary.GetEnumerator();
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return true;
        }

        public bool Remove(string key)
        {
            return this._innerDictionary.Remove(key);
        }

        public bool TryGetValue(string key, out string value)
        {
            return this._innerDictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._innerDictionary.GetEnumerator();
        }
    }
}
