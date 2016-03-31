using System;
using Smooth.Algebraics;
using Smooth.Delegates;

namespace Smooth.Foundations.Foundations.Structures
{
    public class ErrorMatcher<T>
    {
        private readonly Action<Action<string>> _addAction;
        private readonly ValueOrErrorExecMatcher<T> _matcher;

        public ErrorMatcher(ValueOrErrorExecMatcher<T> matcher,
            Action<Action<string>> addAction)
        {
            _addAction = addAction;
            _matcher = matcher;
        }

        public ValueOrErrorExecMatcher<T> Do(Action<string> action)
        {
            _addAction(action);
            return _matcher;
        }
    }
}