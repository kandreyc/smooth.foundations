﻿using System;
using Smooth.Algebraics;
using Smooth.Delegates;

namespace Smooth.Foundations.PatternMatching
{
    public sealed class ResultMatcher<T1, TResult>
    {
        private readonly MatchFunctionSelector<T1, TResult> _functionSelector;
        private readonly T1 _item;

        internal ResultMatcher(T1 item)
        {
            _item = item;
            _functionSelector = new MatchFunctionSelector<T1, TResult>(
                x => { throw new NoMatchException($"No match action exists for value of {_item}"); });
        }

        public WithForFuncHandler<ResultMatcher<T1, TResult>, T1, TResult> With(T1 value)
        {
            return new WithForFuncHandler<ResultMatcher<T1, TResult>, T1, TResult>(value, RecordAction, this);
        }

        public WhereForFuncHandler<ResultMatcher<T1, TResult>, T1, TResult> Where(DelegateFunc<T1, bool> expression)
        {
            return new WhereForFuncHandler<ResultMatcher<T1, TResult>, T1, TResult>(expression, RecordAction, this);
        }

        public ResultMatcherWithElse<T1, TResult> Else(DelegateFunc<T1, TResult> action)
        {
            return new ResultMatcherWithElse<T1, TResult>(_functionSelector, action, _item);
        }

        public ResultMatcherWithElse<T1, TResult> Else(TResult result)
        {
            return new ResultMatcherWithElse<T1, TResult>(_functionSelector, x => result, _item);
        }

        public TResult Result()
        {
            return _functionSelector.DetermineResultUsingDefaultIfRequired(_item);
        }

        private void RecordAction(DelegateFunc<T1, bool> test, DelegateFunc<T1, TResult> action)
        {
            _functionSelector.AddPredicateAndAction(test, action);
        }
    }

    public sealed class ResultMatcher<T1, T2, TResult>
    {
        private readonly MatchFunctionSelector<T1, T2, TResult> _functionSelector;
        private readonly Tuple<T1, T2> _item;

        internal ResultMatcher(Tuple<T1, T2> item)
        {
            _item = item;
            _functionSelector = new MatchFunctionSelector<T1, T2, TResult>((x, y) =>
            {
                throw new NoMatchException($"No match action exists for value of ({_item.Item1}, {_item.Item2}");
            });
        }

        public WithForFuncHandler<ResultMatcher<T1, T2, TResult>, T1, T2, TResult> With(T1 value1, T2 value2)
        {
            return new WithForFuncHandler<ResultMatcher<T1, T2, TResult>, T1, T2, TResult>(Tuple.Create(value1, value2),
                RecordAction,
                this);
        }

        public WhereForFuncHandler<ResultMatcher<T1, T2, TResult>, T1, T2, TResult> Where(
            DelegateFunc<T1, T2, bool> expression)
        {
            return new WhereForFuncHandler<ResultMatcher<T1, T2, TResult>, T1, T2, TResult>(expression,
                RecordAction,
                this);
        }

        private void RecordAction(DelegateFunc<T1, T2, bool> test, DelegateFunc<T1, T2, TResult> action)
        {
            _functionSelector.AddTestAndAction(test, action);
        }

        public ResultMatcherWithElse<T1, T2, TResult> Else(DelegateFunc<T1, T2, TResult> action)
        {
            return new ResultMatcherWithElse<T1, T2, TResult>(_functionSelector, action, _item);
        }

        public ResultMatcherWithElse<T1, T2, TResult> Else(TResult result)
        {
            return new ResultMatcherWithElse<T1, T2, TResult>(_functionSelector, (x, y) => result, _item);
        }

        public TResult Result()
        {
            return _functionSelector.DetermineResultUsingDefaultIfRequired(_item);
        }
    }

    public sealed class ResultMatcher<T1, T2, T3, TResult>
    {
        private readonly MatchFunctionSelector<T1, T2, T3, TResult> _functionSelector;
        private readonly Tuple<T1, T2, T3> _item;

