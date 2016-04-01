using System;
using Smooth.Delegates;

namespace Smooth.Foundations.Foundations.PatternMatching.ValueOrErrorStructure
{
    public sealed class ValueMatcher<T>
    {
        private readonly Action<DelegateFunc<T, bool>, Action<T>> _addPredicateAndAction;
        private readonly Action<Action<T>> _addDefaultValueAction;
        private readonly ValueOrErrorMatcher<T> _matcher;
        private readonly bool _isError;

        public ValueMatcher(ValueOrErrorMatcher<T> matcher,
            Action<DelegateFunc<T, bool>, Action<T>> addPredicateAndAction,
            Action<Action<T>> addAddDefaultValueAction,
            bool isError)
        {
            _addDefaultValueAction = addAddDefaultValueAction;
            _matcher = matcher;
            _addPredicateAndAction = addPredicateAndAction;
            _isError = isError;
        }

        public WhereForValue<T> Where(DelegateFunc<T, bool> predicate) =>
            _isError
                ? WhereForValue<T>.Useless(_matcher)
                : new WhereForValue<T>(predicate, _addPredicateAndAction, _matcher);

        public ValueOrErrorMatcher<T> Do(Action<T> action)
        {
            _addDefaultValueAction(action);
            return _matcher;
        }
    }
}