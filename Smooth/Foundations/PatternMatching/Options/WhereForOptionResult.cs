using System;
using Smooth.Delegates;

namespace Smooth.Foundations.PatternMatching.Options
{
    public sealed class WhereForOptionResult<T, TResult>
    {
        private readonly ResultOptionMatcher<T, TResult> _matcher;
        private readonly DelegateFunc<T, bool> _predicate;
        private readonly FuncSelectorForOption<T, TResult> _predicateAndResultManager;

        internal WhereForOptionResult(DelegateFunc<T, bool> predicate,
            FuncSelectorForOption<T, TResult> predicateAndResultManager,
            ResultOptionMatcher<T, TResult> matcher)
        {
            _predicate = predicate;
            _predicateAndResultManager = predicateAndResultManager;
            _matcher = matcher;
        }

        [Obsolete("Please use return")]
        public ResultOptionMatcher<T, TResult> Do(TResult result)
        {
            return Return(result);
        }

        [Obsolete("Please use return")]
        public ResultOptionMatcher<T, TResult> Do(DelegateFunc<T, TResult> func)
        {
            return Return(func);
        }

        public ResultOptionMatcher<T, TResult> Return(TResult result)
        {
            _predicateAndResultManager.AddPredicateAndResult(o => o.isSome && _predicate(o.value), result);
            return _matcher;
        }

        public ResultOptionMatcher<T, TResult> Return(DelegateFunc<T, TResult> func)
        {
            _predicateAndResultManager.AddPredicateAndValueFunc(o => o.isSome && _predicate(o.value), func);
            return _matcher;
        }
    }
}