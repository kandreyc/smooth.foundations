using System;
using Smooth.Algebraics;
using UnityEngine;

namespace Smooth.Foundations.PatternMatching
{
    public class EitherResolver<T1, T2>
    {
        private readonly EitherMatcher<T1, T2> _matcher;

        internal EitherResolver(EitherMatcher<T1, T2> matcher, Func<Either<T1, T2>, bool> predicate, Either<T1, T2> item)
        {
            _matcher = matcher;
        }


    }
}