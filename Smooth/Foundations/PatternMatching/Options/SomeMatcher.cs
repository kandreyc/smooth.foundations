﻿using System;
using Smooth.Algebraics;
using Smooth.Delegates;

namespace Smooth.Foundations.PatternMatching.Options
{
    public sealed class SomeMatcher<T>
    {
        private readonly Action<DelegateFunc<Option<T>, bool>, Action<T>> _addPredicateAndAction;
        private readonly OptionMatcher<T> _matcher;

        public SomeMatcher(OptionMatcher<T> matcher,
            Action<DelegateFunc<Option<T>, bool>, Action<T>> addPredicateAndAction)
        {
            _matcher = matcher;
            _addPredicateAndAction = addPredicateAndAction;
        }

        public OfMatcher<T> Of(T value)
        {
            return new OfMatcher<T>(value, _matcher, _addPredicateAndAction);
        }

        public WhereForOption<T> Where(DelegateFunc<T, bool> predicate)
        {
            return new WhereForOption<T>(predicate, _addPredicateAndAction, _matcher);
        }

        public OptionMatcher<T> Do(Action<T> action)
        {
            _addPredicateAndAction(o => o.isSome, action);
            return _matcher;
        }
    }
}