using System;
using System.Collections.Generic;
using Smooth.Algebraics;
using Smooth.Slinq;

namespace Smooth.Foundations.PatternMatching.Options
{
    public sealed class OfMatcherResult<T, TResult>
    {
        private readonly ResultOptionMatcher<T, TResult> _matcher;
        private readonly Action<Func<Option<T>, bool>, Func<Option<T>, TResult>> _addPredicateAndFunc;
        private readonly List<T> _values = new List<T>(5);

        internal OfMatcherResult(T value, 
                           ResultOptionMatcher<T, TResult> matcher, 
                           Action<Func<Option<T>, bool>, Func<Option<T>, TResult>> addPredicateAndFunc)
        {
            _matcher = matcher;
            _addPredicateAndFunc = addPredicateAndFunc;
            _values.Add(value);
        }
        public OfMatcherResult<T, TResult> Or(T value)
        {
            _values.Add(value);
            return this;
        }

        public ResultOptionMatcher<T, TResult> Do(TResult result) => Do(_ => result);

        public ResultOptionMatcher<T, TResult> Do(Func<T, TResult> func)
        {
            _addPredicateAndFunc(o => o.isSome &&
                _values.Slinq()
                .Any((v, p) => Collections.EqualityComparer<T>.Default.Equals(v, p), o.value),
                option => func(option.value));
            return _matcher;
        }
    }
}