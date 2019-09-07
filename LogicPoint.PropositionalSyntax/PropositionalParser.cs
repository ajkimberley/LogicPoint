namespace LogicPoint.PropositionalSyntax
{
    public class PropositionalParser : IParser
    {
        public IGrammaticalCategory Parse(string input)
        {
            return new PropositionalVariable();
        }
    }
}
