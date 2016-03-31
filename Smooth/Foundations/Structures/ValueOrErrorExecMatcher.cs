using System;
using Smooth.Delegates;
using Smooth.Foundations.PatternMatching;
using Smooth.Foundations.PatternMatching.Options;

namespace Smooth.Foundations.Foundations.Structures
{
    public class ValueOrErrorExecMatcher<T1>
    {
        private readonly ValueOrErrorMatchActionSelector<T1> _actionSelector;
        private readonly ValueOrError<T1> _item;

        internal ValueOrErrorExecMatcher(ValueOrError<T1> item)
        {
            _item = item;
            _actionSelector = new ValueOrErrorMatchActionSelector<T1>(
               () => { throw new NoMatchException($"No match action exists for value of {_item}"); });
        }

        public ValueMatcher<T1> Value() => new ValueMatcher<T1>(this, 
            _actionSelector.AddPredicateAndAction,
            _actionSelector.SetDefaultOnValueAction);
        public ErrorMatcher<T1> Error() => new ErrorMatcher<T1>(this, _actionSelector.AddErrorAction);
        public void Exec() => _actionSelector.InvokeMatchedOrDefaultAction(_item);
    }
}
