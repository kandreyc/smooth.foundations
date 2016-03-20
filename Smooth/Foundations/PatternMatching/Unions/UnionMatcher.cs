using System.Collections.Generic;
using Smooth.Foundations.Algebraics;

namespace Smooth.Foundations.PatternMatching.Unions
{
    public class UnionMatcher<T1, T2, T3>
    {
        private MatchActionSelector<T1> _case1Selector;
        private MatchActionSelector<T2> _case2Selector;
        private MatchActionSelector<T3> _case3Selector;
        private Union<T1, T2, T3> _item;

        public void Case1() { }
        public void Case2() { }
        public void Case3() { }
        
    }
}