using System;

namespace LogicPoint.PropositionalSyntax
{
    public interface ITokenWalker
    {
        void GetNext();
        bool IsNextOfType(Type type);
        bool ThereAreMoreTokens();
    }
}
