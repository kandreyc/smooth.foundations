using System;
using Smooth.Delegates;

namespace Smooth.Foundations.Foundations.Structures
{
    public sealed class ValueMatcher<T>
    {
        private readonly Action<DelegateFunc<T, bool>, Action<T>> _addPredicateAndAction;
        private readonly Action<Action<T>> _addDefaultValueAction;
        private readonly ValueOrErrorExecMatcher<T> _matcher;

        public ValueMatcher(ValueOrErrorExecMatcher<T> matcher,
            Action<DelegateFunc<T, bool>, Action<T>> addPredicateAndAction,
            Action<Action<T>> addAddDefaultValueAction)
        {
            _addDefaultValueAction = addAddDefaultValueAction;
            _matcher = matcher;
            _addPredicateAndAction = addPredicateAndAction;
        }

        public WhereForValueOrError<T> Where(DelegateFunc<T, bool> predicate) =>
            new WhereForValueOrError<T>(predicate, _addPredicateAndAction, _matcher);

        public ValueOrErrorExecMatcher<T> Do(Action<T> action)
        {
            _addDefaultValueAction(action);
            return _matcher;
        }
    }
}