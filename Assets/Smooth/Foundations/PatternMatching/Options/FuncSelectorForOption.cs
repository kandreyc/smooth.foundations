using System;
using System.Collections.Generic;
using Smooth.Algebraics;
using Smooth.Delegates;
using Smooth.Slinq;

namespace Smooth.Foundations.PatternMatching.Options
{
    internal sealed class FuncSelectorForOption<T, TResult>
    {
        private readonly Func<Option<T>, TResult> _defaultFunc;
        private readonly List<Tuple<Func<Option<T>, bool>, 
            Either<Func<T, TResult>, Func<Option<T>, TResult>>>> _predicatesAndFuncs =
                new List<Tuple<Func<Option<T>, bool>, Either<Func<T, TResult>, Func<Option<T>, TResult>>>>();

        public FuncSelectorForOption(Func<Option<T>, TResult> defaultFunc)
        {
            _defaultFunc = defaultFunc;
        }

        public void AddPredicateAndFunc(Func<Option<T>, bool> predicate, Func<T, TResult> func)
        {
            _predicatesAndFuncs.Add(Tuple.Create(predicate,
                Either<Func<T, TResult>, Func<Option<T>, TResult>>.Left(func)));
        }

        public void AddPredicateAndFunc(Func<Option<T>, bool> predicate, Func<Option<T>, TResult> func)
        {
            _predicatesAndFuncs.Add(Tuple.Create(predicate,
                Either<Func<T, TResult>, Func<Option<T>, TResult>>.Right(func)));
        }

        public TResult GetMatchedOrDefaultResult(Option<T> item)
        {
            return GetMatchedOrProvidedResult(item, _defaultFunc);
        }

        public TResult GetMatchedOrProvidedResult(Option<T> item, Func<Option<T>, TResult> elseFunc)
        {
            return GetMatchedResult(item).ValueOr(elseFunc, item);
        }

        public TResult GetMatchedOrProvidedResult(Option<T> item, TResult result)
        {
            return GetMatchedResult(item).ValueOr(result);
        }

        private Option<TResult> GetMatchedResult(Option<T> item)
        {
            return _predicatesAndFuncs.Slinq()
                .FirstOrNone((pair, v) => pair.Item1(v), item)
                .Select(pair => pair.Item2)
                .Select((func, pItem) => func.isLeft ? func.leftValue(pItem.value) : func.rightValue(pItem), item);
        }

    }
}