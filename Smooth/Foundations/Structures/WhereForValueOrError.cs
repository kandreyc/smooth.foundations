using System;
using Smooth.Delegates;

namespace Smooth.Foundations.Foundations.Structures
{
    public sealed class WhereForValueOrError<T>
    {
        private readonly DelegateFunc<T, bool> _predicate;
        private readonly Action<DelegateFunc<T, bool>, Action<T>> _addPredicateAndAction;
        private readonly ValueOrErrorExecMatcher<T> _matcher;

        internal WhereForValueOrError(DelegateFunc<T, bool> predicate,
            Action<DelegateFunc<T, bool>, Action<T>> addPredicateAndAction,
            ValueOrErrorExecMatcher<T> matcher)
        {
            _predicate = predicate;
            _addPredicateAndAction = addPredicateAndAction;
            _matcher = matcher;
        }

        public ValueOrErrorExecMatcher<T> Do(Action<T> action)
        {
            _addPredicateAndAction(o => _predicate(o), action);
            return _matcher;
        }
    }
}