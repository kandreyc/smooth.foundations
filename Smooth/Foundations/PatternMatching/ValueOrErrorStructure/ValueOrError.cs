using System;

namespace Smooth.Foundations.Foundations.PatternMatching.ValueOrErrorStructure
{
    public struct ValueOrError<T>
    {
        public T Value
        {
            get
            {
                if (IsError)
                {
                    throw new InvalidOperationException();
                }
                return _value;
            }
        }

        public bool IsError { get; }

        public string Error { get; }

        private readonly T _value;

        public static ValueOrError<T> FromValue(T value)
        {
            return new ValueOrError<T>(value, string.Empty, false);
        }

        public static ValueOrError<T> FromError(string error)
        {
            return new ValueOrError<T>(default(T), error, true);
        }

        private ValueOrError(T value, string error, bool isError)
        {
            _value = value;
            Error = error;
            IsError = isError;
        }


        public void Test()
        {
            var testValue = ValueOrError<int>.FromValue(42);
            testValue.Match()
                .Value().Where(i => i == 0).Do(i => Console.WriteLine($"{i} is zero"))
                .Value().Where(i => i == 1).Do(i => Console.WriteLine($"{i} is one"))
                .Value().Do(i => Console.WriteLine("other int"))
                .Error().Do(_ => Console.WriteLine("some error has occured"))
                .Exec();
        }


        public ValueOrErrorMatcher<T> Match()
        {
            return new ValueOrErrorMatcher<T>(this);
        }

        public ValueOrError<TResult> ContinueWith<TResult>(Func<ValueOrError<TResult>> func)
        {
            return IsError
                ? ValueOrError<TResult>.FromError(Error)
                : func();
        }
    }
}