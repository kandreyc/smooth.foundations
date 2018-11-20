using Smooth.Delegates;

namespace Smooth.Foundations.PatternMatching.ValueOrError.Action
{
    public sealed class ValueMatcher<T>
    {
        private readonly DelegateAction<DelegateAction<T>> _addDefaultValueAction;
        private readonly DelegateAction<DelegateFunc<T, bool>, DelegateAction<T>> _addPredicateAndAction;
        private readonly bool _isError;
        private readonly ValueOrErrorMatcher<T> _matcher;

        public ValueMatcher(ValueOrErrorMatcher<T> matcher,
            DelegateAction<DelegateFunc<T, bool>, DelegateAction<T>> addPredicateAndAction,
            DelegateAction<DelegateAction<T>> addAddDefaultValueAction,
            bool isError)
        {
            _addDefaultValueAction = addAddDefaultValueAction;
            _matcher = matcher;
            _addPredicateAndAction = addPredicateAndAction;
            _isError = isError;
        }

        public WhereForValue<T> Where(DelegateFunc<T, bool> predicate)
        {
            return _isError
                ? WhereForValue<T>.Useless(_matcher)
                : new WhereForValue<T>(predicate, _addPredicateAndAction, _matcher);
        }

        public WithForValueActionHandler<T> With(T value)
        {
            return new WithForValueActionHandler<T>(value, _addPredicateAndAction, _matcher, !_isError);
        }

        public ValueOrErrorMatcher<T> Do(DelegateAction<T> action)
        {
            _addDefaultValueAction(action);
            return _matcher;
        }
    }
}