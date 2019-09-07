using System;
using Xunit;

namespace PropositionalSyntaxChecker.Tests
{
    public class PropositionalTokenizerTests : IDisposable 
    {
        PropositionalTokenizer _propositionalTokenizer;

        public PropositionalTokenizerTests()
        {
            _propositionalTokenizer = new PropositionalTokenizer();
        }

        public void Dispose()
        {
            _propositionalTokenizer.Dispose();
        }

        [Fact]
        public void Test1()
        {
            _propositionalTokenizer.Tokenize();

        }
    }
}
