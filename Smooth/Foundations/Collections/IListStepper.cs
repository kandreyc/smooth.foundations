using System;
using System.Collections;
using System.Collections.Generic;
using Smooth.Algebraics;

namespace Smooth.Collections
{
	/// <summary>
	///     Helper class for enuemrating the elements of an IList<T> using a start index and step value.
	/// </summary>
	public class IListStepper<T> : IEnumerable<T>
    {
        private readonly IList<T> list;
        private readonly int startIndex;
        private readonly int step;

        private IListStepper()
        {
        }

        public IListStepper(IList<T> list, int startIndex, int step)
        {
            this.list = list;
            this.startIndex = startIndex;
            this.step = step;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = startIndex; 0 <= i && i < list.Count; i += step) yield return list[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

	/// <summary>
	///     Helper class for enuemrating the element, index pairs of an IList<T> using a start index and step value.
	/// </summary>
	public class IListStepperWithIndex<T> : IEnumerable<ValueTuple<T, int>>
    {
        private readonly IList<T> list;
        private readonly int startIndex;
        private readonly int step;

        private IListStepperWithIndex()
        {
        }

        public IListStepperWithIndex(IList<T> list, int startIndex, int step)
        {
            this.list = list;
            this.startIndex = startIndex;
            this.step = step;
        }

        public IEnumerator<ValueTuple<T, int>> GetEnumerator()
        {
            for (var i = startIndex; 0 <= i && i < list.Count; i += step) yield return new ValueTuple<T, int>(list[i], i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}