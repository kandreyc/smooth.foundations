using System;
using Smooth.Algebraics;

namespace Smooth.Foundations.PatternMatching
{
    public sealed class ResultMatcherWithElse<T1, TResult>
    {
        private readonly MatchFunctionSelector<T1, TResult> _selector;
        private readonly Func<T1, TResult> _elseAction;
        private readonly T1 _value;

        internal ResultMatcherWithElse(MatchFunctionSelector<T1, TResult> selector, Func<T1, TResult> elseAction, T1 value)
        {
            _selector = selector;
            _elseAction = elseAction;
            _value = value;
        }

        public TResult Result()
        {
            var matchedResult = _selector.DetermineResult(_value);

            return matchedResult
                .Match<TResult, TResult>()
                .Some().Do(x => x)
                .None().Do(() => _elseAction(_value))
                .Result();
        }
    }

    public sealed class ResultMatcherWithElse<T1, T2, TResult>
    {
        private readonly MatchFunctionSelector<T1, T2, TResult> _selector;
        private readonly Func<T1, T2, TResult> _elseAction;
        private readonly Tuple<T1, T2> _value;

        internal ResultMatcherWithElse(MatchFunctionSelector<T1, T2, TResult> selector,
                                       Func<T1, T2, TResult> elseAction,
                                       Tuple<T1, T2> value)
        {
            _selector = selector;
            _elseAction = elseAction;
            _value = value;
        }

        public TResult Result()
        {
            var matchedResult = _selector.DetermineResult(_value);

            return matchedResult
                .Match<TResult, TResult>()
                .Some().Do(x => x)
                .None().Do(() => _elseAction(_value.Item1, _value.Item2))
                .Result();
        }
    }

    public sealed class ResultMatcherWithElse<T1, T2, T3, TResult>
    {
        private readonly MatchFunctionSelector<T1, T2, T3, TResult> _selector;
        private readonly Func<T1, T2, T3, TResult> _elseAction;
        private readonly Tuple<T1, T2, T3> _value;

        internal ResultMatcherWithElse(MatchFunctionSelector<T1, T2, T3, TResult> selector,
                                       Func<T1, T2, T3, TResult> elseAction,
                                       Tuple<T1, T2, T3> value)
        {
            _selector = selector;
            _elseAction = elseAction;
            _value = value;
        }

        public TResult Result()
        {
            var matchedResult = _selector.DetermineResult(_value);

            return matchedResult.Match<TResult, TResult>()
                                .Some().Do(x => x)
                                .None().Do(() => _elseAction(_value.Item1, _value.Item2, _value.Item3))
                                .Result();
        }
    }

    public sealed class ResultMatcherWithElse<T1, T2, T3, T4, TResult>
    {
        private readonly MatchFunctionSelector<T1, T2, T3, T4, TResult> _selector;
        private readonly Func<T1, T2, T3, T4, TResult> _elseAction;
        private readonly Tuple<T1, T2, T3, T4> _value;

        internal ResultMatcherWithElse(MatchFunctionSelector<T1, T2, T3, T4, TResult> selector,
                                       Func<T1, T2, T3, T4, TResult> elseAction,
                                       Tuple<T1, T2, T3, T4> value)
        {
            _selector = selector;
            _elseAction = elseAction;
            _value = value;
        }

        public TResult Result()
        {
            var matchedResult = _selector.DetermineResult(_value);

            return matchedResult.Match<TResult, TResult>()
                                .Some().Do(x => x)
                                .None().Do(() => _elseAction(_value.Item1, _value.Item2, _value.Item3, _value.Item4))
                                .Result();
        }
    }

}