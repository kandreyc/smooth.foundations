using System;
using Smooth.Algebraics;

namespace Smooth.Foundations.PatternMatching.Options
{
    public sealed class WhereForOptionResult<T, TResult>
    {
        private readonly Func<T, bool> _predicate;
        private readonly Action<Func<Option<T>, bool>, Func<Option<T>, TResult>> _addPredicateAndFunc;
        private readonly ResultOptionMatcher<T, TResult> _matcher;

        internal WhereForOptionResult(Func<T, bool> predicate,
                                Action<Func<Option<T>, bool>, Func<Option<T>, TResult>> addPredicateAndFunc,
                                ResultOptionMatcher<T, TResult> matcher)
        {
            _predicate = predicate;
            _addPredicateAndFunc = addPredicateAndFunc;
            _matcher = matcher;
        }

        public ResultOptionMatcher<T, TResult> Do(TResult result) => Do(_ => result); 

        public ResultOptionMatcher<T, TResult> Do(Func<T, TResult> func)
        {
            _addPredicateAndFunc(o => o.isSome && _predicate(o.value), o => func(o.value));
            return _matcher;
        }
    }
}
