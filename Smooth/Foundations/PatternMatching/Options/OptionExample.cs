using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smooth.Algebraics;
using Smooth.Foundations.PatternMatching;
using Smooth.Foundations.PatternMatching.GeneralMatcher;

namespace Smooth.Foundations.Foundations.PatternMatching.Options
{
    public class OptionExample
    {
        public void Test()
        {
            new Option<int>(54).Match()
                .Some().Of(66).Or(44).Or(123).Do(i=> Console.WriteLine($"value={i}"))
                .Some().Where(i=>i<13).Do(i=> Console.WriteLine($"value={i}"))
                
                .Exec();

            var result = "tata".Match()
                .To<int>()
                .Result();
        }

    }
}
