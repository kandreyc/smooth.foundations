﻿using System;
using System.Collections.Generic;
using Smooth.Algebraics;
using Smooth.Delegates;
using Smooth.Slinq;

namespace Smooth.Foundations.PatternMatching.Options
{
    public sealed class OfMatcher<T>
    {
        private readonly Action<DelegateFunc<Option<T>, bool>, Action<T>> _addPredicateAndAction;
        private readonly OptionMatcher<T> _matcher;
        private readonly List<T> _values = new List<T>(5);

        internal OfMatcher(T value, OptionMatcher<T> matcher,
            Action<DelegateFunc<Option<T>, bool>, Action<T>> addPredicateAndAction)
        {
            _matcher = matcher;
            _addPredicateAndAction = addPredicateAndAction;
            _values.Add(value);
        }

        public OfMatcher<T> Or(T value)
        {
            _values.Add(value);
            return this;
        }

        public OptionMatcher<T> Do(Action<T> action)
        {
            _addPredicateAndAction(o => o.isSome &&
                                        _values.Slinq()
                                            .Any((v, p) => Collections.EqualityComparer<T>.Default.Equals(v, p),
                                                o.value),
                action);
            return _matcher;
        }
    }
}