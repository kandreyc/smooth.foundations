using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smooth.Delegates;
using Smooth.Foundations.PatternMatching;

namespace Smooth.Foundations.Foundations.PatternMatching.ValueOrErrorStructure
{
  public  class ValueOrErrorResultMatcher<T1, TResult>
    {
        private readonly ValueOrErrorMatchFunctionSelector<T1, TResult> _functionSelector;
        private readonly ValueOrError<T1> _item;

        internal ValueOrErrorResultMatcher(ValueOrError<T1> item)
        {
            _item = item;
            _functionSelector = new ValueOrErrorMatchFunctionSelector<T1, TResult>(
                x => { throw new NoMatchException($"No match action exists for value of {_item}"); }, item.IsError);
        }

//        public WithForValueOrErrorHandler<ValueOrErrorResultMatcher<T1, TResult>, T1, TResult> With(T1 value) =>
//            new WithForValueOrErrorHandler<ValueOrErrorResultMatcher<T1, TResult>, T1, TResult>(value, RecordAction, this);


      public ValueOrError<TResult> Result() =>
          
            _functionSelector.DetermineResultUsingDefaultIfRequired(_item);

        private void RecordAction(DelegateFunc<T1, bool> test, DelegateFunc<T1, TResult> action) =>
            _functionSelector.AddPredicateAndAction(test, action);
    }
}
