namespace PropositionalSyntaxChecker
{
    public interface IParser
    {
        IGrammaticalCategory Parse(string input);
    }
}