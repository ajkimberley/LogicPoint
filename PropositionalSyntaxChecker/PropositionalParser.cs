using System;
using System.Collections.Generic;
using System.Text;

namespace PropositionalSyntaxChecker
{
    public class PropositionalParser : IParser
    {
        public IGrammaticalCategory Parse(string input)
        {
            return new GrammaticalCategory();
        }
    }
}
