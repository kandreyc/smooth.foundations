using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smooth.Algebraics;
using Smooth.Delegates;
using Smooth.Foundations.PatternMatching.Options;

namespace Smooth.Foundations.Foundations.Structures
{
    public sealed   class ValueMatcher<T>
    {
        private readonly Action<DelegateFunc<T, bool>, Action<T>> _addPredicateAndAction;
        private readonly ValueOrErrorExecMatcher<T> _matcher;

        public ValueMatcher(ValueOrErrorExecMatcher<T> matcher, Action<DelegateFunc<T, bool>, Action<T>> addPredicateAndAction)
        {
            _matcher = matcher;
            _addPredicateAndAction = addPredicateAndAction;
        }


        public WhereForValueOrError<T> Where(DelegateFunc<T, bool> predicate) =>
            new WhereForValueOrError<T>(predicate, _addPredicateAndAction, _matcher);

        public ValueOrErrorExecMatcher<T> Do(Action<T> action)
        {
            _addPredicateAndAction(o => true, action);//todo remove stub
            return _matcher;
        }
    }
}
