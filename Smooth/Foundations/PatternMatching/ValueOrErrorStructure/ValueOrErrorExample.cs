using System;

namespace Smooth.Foundations.Foundations.PatternMatching.ValueOrErrorStructure
{
    public class ValueOrErrorExample
    {
        public static void Example()
        {
            var testValue = ValueOrError<int>.FromValue(42);

            testValue.Match()
                .Value().Where(i => i == 0).Do(i => Console.WriteLine($"{i} is zero"))
                .Value().Where(i => i == 1).Do(i => Console.WriteLine($"{i} is one"))
                .Value().Do(i => Console.WriteLine("{i} is not 0 or 1"))
                .Error().Do(_ => Console.WriteLine("some error has occured"))
                .Exec();

            var matchResult = testValue.MatchTo<string>()
                .With(555).Or(666).Do(i => "i is 555 or 666")
                .Where(i => i > 1000).Return(i => $"{i} > 1000")
                .Where(i => i < 300).Return(i => $"{i} < 300")
                .Else(i => "some other int")
                .Result();

            Console.WriteLine(matchResult);
        }
    }
}