using System;

namespace Smooth.Foundations.Foundations.PatternMatching.ValueOrErrorStructure
{
    public class ErrorMatcher<T>
    {
        private readonly Action<Action<string>> _addAction;
        private readonly ValueOrErrorExecMatcher<T> _matcher;
        private readonly bool _isError;

        public ErrorMatcher(ValueOrErrorExecMatcher<T> matcher,
            Action<Action<string>> addAction, bool isError)
        {
            _addAction = addAction;
            _matcher = matcher;
            _isError = isError;
        }

        public ValueOrErrorExecMatcher<T> Do(Action<string> action)
        {
            if (_isError)
            {
                _addAction(action);
            }
            return _matcher;
        }
    }
}