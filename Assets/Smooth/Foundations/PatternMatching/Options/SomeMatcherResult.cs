using System;
using Smooth.Algebraics;

namespace Smooth.Foundations.PatternMatching.Options
{
    public sealed class SomeMatcherResult<T, TResult>
    {
        private readonly ResultOptionMatcher<T, TResult> _matcher;
        private readonly Action<Func<Option<T>, bool>, Func<Option<T>, TResult>> _addPredicateAndFunc;

        public SomeMatcherResult(ResultOptionMatcher<T, TResult> matcher, 
            Action<Func<Option<T>, bool>, Func<Option<T>, TResult>> addPredicateAndFunc)
        {
            _matcher = matcher;
            _addPredicateAndFunc = addPredicateAndFunc;
        }

        public OfMatcherResult<T, TResult> Of(T value) => new OfMatcherResult<T, TResult>(value, _matcher, _addPredicateAndFunc);

        public WhereForOptionResult<T, TResult> Where(Func<T, bool> predicate) => 
            new WhereForOptionResult<T, TResult>(predicate, _addPredicateAndFunc, _matcher);

        public ResultOptionMatcher<T, TResult> Do(Func<T, TResult> func)
        {
            _addPredicateAndFunc(o => o.isSome, o => func(o.value));
            return _matcher;
        }

        public ResultOptionMatcher<T, TResult> Do(TResult result)
        {
            _addPredicateAndFunc(o => o.isSome, o => result);
            return _matcher;
        }
    }
}