        internal ResultMatcher(Tuple<T1, T2, T3> item)
        {
            _item = item;
            _functionSelector = new MatchFunctionSelector<T1, T2, T3, TResult>((x, y, z) =>
            {
                throw new NoMatchException(
                    $"No match action exists for value of ({_item.Item1}, {_item.Item2}, {_item.Item3})");
            });
        }

        public WithForFuncHandler<ResultMatcher<T1, T2, T3, TResult>, T1, T2, T3, TResult> With(T1 value1, T2 value2,
            T3 value3)
        {
            return new WithForFuncHandler<ResultMatcher<T1, T2, T3, TResult>, T1, T2, T3, TResult>(
                Tuple.Create(value1, value2, value3), RecordAction, this);
        }

        public WhereForFuncHandler<ResultMatcher<T1, T2, T3, TResult>, T1, T2, T3, TResult> Where(
            DelegateFunc<T1, T2, T3, bool> expression)
        {
            return new WhereForFuncHandler<ResultMatcher<T1, T2, T3, TResult>, T1, T2, T3, TResult>(expression,
                RecordAction,
                this);
        }

        private void RecordAction(DelegateFunc<T1, T2, T3, bool> test, DelegateFunc<T1, T2, T3, TResult> action)
        {
            _functionSelector.AddTestAndAction(test, action);
        }

        public ResultMatcherWithElse<T1, T2, T3, TResult> Else(DelegateFunc<T1, T2, T3, TResult> action)
        {
            return new ResultMatcherWithElse<T1, T2, T3, TResult>(_functionSelector, action, _item);
        }

        public ResultMatcherWithElse<T1, T2, T3, TResult> Else(TResult result)
        {
            return new ResultMatcherWithElse<T1, T2, T3, TResult>(_functionSelector, (x, y, z) => result, _item);
        }

        public TResult Result()
        {
            return _functionSelector.DetermineResultUsingDefaultIfRequired(_item);
        }
    }

    public sealed class ResultMatcher<T1, T2, T3, T4, TResult>
    {
        private readonly MatchFunctionSelector<T1, T2, T3, T4, TResult> _functionSelector;
        private readonly Tuple<T1, T2, T3, T4> _item;

        internal ResultMatcher(Tuple<T1, T2, T3, T4> item)
        {
            _item = item;
            _functionSelector = new MatchFunctionSelector<T1, T2, T3, T4, TResult>(
                (w, x, y, z) =>
                {
                    throw new NoMatchException(
                        $"No match action exists for value of ({_item.Item1}, {_item.Item2}, {_item.Item3})");
                });
        }

        public WithForFuncHandler<ResultMatcher<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>
            With(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            return new WithForFuncHandler<ResultMatcher<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>(
                Tuple.Create(value1, value2, value3, value4),
                RecordAction,
                this);
        }

        public WhereForFuncHandler<ResultMatcher<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>
            Where(DelegateFunc<T1, T2, T3, T4, bool> expression)
        {
            return new WhereForFuncHandler<ResultMatcher<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>(expression,
                RecordAction,
                this);
        }

        private void RecordAction(DelegateFunc<T1, T2, T3, T4, bool> test, DelegateFunc<T1, T2, T3, T4, TResult> action)
        {
            _functionSelector.AddTestAndAction(test, action);
        }

        public ResultMatcherWithElse<T1, T2, T3, T4, TResult> Else(DelegateFunc<T1, T2, T3, T4, TResult> action)
        {
            return new ResultMatcherWithElse<T1, T2, T3, T4, TResult>(_functionSelector, action, _item);
        }

        public ResultMatcherWithElse<T1, T2, T3, T4, TResult> Else(TResult result)
        {
            return new ResultMatcherWithElse<T1, T2, T3, T4, TResult>(_functionSelector, (w, x, y, z) => result, _item);
        }

        public TResult Result()
        {
            return _functionSelector.DetermineResultUsingDefaultIfRequired(_item);
        }
    }
}