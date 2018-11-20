using System.Collections.Generic;

namespace Smooth.Compare.Comparers
{
	/// <summary>
	///     Allocation free sort order comparer for KeyValuePair<K, V>s.
	/// </summary>
	public class KeyValuePairComparer<K, V> : Collections.Comparer<KeyValuePair<K, V>>
    {
        public override int Compare(KeyValuePair<K, V> l, KeyValuePair<K, V> r)
        {
            var c = Collections.Comparer<K>.Default.Compare(l.Key, r.Key);
            return c == 0 ? Collections.Comparer<V>.Default.Compare(l.Value, r.Value) : c;
        }
    }

	/// <summary>
	///     Allocation free equality comparer for KeyValuePair<K, V>s.
	/// </summary>
	public class KeyValuePairEqualityComparer<K, V> : Collections.EqualityComparer<KeyValuePair<K, V>>
    {
        public override bool Equals(KeyValuePair<K, V> l, KeyValuePair<K, V> r)
        {
            return Collections.EqualityComparer<K>.Default.Equals(l.Key, r.Key) &&
                   Collections.EqualityComparer<V>.Default.Equals(l.Value, r.Value);
        }

        public override int GetHashCode(KeyValuePair<K, V> kvp)
        {
            unchecked
            {
                var hash = 17;
                hash = 29 * hash + Collections.EqualityComparer<K>.Default.GetHashCode(kvp.Key);
                hash = 29 * hash + Collections.EqualityComparer<V>.Default.GetHashCode(kvp.Value);
                return hash;
            }
        }
    }
}