using System;
using Smooth.Delegates;

namespace Smooth.Foundations.Foundations.PatternMatching.ValueOrErrorStructure
{
    public sealed class WhereForValue<T>
    {
        private readonly DelegateFunc<T, bool> _predicate;
        private readonly Action<DelegateFunc<T, bool>, Action<T>> _addPredicateAndAction;
        private readonly ValueOrErrorMatcher<T> _matcher;
        private readonly bool _isUseless;

        public static WhereForValue<T> Useless(ValueOrErrorMatcher<T> matcher)
        {
            return new WhereForValue<T>(null, null, matcher, true);
        }

        internal WhereForValue(DelegateFunc<T, bool> predicate,
            Action<DelegateFunc<T, bool>, Action<T>> addPredicateAndAction,
            ValueOrErrorMatcher<T> matcher, bool isUseless = false)
        {
            _predicate = predicate;
            _addPredicateAndAction = addPredicateAndAction;
            _matcher = matcher;
            _isUseless = isUseless;
        }

        public ValueOrErrorMatcher<T> Do(Action<T> action)
        {
            if (!_isUseless)
            {
                _addPredicateAndAction(o => _predicate(o), action);
            }
            return _matcher;
        }
    }
}