using System;

namespace BlogML.Core
{
    /// <summary>
    /// A serializable keyvalue pair class
    /// </summary>
    public struct Pair<K, V> {
        public K Key;
        public V Value;
        public Pair(K key, V value) {
            this.Key = key;
            this.Value = value;
        }
    }
}
