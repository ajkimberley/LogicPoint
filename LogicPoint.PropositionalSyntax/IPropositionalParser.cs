namespace LogicPoint.PropositionalSyntax
{
    public interface IParser
    {
        IGrammaticalCategory Parse(string input);
    }
}