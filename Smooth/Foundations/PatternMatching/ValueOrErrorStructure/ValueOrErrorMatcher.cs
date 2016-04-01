using Smooth.Foundations.PatternMatching;

namespace Smooth.Foundations.Foundations.PatternMatching.ValueOrErrorStructure
{
    public class ValueOrErrorMatcher<T1>
    {
        private readonly ValueOrErrorMatchActionSelector<T1> _actionSelector;
        private readonly ValueOrError<T1> _item;

        internal ValueOrErrorMatcher(ValueOrError<T1> item)
        {
            _item = item;
            _actionSelector = new ValueOrErrorMatchActionSelector<T1>(
                () => { throw new NoMatchException($"No match action exists for value of {_item}"); });
        }

        public ValueMatcher<T1> Value() => new ValueMatcher<T1>(this,
            _actionSelector.AddPredicateAndAction,
            _actionSelector.SetDefaultOnValueAction,
            _item.IsError);

        public ErrorMatcher<T1> Error() => new ErrorMatcher<T1>(this, _actionSelector.AddErrorAction, _item.IsError);
        public void Exec() => _actionSelector.InvokeMatchedOrDefaultAction(_item);

    }
}