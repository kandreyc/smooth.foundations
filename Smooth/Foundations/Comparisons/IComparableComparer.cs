﻿using System;
using Smooth.Collections;

namespace Smooth.Comparisons
{
	/// <summary>
	///     Allocation free sort order comparer for type T where T implements IComparable
	///     <T>
	///         .
	///         Only useful to circumvent potential JIT exceptions on platforms without JIT compilation.
	/// </summary>
	public class IComparableComparer<T> : Comparer<T> where T : IComparable<T>
    {
        public override int Compare(T l, T r)
        {
            return l.CompareTo(r);
        }
    }
}