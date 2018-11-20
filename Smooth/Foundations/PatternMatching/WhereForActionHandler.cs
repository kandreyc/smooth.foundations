using System;
using Smooth.Delegates;

namespace Smooth.Foundations.PatternMatching
{
    public sealed class WhereForActionHandler<TMatcher, T1>
    {
        private readonly DelegateFunc<T1, bool> _expression;
        private readonly TMatcher _matcher;
        private readonly Action<DelegateFunc<T1, bool>, Action<T1>> _recorder;

        internal WhereForActionHandler(DelegateFunc<T1, bool> expression,
            Action<DelegateFunc<T1, bool>, Action<T1>> recorder,
            TMatcher matcher)
        {
            _expression = expression;
            _recorder = recorder;
            _matcher = matcher;
        }

        public TMatcher Do(Action<T1> action)
        {
            _recorder(_expression, action);
            return _matcher;
        }
    }

    public sealed class WhereForActionHandler<TMatcher, T1, T2>
    {
        private readonly DelegateFunc<T1, T2, bool> _expression;
        private readonly TMatcher _matcher;
        private readonly Action<DelegateFunc<T1, T2, bool>, Action<T1, T2>> _recorder;

        internal WhereForActionHandler(DelegateFunc<T1, T2, bool> expression,
            Action<DelegateFunc<T1, T2, bool>, Action<T1, T2>> recorder,
            TMatcher matcher)
        {
            _expression = expression;
            _recorder = recorder;
            _matcher = matcher;
        }

        public TMatcher Do(Action<T1, T2> action)
        {
            _recorder(_expression, action);
            return _matcher;
        }
    }

    public sealed class WhereForActionHandler<TMatcher, T1, T2, T3>
    {
        private readonly DelegateFunc<T1, T2, T3, bool> _expression;
        private readonly TMatcher _matcher;
        private readonly Action<DelegateFunc<T1, T2, T3, bool>, Action<T1, T2, T3>> _recorder;

        internal WhereForActionHandler(DelegateFunc<T1, T2, T3, bool> expression,
            Action<DelegateFunc<T1, T2, T3, bool>, Action<T1, T2, T3>> recorder,
            TMatcher matcher)
        {
            _expression = expression;
            _recorder = recorder;
            _matcher = matcher;
        }

        public TMatcher Do(Action<T1, T2, T3> action)
        {
            _recorder(_expression, action);
            return _matcher;
        }
    }

    public sealed class WhereForActionHandler<TMatcher, T1, T2, T3, T4>
    {
        private readonly DelegateFunc<T1, T2, T3, T4, bool> _expression;
        private readonly TMatcher _matcher;
        private readonly Action<DelegateFunc<T1, T2, T3, T4, bool>, Action<T1, T2, T3, T4>> _recorder;

        internal WhereForActionHandler(DelegateFunc<T1, T2, T3, T4, bool> expression,
            Action<DelegateFunc<T1, T2, T3, T4, bool>, Action<T1, T2, T3, T4>> recorder,
            TMatcher matcher)
        {
            _expression = expression;
            _recorder = recorder;
            _matcher = matcher;
        }

        public TMatcher Do(Action<T1, T2, T3, T4> action)
        {
            _recorder(_expression, action);
            return _matcher;
        }
    }
}