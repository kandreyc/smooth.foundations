using System;
using Smooth.Collections;

namespace Smooth.Algebraics
{
	/// <summary>
	///     Extension methods for Tuple<>s.
	/// </summary>
	public static class Tuple
    {
        public static Tuple<T1> Create<T1>(T1 t1)
        {
            return new Tuple<T1>(t1);
        }

        public static Tuple<T1, T2> Create<T1, T2>(T1 t1, T2 t2)
        {
            return new Tuple<T1, T2>(t1, t2);
        }

        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            return new Tuple<T1, T2, T3>(t1, t2, t3);
        }

        public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return new Tuple<T1, T2, T3, T4>(t1, t2, t3, t4);
        }

        public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return new Tuple<T1, T2, T3, T4, T5>(t1, t2, t3, t4, t5);
        }

        public static Tuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5,
            T6 t6)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6>(t1, t2, t3, t4, t5, t6);
        }

        public static Tuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4,
            T5 t5, T6 t6, T7 t7)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7>(t1, t2, t3, t4, t5, t6, t7);
        }

        public static Tuple<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3,
            T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7, T8>(t1, t2, t3, t4, t5, t6, t7, t8);
        }

        public static Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1, T2 t2,
            T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
    }

	/// <summary>
	///     Struct representing a sequence of one element, aka: a singleton.
	/// </summary>
	[Serializable]
    public struct Tuple<T1> :
        IComparable<Tuple<T1>>,
        IEquatable<Tuple<T1>>
    {
        public readonly T1 Item1;

        public Tuple(T1 Item1)
        {
            this.Item1 = Item1;
        }

        public override bool Equals(object o)
        {
            return o is Tuple<T1> && Equals((Tuple<T1>) o);
        }

        public bool Equals(Tuple<T1> t)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, t.Item1);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = 29 * hash + EqualityComparer<T1>.Default.GetHashCode(Item1);
                return hash;
            }
        }

        public int CompareTo(Tuple<T1> other)
        {
            return Comparer<T1>.Default.Compare(Item1, other.Item1);
        }

        public static bool operator ==(Tuple<T1> lhs, Tuple<T1> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Tuple<T1> lhs, Tuple<T1> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(Tuple<T1> lhs, Tuple<T1> rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Tuple<T1> lhs, Tuple<T1> rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Tuple<T1> lhs, Tuple<T1> rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Tuple<T1> lhs, Tuple<T1> rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return "(" + Item1 + ")";
        }
    }

	/// <summary>
	///     Struct representing a sequence of two elements, aka: an ordered pair.
	/// </summary>
	[Serializable]
    public struct Tuple<T1, T2> :
        IComparable<Tuple<T1, T2>>,
        IEquatable<Tuple<T1, T2>>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;

        public Tuple(T1 Item1, T2 Item2)
        {
            this.Item1 = Item1;
            this.Item2 = Item2;
        }

        public override bool Equals(object o)
        {
            return o is Tuple<T1, T2> && Equals((Tuple<T1, T2>) o);
        }

        public bool Equals(Tuple<T1, T2> t)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, t.Item1) &&
                   EqualityComparer<T2>.Default.Equals(Item2, t.Item2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = 29 * hash + EqualityComparer<T1>.Default.GetHashCode(Item1);
                hash = 29 * hash + EqualityComparer<T2>.Default.GetHashCode(Item2);
                return hash;
            }
        }

        public int CompareTo(Tuple<T1, T2> other)
        {
            int c;
            c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;
            return Comparer<T2>.Default.Compare(Item2, other.Item2);
        }

        public static bool operator ==(Tuple<T1, T2> lhs, Tuple<T1, T2> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Tuple<T1, T2> lhs, Tuple<T1, T2> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(Tuple<T1, T2> lhs, Tuple<T1, T2> rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Tuple<T1, T2> lhs, Tuple<T1, T2> rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Tuple<T1, T2> lhs, Tuple<T1, T2> rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Tuple<T1, T2> lhs, Tuple<T1, T2> rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return "(" + Item1 + ", " + Item2 + ")";
        }
    }

	/// <summary>
	///     Struct representing a sequence of three elements, aka: an ordered triplet.
	/// </summary>
	[Serializable]
    public struct Tuple<T1, T2, T3> :
        IComparable<Tuple<T1, T2, T3>>,
        IEquatable<Tuple<T1, T2, T3>>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;

        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public override bool Equals(object o)
        {
            return o is Tuple<T1, T2, T3> && Equals((Tuple<T1, T2, T3>) o);
        }

        public bool Equals(Tuple<T1, T2, T3> t)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, t.Item1) &&
                   EqualityComparer<T2>.Default.Equals(Item2, t.Item2) &&
                   EqualityComparer<T3>.Default.Equals(Item3, t.Item3);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = 29 * hash + EqualityComparer<T1>.Default.GetHashCode(Item1);
                hash = 29 * hash + EqualityComparer<T2>.Default.GetHashCode(Item2);
                hash = 29 * hash + EqualityComparer<T3>.Default.GetHashCode(Item3);
                return hash;
            }
        }

        public int CompareTo(Tuple<T1, T2, T3> other)
        {
            int c;
            c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;
            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;
            return Comparer<T3>.Default.Compare(Item3, other.Item3);
        }

        public static bool operator ==(Tuple<T1, T2, T3> lhs, Tuple<T1, T2, T3> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Tuple<T1, T2, T3> lhs, Tuple<T1, T2, T3> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(Tuple<T1, T2, T3> lhs, Tuple<T1, T2, T3> rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Tuple<T1, T2, T3> lhs, Tuple<T1, T2, T3> rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Tuple<T1, T2, T3> lhs, Tuple<T1, T2, T3> rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Tuple<T1, T2, T3> lhs, Tuple<T1, T2, T3> rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return "(" + Item1 + ", " + Item2 + ", " + Item3 + ")";
        }
    }

	/// <summary>
	///     Struct representing a sequence of four elements.
	/// </summary>
	[Serializable]
    public struct Tuple<T1, T2, T3, T4> :
        IComparable<Tuple<T1, T2, T3, T4>>,
        IEquatable<Tuple<T1, T2, T3, T4>>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }

        public override bool Equals(object o)
        {
            return o is Tuple<T1, T2, T3, T4> && Equals((Tuple<T1, T2, T3, T4>) o);
        }

        public bool Equals(Tuple<T1, T2, T3, T4> t)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, t.Item1) &&
                   EqualityComparer<T2>.Default.Equals(Item2, t.Item2) &&
                   EqualityComparer<T3>.Default.Equals(Item3, t.Item3) &&
                   EqualityComparer<T4>.Default.Equals(Item4, t.Item4);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = 29 * hash + EqualityComparer<T1>.Default.GetHashCode(Item1);
                hash = 29 * hash + EqualityComparer<T2>.Default.GetHashCode(Item2);
                hash = 29 * hash + EqualityComparer<T3>.Default.GetHashCode(Item3);
                hash = 29 * hash + EqualityComparer<T4>.Default.GetHashCode(Item4);
                return hash;
            }
        }

        public int CompareTo(Tuple<T1, T2, T3, T4> other)
        {
            int c;
            c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;
            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;
            c = Comparer<T3>.Default.Compare(Item3, other.Item3);
            if (c != 0) return c;
            return Comparer<T4>.Default.Compare(Item4, other.Item4);
        }

        public static bool operator ==(Tuple<T1, T2, T3, T4> lhs, Tuple<T1, T2, T3, T4> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Tuple<T1, T2, T3, T4> lhs, Tuple<T1, T2, T3, T4> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(Tuple<T1, T2, T3, T4> lhs, Tuple<T1, T2, T3, T4> rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Tuple<T1, T2, T3, T4> lhs, Tuple<T1, T2, T3, T4> rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Tuple<T1, T2, T3, T4> lhs, Tuple<T1, T2, T3, T4> rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Tuple<T1, T2, T3, T4> lhs, Tuple<T1, T2, T3, T4> rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return "(" + Item1 + ", " + Item2 + ", " + Item3 + ", " + Item4 + ")";
        }
    }

	/// <summary>
	///     Struct representing a sequence of five elements.
	/// </summary>
	[Serializable]
    public struct Tuple<T1, T2, T3, T4, T5> :
        IComparable<Tuple<T1, T2, T3, T4, T5>>,
        IEquatable<Tuple<T1, T2, T3, T4, T5>>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;

        public Tuple(T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5)
        {
            this.Item1 = Item1;
            this.Item2 = Item2;
            this.Item3 = Item3;
            this.Item4 = Item4;
            this.Item5 = Item5;
        }

        public override bool Equals(object o)
        {
            return o is Tuple<T1, T2, T3, T4, T5> && Equals((Tuple<T1, T2, T3, T4, T5>) o);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5> t)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, t.Item1) &&
                   EqualityComparer<T2>.Default.Equals(Item2, t.Item2) &&
                   EqualityComparer<T3>.Default.Equals(Item3, t.Item3) &&
                   EqualityComparer<T4>.Default.Equals(Item4, t.Item4) &&
                   EqualityComparer<T5>.Default.Equals(Item5, t.Item5);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = 29 * hash + EqualityComparer<T1>.Default.GetHashCode(Item1);
                hash = 29 * hash + EqualityComparer<T2>.Default.GetHashCode(Item2);
                hash = 29 * hash + EqualityComparer<T3>.Default.GetHashCode(Item3);
                hash = 29 * hash + EqualityComparer<T4>.Default.GetHashCode(Item4);
                hash = 29 * hash + EqualityComparer<T5>.Default.GetHashCode(Item5);
                return hash;
            }
        }

        public int CompareTo(Tuple<T1, T2, T3, T4, T5> other)
        {
            int c;
            c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;
            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;
            c = Comparer<T3>.Default.Compare(Item3, other.Item3);
            if (c != 0) return c;
            c = Comparer<T4>.Default.Compare(Item4, other.Item4);
            if (c != 0) return c;
            return Comparer<T5>.Default.Compare(Item5, other.Item5);
        }

        public static bool operator ==(Tuple<T1, T2, T3, T4, T5> lhs, Tuple<T1, T2, T3, T4, T5> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Tuple<T1, T2, T3, T4, T5> lhs, Tuple<T1, T2, T3, T4, T5> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(Tuple<T1, T2, T3, T4, T5> lhs, Tuple<T1, T2, T3, T4, T5> rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Tuple<T1, T2, T3, T4, T5> lhs, Tuple<T1, T2, T3, T4, T5> rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Tuple<T1, T2, T3, T4, T5> lhs, Tuple<T1, T2, T3, T4, T5> rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Tuple<T1, T2, T3, T4, T5> lhs, Tuple<T1, T2, T3, T4, T5> rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return "(" + Item1 + ", " + Item2 + ", " + Item3 + ", " + Item4 + ", " + Item5 + ")";
        }
    }

	/// <summary>
	///     Struct representing a sequence of six elements.
	/// </summary>
	[Serializable]
    public struct Tuple<T1, T2, T3, T4, T5, T6> :
        IComparable<Tuple<T1, T2, T3, T4, T5, T6>>,
        IEquatable<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;
        public readonly T6 Item6;

        public Tuple(T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6)
        {
            this.Item1 = Item1;
            this.Item2 = Item2;
            this.Item3 = Item3;
            this.Item4 = Item4;
            this.Item5 = Item5;
            this.Item6 = Item6;
        }

        public override bool Equals(object o)
        {
            return o is Tuple<T1, T2, T3, T4, T5, T6> && Equals((Tuple<T1, T2, T3, T4, T5, T6>) o);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5, T6> t)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, t.Item1) &&
                   EqualityComparer<T2>.Default.Equals(Item2, t.Item2) &&
                   EqualityComparer<T3>.Default.Equals(Item3, t.Item3) &&
                   EqualityComparer<T4>.Default.Equals(Item4, t.Item4) &&
                   EqualityComparer<T5>.Default.Equals(Item5, t.Item5) &&
                   EqualityComparer<T6>.Default.Equals(Item6, t.Item6);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = 29 * hash + EqualityComparer<T1>.Default.GetHashCode(Item1);
                hash = 29 * hash + EqualityComparer<T2>.Default.GetHashCode(Item2);
                hash = 29 * hash + EqualityComparer<T3>.Default.GetHashCode(Item3);
                hash = 29 * hash + EqualityComparer<T4>.Default.GetHashCode(Item4);
                hash = 29 * hash + EqualityComparer<T5>.Default.GetHashCode(Item5);
                hash = 29 * hash + EqualityComparer<T6>.Default.GetHashCode(Item6);
                return hash;
            }
        }

        public int CompareTo(Tuple<T1, T2, T3, T4, T5, T6> other)
        {
            int c;
            c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;
            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;
            c = Comparer<T3>.Default.Compare(Item3, other.Item3);
            if (c != 0) return c;
            c = Comparer<T4>.Default.Compare(Item4, other.Item4);
            if (c != 0) return c;
            c = Comparer<T5>.Default.Compare(Item5, other.Item5);
            if (c != 0) return c;
            return Comparer<T6>.Default.Compare(Item6, other.Item6);
        }

        public static bool operator ==(Tuple<T1, T2, T3, T4, T5, T6> lhs, Tuple<T1, T2, T3, T4, T5, T6> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Tuple<T1, T2, T3, T4, T5, T6> lhs, Tuple<T1, T2, T3, T4, T5, T6> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(Tuple<T1, T2, T3, T4, T5, T6> lhs, Tuple<T1, T2, T3, T4, T5, T6> rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Tuple<T1, T2, T3, T4, T5, T6> lhs, Tuple<T1, T2, T3, T4, T5, T6> rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Tuple<T1, T2, T3, T4, T5, T6> lhs, Tuple<T1, T2, T3, T4, T5, T6> rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Tuple<T1, T2, T3, T4, T5, T6> lhs, Tuple<T1, T2, T3, T4, T5, T6> rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return "(" + Item1 + ", " + Item2 + ", " + Item3 + ", " + Item4 + ", " + Item5 + ", " + Item6 + ")";
        }
    }

	/// <summary>
	///     Struct representing a sequence of seven elements.
	/// </summary>
	[Serializable]
    public struct Tuple<T1, T2, T3, T4, T5, T6, T7> :
        IComparable<Tuple<T1, T2, T3, T4, T5, T6, T7>>,
        IEquatable<Tuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;
        public readonly T6 Item6;
        public readonly T7 Item7;

        public Tuple(T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7)
        {
            this.Item1 = Item1;
            this.Item2 = Item2;
            this.Item3 = Item3;
            this.Item4 = Item4;
            this.Item5 = Item5;
            this.Item6 = Item6;
            this.Item7 = Item7;
        }

        public override bool Equals(object o)
        {
            return o is Tuple<T1, T2, T3, T4, T5, T6, T7> && Equals((Tuple<T1, T2, T3, T4, T5, T6, T7>) o);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5, T6, T7> t)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, t.Item1) &&
                   EqualityComparer<T2>.Default.Equals(Item2, t.Item2) &&
                   EqualityComparer<T3>.Default.Equals(Item3, t.Item3) &&
                   EqualityComparer<T4>.Default.Equals(Item4, t.Item4) &&
                   EqualityComparer<T5>.Default.Equals(Item5, t.Item5) &&
                   EqualityComparer<T6>.Default.Equals(Item6, t.Item6) &&
                   EqualityComparer<T7>.Default.Equals(Item7, t.Item7);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = 29 * hash + EqualityComparer<T1>.Default.GetHashCode(Item1);
                hash = 29 * hash + EqualityComparer<T2>.Default.GetHashCode(Item2);
                hash = 29 * hash + EqualityComparer<T3>.Default.GetHashCode(Item3);
                hash = 29 * hash + EqualityComparer<T4>.Default.GetHashCode(Item4);
                hash = 29 * hash + EqualityComparer<T5>.Default.GetHashCode(Item5);
                hash = 29 * hash + EqualityComparer<T6>.Default.GetHashCode(Item6);
                hash = 29 * hash + EqualityComparer<T7>.Default.GetHashCode(Item7);
                return hash;
            }
        }

        public int CompareTo(Tuple<T1, T2, T3, T4, T5, T6, T7> other)
        {
            int c;
            c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;
            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;
            c = Comparer<T3>.Default.Compare(Item3, other.Item3);
            if (c != 0) return c;
            c = Comparer<T4>.Default.Compare(Item4, other.Item4);
            if (c != 0) return c;
            c = Comparer<T5>.Default.Compare(Item5, other.Item5);
            if (c != 0) return c;
            c = Comparer<T6>.Default.Compare(Item6, other.Item6);
            if (c != 0) return c;
            return Comparer<T7>.Default.Compare(Item7, other.Item7);
        }

        public static bool operator ==(Tuple<T1, T2, T3, T4, T5, T6, T7> lhs, Tuple<T1, T2, T3, T4, T5, T6, T7> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Tuple<T1, T2, T3, T4, T5, T6, T7> lhs, Tuple<T1, T2, T3, T4, T5, T6, T7> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(Tuple<T1, T2, T3, T4, T5, T6, T7> lhs, Tuple<T1, T2, T3, T4, T5, T6, T7> rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Tuple<T1, T2, T3, T4, T5, T6, T7> lhs, Tuple<T1, T2, T3, T4, T5, T6, T7> rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Tuple<T1, T2, T3, T4, T5, T6, T7> lhs, Tuple<T1, T2, T3, T4, T5, T6, T7> rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Tuple<T1, T2, T3, T4, T5, T6, T7> lhs, Tuple<T1, T2, T3, T4, T5, T6, T7> rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return "(" + Item1 + ", " + Item2 + ", " + Item3 + ", " + Item4 + ", " + Item5 + ", " + Item6 + ", " +
                   Item7 + ")";
        }
    }

	/// <summary>
	///     Struct representing a sequence of eight elements.
	/// </summary>
	[Serializable]
    public struct Tuple<T1, T2, T3, T4, T5, T6, T7, T8> :
        IComparable<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>>,
        IEquatable<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;
        public readonly T6 Item6;
        public readonly T7 Item7;
        public readonly T8 Item8;

        public Tuple(T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7, T8 Item8)
        {
            this.Item1 = Item1;
            this.Item2 = Item2;
            this.Item3 = Item3;
            this.Item4 = Item4;
            this.Item5 = Item5;
            this.Item6 = Item6;
            this.Item7 = Item7;
            this.Item8 = Item8;
        }

        public override bool Equals(object o)
        {
            return o is Tuple<T1, T2, T3, T4, T5, T6, T7, T8> && Equals((Tuple<T1, T2, T3, T4, T5, T6, T7, T8>) o);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> t)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, t.Item1) &&
                   EqualityComparer<T2>.Default.Equals(Item2, t.Item2) &&
                   EqualityComparer<T3>.Default.Equals(Item3, t.Item3) &&
                   EqualityComparer<T4>.Default.Equals(Item4, t.Item4) &&
                   EqualityComparer<T5>.Default.Equals(Item5, t.Item5) &&
                   EqualityComparer<T6>.Default.Equals(Item6, t.Item6) &&
                   EqualityComparer<T7>.Default.Equals(Item7, t.Item7) &&
                   EqualityComparer<T8>.Default.Equals(Item8, t.Item8);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = 29 * hash + EqualityComparer<T1>.Default.GetHashCode(Item1);
                hash = 29 * hash + EqualityComparer<T2>.Default.GetHashCode(Item2);
                hash = 29 * hash + EqualityComparer<T3>.Default.GetHashCode(Item3);
                hash = 29 * hash + EqualityComparer<T4>.Default.GetHashCode(Item4);
                hash = 29 * hash + EqualityComparer<T5>.Default.GetHashCode(Item5);
                hash = 29 * hash + EqualityComparer<T6>.Default.GetHashCode(Item6);
                hash = 29 * hash + EqualityComparer<T7>.Default.GetHashCode(Item7);
                hash = 29 * hash + EqualityComparer<T8>.Default.GetHashCode(Item8);
                return hash;
            }
        }

        public int CompareTo(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> other)
        {
            int c;
            c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;
            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;
            c = Comparer<T3>.Default.Compare(Item3, other.Item3);
            if (c != 0) return c;
            c = Comparer<T4>.Default.Compare(Item4, other.Item4);
            if (c != 0) return c;
            c = Comparer<T5>.Default.Compare(Item5, other.Item5);
            if (c != 0) return c;
            c = Comparer<T6>.Default.Compare(Item6, other.Item6);
            if (c != 0) return c;
            c = Comparer<T7>.Default.Compare(Item7, other.Item7);
            if (c != 0) return c;
            return Comparer<T8>.Default.Compare(Item8, other.Item8);
        }

        public static bool operator ==(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8> rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8> rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8> rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8> rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return "(" + Item1 + ", " + Item2 + ", " + Item3 + ", " + Item4 + ", " + Item5 + ", " + Item6 + ", " +
                   Item7 + ", " + Item8 + ")";
        }
    }

	/// <summary>
	///     Struct representing a sequence of nine elements.
	/// </summary>
	[Serializable]
    public struct Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        IComparable<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>>,
        IEquatable<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;
        public readonly T6 Item6;
        public readonly T7 Item7;
        public readonly T8 Item8;
        public readonly T9 Item9;

        public Tuple(T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5, T6 Item6, T7 Item7, T8 Item8, T9 Item9)
        {
            this.Item1 = Item1;
            this.Item2 = Item2;
            this.Item3 = Item3;
            this.Item4 = Item4;
            this.Item5 = Item5;
            this.Item6 = Item6;
            this.Item7 = Item7;
            this.Item8 = Item8;
            this.Item9 = Item9;
        }

        public override bool Equals(object o)
        {
            return o is Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> &&
                   Equals((Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>) o);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> t)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, t.Item1) &&
                   EqualityComparer<T2>.Default.Equals(Item2, t.Item2) &&
                   EqualityComparer<T3>.Default.Equals(Item3, t.Item3) &&
                   EqualityComparer<T4>.Default.Equals(Item4, t.Item4) &&
                   EqualityComparer<T5>.Default.Equals(Item5, t.Item5) &&
                   EqualityComparer<T6>.Default.Equals(Item6, t.Item6) &&
                   EqualityComparer<T7>.Default.Equals(Item7, t.Item7) &&
                   EqualityComparer<T8>.Default.Equals(Item8, t.Item8) &&
                   EqualityComparer<T9>.Default.Equals(Item9, t.Item9);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = 29 * hash + EqualityComparer<T1>.Default.GetHashCode(Item1);
                hash = 29 * hash + EqualityComparer<T2>.Default.GetHashCode(Item2);
                hash = 29 * hash + EqualityComparer<T3>.Default.GetHashCode(Item3);
                hash = 29 * hash + EqualityComparer<T4>.Default.GetHashCode(Item4);
                hash = 29 * hash + EqualityComparer<T5>.Default.GetHashCode(Item5);
                hash = 29 * hash + EqualityComparer<T6>.Default.GetHashCode(Item6);
                hash = 29 * hash + EqualityComparer<T7>.Default.GetHashCode(Item7);
                hash = 29 * hash + EqualityComparer<T8>.Default.GetHashCode(Item8);
                hash = 29 * hash + EqualityComparer<T9>.Default.GetHashCode(Item9);
                return hash;
            }
        }

        public int CompareTo(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> other)
        {
            int c;
            c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;
            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;
            c = Comparer<T3>.Default.Compare(Item3, other.Item3);
            if (c != 0) return c;
            c = Comparer<T4>.Default.Compare(Item4, other.Item4);
            if (c != 0) return c;
            c = Comparer<T5>.Default.Compare(Item5, other.Item5);
            if (c != 0) return c;
            c = Comparer<T6>.Default.Compare(Item6, other.Item6);
            if (c != 0) return c;
            c = Comparer<T7>.Default.Compare(Item7, other.Item7);
            if (c != 0) return c;
            c = Comparer<T8>.Default.Compare(Item8, other.Item8);
            if (c != 0) return c;
            return Comparer<T9>.Default.Compare(Item9, other.Item9);
        }

        public static bool operator ==(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> lhs,
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return "(" + Item1 + ", " + Item2 + ", " + Item3 + ", " + Item4 + ", " + Item5 + ", " + Item6 + ", " +
                   Item7 + ", " + Item8 + ", " + Item9 + ")";
        }
    }
}