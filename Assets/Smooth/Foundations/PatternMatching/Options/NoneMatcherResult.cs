using System;
using Smooth.Algebraics;

namespace Smooth.Foundations.PatternMatching.Options
{
    public sealed class NoneMatcherResult<T, TResult>
    {
        private readonly Action<Func<Option<T>, bool>, Func<Option<T>, TResult>> _addPredicateAndFunc;
        private readonly ResultOptionMatcher<T, TResult> _matcher;

        public NoneMatcherResult(ResultOptionMatcher<T, TResult> matcher,
                           Action<Func<Option<T>, bool>, Func<Option<T>, TResult>> addPredicateAndFunc)
        {
            _addPredicateAndFunc = addPredicateAndFunc;
            _matcher = matcher;
        }

        public ResultOptionMatcher<T, TResult> Do(TResult result) => Do(() => result);

        public ResultOptionMatcher<T, TResult> Do(Func<TResult> result)
        {
            _addPredicateAndFunc(o => o.isNone, o => result());
            return _matcher;
        }
    }
}