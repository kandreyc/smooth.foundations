using System.Collections.Generic;
using System.Text;

namespace Smooth.Pools
{
	/// <summary>
	///     Singleton Dictionary<K, V> pool.
	/// </summary>
	public static class DictionaryPool<K, V>
    {
	    /// <summary>
	    ///     Singleton Dictionary<K, V> pool instance.
	    /// </summary>
	    public static KeyedPoolWithDefaultKey<IEqualityComparer<K>, Dictionary<K, V>> Instance { get; } =
            new KeyedPoolWithDefaultKey<IEqualityComparer<K>, Dictionary<K, V>>(
                comparer => new Dictionary<K, V>(comparer),
                dictionary =>
                {
                    dictionary.Clear();
                    return dictionary.Comparer;
                },
                () => Collections.EqualityComparer<K>.Default
            );
    }

	/// <summary>
	///     Singleton HashSet<T> pool.
	/// </summary>
	public static class HashSetPool<T>
    {
	    /// <summary>
	    ///     Singleton HashSet<T> pool instance.
	    /// </summary>
	    public static KeyedPoolWithDefaultKey<IEqualityComparer<T>, HashSet<T>> Instance { get; } =
            new KeyedPoolWithDefaultKey<IEqualityComparer<T>, HashSet<T>>(
                comparer => new HashSet<T>(comparer),
                hashSet =>
                {
                    hashSet.Clear();
                    return hashSet.Comparer;
                },
                () => Collections.EqualityComparer<T>.Default
            );
    }

	/// <summary>
	///     Singleton List<T> pool.
	/// </summary>
	public static class ListPool<T>
    {
	    /// <summary>
	    ///     Singleton List<T> pool instance.
	    /// </summary>
	    public static Pool<List<T>> Instance { get; } = new Pool<List<T>>(
            () => new List<T>(),
            list => list.Clear());
    }

	/// <summary>
	///     Singleton LinkedList<T> pool.
	/// </summary>
	public static class LinkedListPool<T>
    {
	    /// <summary>
	    ///     Singleton LinkedList<T> pool instance.
	    /// </summary>
	    public static Pool<LinkedList<T>> Instance { get; } = new Pool<LinkedList<T>>(
            () => new LinkedList<T>(),
            list =>
            {
                var node = list.First;
                while (node != null)
                {
                    list.RemoveFirst();
                    LinkedListNodePool<T>.Instance.Release(node);
                    node = list.First;
                }
            }
        );
    }

	/// <summary>
	///     Singleton LinkedListNode<T> pool.
	/// </summary>
	public static class LinkedListNodePool<T>
    {
	    /// <summary>
	    ///     Singleton LinkedListNode<T> pool instance.
	    /// </summary>
	    public static PoolWithInitializer<LinkedListNode<T>, T> Instance { get; } =
            new PoolWithInitializer<LinkedListNode<T>, T>(
                () => new LinkedListNode<T>(default(T)),
                node => node.Value = default(T),
                (node, value) => node.Value = value
            );
    }

	/// <summary>
	///     Singleton StringBuilder pool.
	/// </summary>
	public static class StringBuilderPool
    {
	    /// <summary>
	    ///     Singleton StringBuilder pool instance.
	    /// </summary>
	    public static Pool<StringBuilder> Instance { get; } = new Pool<StringBuilder>(
            () => new StringBuilder(),
            sb => sb.Length = 0);
    }
}