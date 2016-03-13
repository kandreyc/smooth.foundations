using Smooth.Algebraics;

namespace Smooth.Foundations.PatternMatching
{
    public class EitherMatcher<T1, T2>
    {
        private Either<T1, T2> _item;

        public EitherResolver<T1, T2> CaseLeft() => new EitherResolver<T1, T2>(this, item => item.isLeft, _item);

        public EitherResolver<T1, T2> CaseRight() => new EitherResolver<T1, T2>(this, item => item.isRight, _item); 
    }
}