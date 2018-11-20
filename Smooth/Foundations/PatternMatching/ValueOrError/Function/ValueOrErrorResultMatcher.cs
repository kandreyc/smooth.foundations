﻿using Smooth.Delegates;
using Smooth.Foundations.Algebraics;

namespace Smooth.Foundations.PatternMatching.ValueOrError.Function
{
    public struct ValueOrErrorResultMatcher<T, TResult>
    {
        private readonly ValueOrErrorMatchFunctionSelector<T, TResult> _functionSelector;
        private readonly ValueOrError<T> _item;

        internal ValueOrErrorResultMatcher(ValueOrError<T> item)
        {
            _item = item;
            _functionSelector = new ValueOrErrorMatchFunctionSelector<T, TResult>(
                x => { throw new NoMatchException($"No match action exists for value of {item}"); }, item.IsError);
        }

        public WithForValueOrErrorHandler<ValueOrErrorResultMatcher<T, TResult>, T, TResult> With(T value)
        {
            return new WithForValueOrErrorHandler<ValueOrErrorResultMatcher<T, TResult>, T, TResult>(value,
                RecordAction,
                this);
        }

        public WhereForValueOrError<ValueOrErrorResultMatcher<T, TResult>, T, TResult> Where(
            DelegateFunc<T, bool> expression)
        {
            return new WhereForValueOrError<ValueOrErrorResultMatcher<T, TResult>, T, TResult>(expression, RecordAction,
                this);
        }

        public ValueOrErrorResultMatcherWithElse<T, TResult> Else(DelegateFunc<T, TResult> action)
        {
            return new ValueOrErrorResultMatcherWithElse<T, TResult>(_functionSelector, action, _item);
        }

        public ValueOrErrorResultMatcherWithElse<T, TResult> Else(TResult result)
        {
            return new ValueOrErrorResultMatcherWithElse<T, TResult>(_functionSelector, x => result, _item);
        }

        public ValueOrError<TResult> Result()
        {
            return _functionSelector.DetermineResultUsingDefaultIfRequired(_item);
        }

        private void RecordAction(DelegateFunc<T, bool> test, DelegateFunc<T, TResult> action)
        {
            _functionSelector.AddPredicateAndAction(test, action);
        }
    }
}