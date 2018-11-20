using System;
using Smooth.Delegates;

namespace Smooth.Foundations.PatternMatching
{
    public sealed class WhereForFuncHandler<TMatcher, T1, TResult>
    {
        private readonly DelegateFunc<T1, bool> _expression;
        private readonly TMatcher _matcher;
        private readonly Action<DelegateFunc<T1, bool>, DelegateFunc<T1, TResult>> _recorder;

        internal WhereForFuncHandler(DelegateFunc<T1, bool> expression,
            Action<DelegateFunc<T1, bool>, DelegateFunc<T1, TResult>> recorder,
            TMatcher matcher)
        {
            _expression = expression;
            _recorder = recorder;
            _matcher = matcher;
        }

        public TMatcher Return(DelegateFunc<T1, TResult> action)
        {
            _recorder(_expression, action);
            return _matcher;
        }

        public TMatcher Return(TResult value)
        {
            _recorder(_expression, x => value);
            return _matcher;
        }
    }

    public sealed class WhereForFuncHandler<TMatcher, T1, T2, TResult>
    {
        private readonly DelegateFunc<T1, T2, bool> _expression;
        private readonly TMatcher _matcher;
        private readonly Action<DelegateFunc<T1, T2, bool>, DelegateFunc<T1, T2, TResult>> _recorder;

        internal WhereForFuncHandler(DelegateFunc<T1, T2, bool> expression,
            Action<DelegateFunc<T1, T2, bool>, DelegateFunc<T1, T2, TResult>> recorder,
            TMatcher matcher)
        {
            _expression = expression;
            _recorder = recorder;
            _matcher = matcher;
        }

        public TMatcher Return(DelegateFunc<T1, T2, TResult> action)
        {
            _recorder(_expression, action);
            return _matcher;
        }

        public TMatcher Return(TResult value)
        {
            _recorder(_expression, (x, y) => value);
            return _matcher;
        }
    }

    public sealed class WhereForFuncHandler<TMatcher, T1, T2, T3, TResult>
    {
        private readonly DelegateFunc<T1, T2, T3, bool> _expression;
        private readonly TMatcher _matcher;
        private readonly Action<DelegateFunc<T1, T2, T3, bool>, DelegateFunc<T1, T2, T3, TResult>> _recorder;

        internal WhereForFuncHandler(DelegateFunc<T1, T2, T3, bool> expression,
            Action<DelegateFunc<T1, T2, T3, bool>, DelegateFunc<T1, T2, T3, TResult>> recorder,
            TMatcher matcher)
        {
            _expression = expression;
            _recorder = recorder;
            _matcher = matcher;
        }

        public TMatcher Return(DelegateFunc<T1, T2, T3, TResult> action)
        {
            _recorder(_expression, action);
            return _matcher;
        }

        public TMatcher Return(TResult value)
        {
            _recorder(_expression, (x, y, z) => value);
            return _matcher;
        }
    }

    public sealed class WhereForFuncHandler<TMatcher, T1, T2, T3, T4, TResult>
    {
        private readonly DelegateFunc<T1, T2, T3, T4, bool> _expression;
        private readonly TMatcher _matcher;
        private readonly Action<DelegateFunc<T1, T2, T3, T4, bool>, DelegateFunc<T1, T2, T3, T4, TResult>> _recorder;

        internal WhereForFuncHandler(DelegateFunc<T1, T2, T3, T4, bool> expression,
            Action<DelegateFunc<T1, T2, T3, T4, bool>, DelegateFunc<T1, T2, T3, T4, TResult>> recorder,
            TMatcher matcher)
        {
            _expression = expression;
            _recorder = recorder;
            _matcher = matcher;
        }

        public TMatcher Return(DelegateFunc<T1, T2, T3, T4, TResult> action)
        {
            _recorder(_expression, action);
            return _matcher;
        }

        public TMatcher Return(TResult value)
        {
            _recorder(_expression, (w, x, y, z) => value);
            return _matcher;
        }
    }
}