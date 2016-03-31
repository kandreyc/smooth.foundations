using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smooth.Delegates;

namespace Smooth.Foundations.Foundations.Structures
{
   public class DefaultWhereForValueOrError<T>
    {

        private readonly Action< Action<T>> _addAction;
        private readonly ValueOrErrorExecMatcher<T> _matcher;

        internal DefaultWhereForValueOrError(
            Action<Action<T>> addAction,
            ValueOrErrorExecMatcher<T> matcher)
        {
            _addAction = addAction;
            _matcher = matcher;
        }

        public ValueOrErrorExecMatcher<T> Do(Action<T> action)
        {
            _addAction( action);
            return _matcher;
        }
    }
}
