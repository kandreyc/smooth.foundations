using System;
using Smooth.Algebraics;
using Smooth.Delegates;

namespace Smooth.Foundations.PatternMatching.Options
{
    public sealed class WhereForOption<T>
    {
        private readonly Action<DelegateFunc<Option<T>, bool>, Action<T>> _addPredicateAndAction;
        private readonly OptionMatcher<T> _matcher;
        private readonly DelegateFunc<T, bool> _predicate;

        internal WhereForOption(DelegateFunc<T, bool> predicate,
            Action<DelegateFunc<Option<T>, bool>, Action<T>> addPredicateAndAction,
            OptionMatcher<T> matcher)
        {
            _predicate = predicate;
            _addPredicateAndAction = addPredicateAndAction;
            _matcher = matcher;
        }

        public OptionMatcher<T> Do(Action<T> action)
        {
            _addPredicateAndAction(o => o.isSome && _predicate(o.value), action);
            return _matcher;
        }
    }
}