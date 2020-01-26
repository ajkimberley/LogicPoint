using System;
using LogicPoint.PropositionalSyntax;

namespace Exerciser
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "q") Environment.Exit(1);
                var tokenizer = new PropositionalTokenizer(input);
                var tokens = tokenizer.Tokenize();
                var walker = new TokenWalker(tokens);
                var parser = new PropositionalParser(walker);
                try
                {
                    var result = parser.Parse();
                    Console.WriteLine(result);
                }
                catch (Exception)
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
