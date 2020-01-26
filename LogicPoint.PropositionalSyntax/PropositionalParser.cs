using System;

namespace LogicPoint.PropositionalSyntax
{
    public class PropositionalParser : IParser
    {
        /*
         * EXPRESSION ::= { UNARY OPERATOR } TERM { BINARY OPERATOR TERM }
         * TERM ::= CONSTANT | "(" EXPRESSION ")"
         * CONSTANT ::= PROPOSITITIONAL VARIABLE
         * PROPOSITIONAL VARIABLE ::= "P" | "Q" | "R"
         * NEGATION ::= "~"
         * BINARY OPERATOR ::= "&" | "V" | ">" 
         */

        private readonly ITokenWalker _walker;

        public PropositionalParser(ITokenWalker walker)
        {
            _walker = walker;
        }

        public bool Parse()
        {
            var isValid = false;
            isValid = ParseExpression();
            if (_walker.ThereAreMoreTokens())
            {
                throw new Exception("Invalid Expression");
            }
            return isValid;
        }

        private bool ParseExpression()
        {
            bool isValidExpression = false;
            isValidExpression = ParseTerm();
            while (NextIsBinaryOperator())
            {
                _walker.GetNext();
                isValidExpression = ParseTerm();
            }
            return isValidExpression;
        }

        private bool ParseTerm()
        {
            bool isValidTerm = false;
            if (NextIsPropositionalVariable())
            {
                isValidTerm = ParseConstant();
                return isValidTerm;
            }
            if (!NextIsLeftBracket())
            {
                return false;
                //throw new FormatException("Invalid expression");
            }

            _walker.GetNext();

            isValidTerm = ParseExpression();

            if (!NextIs(typeof(RightBracket)))
            {
                return false;
                //throw new FormatException("Expression has a missing or misplaced closing bracket.");
            }

            _walker.GetNext();

            return isValidTerm;
        }

        private bool ParseConstant()
        {
            bool isValidConstant = false;
            if (NextIsPropositionalVariable())
            {
                isValidConstant = true;
                _walker.GetNext();
            }
            return isValidConstant;
        }

        private bool NextIsPropositionalVariable()
        {
            return NextIs(typeof(PropositionalVariable));
        }

        private bool NextIsLeftBracket()
        {
            return NextIs(typeof(LeftBracket));
        }

        private bool NextIsBinaryOperator()
        {
            return NextIs(typeof(ConjunctionOperator)) || 
                   NextIs(typeof(DisjunctionOperator)) || 
                   NextIs(typeof(ConditionalOperator));
        }

        private bool NextIs(Type type)
        {
            return _walker.ThereAreMoreTokens() && _walker.IsNextOfType(type);
        }

    }
}
