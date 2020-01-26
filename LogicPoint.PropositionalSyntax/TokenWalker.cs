using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicPoint.PropositionalSyntax
{
    public class TokenWalker : ITokenWalker
    {
        private readonly List<GrammaticalCategory> _tokens = new List<GrammaticalCategory>();
        private int _currentIndex = -1;

        public TokenWalker(IEnumerable<GrammaticalCategory> tokens)
        {
            _tokens = tokens.ToList();
        }

        public void GetNext()
        {
            MakeSureWeDoNotGoPastEnd();
            _currentIndex++;
        }

        public bool IsNextOfType(Type type)
        {
            return PeekNext().GetType() == type;
        }

        public bool ThereAreMoreTokens()
        {
            return _currentIndex < _tokens.Count -1;
        }

        private void MakeSureWeDoNotGoPastEnd()
        {
            if (!ThereAreMoreTokens())
            {
                throw new Exception("Cannot read past the end of tokens list");
            }
        }

        private GrammaticalCategory PeekNext()
        {
            MakeSureWeDontPeekPastEnd();
            return _tokens[_currentIndex + 1];
        }

        private void MakeSureWeDontPeekPastEnd()
        {
            bool weCanPeek = (_currentIndex + 1 < _tokens.Count);
            if (!weCanPeek)
            {
                throw new Exception("Cannot peek pas tthe end of the tokens list");
            }
        }
    }
}
