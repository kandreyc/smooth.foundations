﻿using Smooth.Delegates;

namespace Smooth.Foundations.PatternMatching.Options
{
    public sealed class SomeMatcherResult<T, TResult>
    {
        private readonly ResultOptionMatcher<T, TResult> _matcher;
        private readonly FuncSelectorForOption<T, TResult> _predicateAndResultManager;

        internal SomeMatcherResult(ResultOptionMatcher<T, TResult> matcher,
            FuncSelectorForOption<T, TResult> predicateAndResultManager)
        {
            _matcher = matcher;
            _predicateAndResultManager = predicateAndResultManager;
        }

        public OfMatcherResult<T, TResult> Of(T value)
        {
            return new OfMatcherResult<T, TResult>(value, _matcher, _predicateAndResultManager);
        }

        public WhereForOptionResult<T, TResult> Where(DelegateFunc<T, bool> predicate)
        {
            return new WhereForOptionResult<T, TResult>(predicate, _predicateAndResultManager, _matcher);
        }

        public ResultOptionMatcher<T, TResult> Do(DelegateFunc<T, TResult> func)
        {
            _predicateAndResultManager.AddPredicateAndValueFunc(o => o.isSome, func);
            return _matcher;
        }

        public ResultOptionMatcher<T, TResult> Do(TResult result)
        {
            _predicateAndResultManager.AddPredicateAndResult(o => o.isSome, result);
            return _matcher;
        }
    }
}