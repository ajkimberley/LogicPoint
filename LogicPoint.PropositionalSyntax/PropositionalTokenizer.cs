using System;
using System.Collections.Generic;
using System.IO;

namespace LogicPoint.PropositionalSyntax
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// The Propositional Tokenizer class scans a string from left-to-right and classifies each of the characters within that string as an instance of its associated class
    /// Upon classifying a character as an instance of a class it adds an object of that class-type to a list
    /// This list is then utilised by the Propositonal Parser, which determines whether the list of objects constitutes a well-formed formula
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PropositionalTokenizer
    {
        private readonly string _input;
        private ICollection<GrammaticalCategory> _grammaticalCategories;

        public PropositionalTokenizer(string input)
        {
            _input = input;
            _grammaticalCategories = new List<GrammaticalCategory>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Scans a string argument and outputs a list of tokens which correspond to the string characters.
        /// </summary>
        /// <returns>
        /// An enumerable collection of tokens.
        /// </returns>
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public IEnumerable<GrammaticalCategory> Tokenize()
        {
            // Initialises a string reader
            StringReader _reader = new StringReader(_input);

            while (_reader.Peek() != -1)
            {
                // Add the currently read character to variable 'c'
                var c = (char)_reader.Read();

                // If c is a blank space, continue reading
                if (Char.IsWhiteSpace(c))
                {
                    continue;
                }

                switch (c)
                {
                    // If c is 'P', 'Q', or 'R', add a propositional variable token to tokens
                    case 'P':
                    case 'Q':
                    case 'R':
                        _grammaticalCategories.Add(new PropositionalVariable());
                        break;
                    // If c is 'V', '&', or '>', add a binary operator token to tokens
                    case 'V':
                        _grammaticalCategories.Add(new DisjunctionOperator());
                        break;
                    case '&':
                        _grammaticalCategories.Add(new ConjunctionOperator());
                        break;
                    case '>':
                        _grammaticalCategories.Add(new ConditionalOperator());
                        break;
                    // If c is '(', add a left bracket token to tokens
                    case '(':
                        _grammaticalCategories.Add(new LeftBracket());
                        break;
                    // if c is ')', add a right bracket token to tokens
                    case ')':
                        _grammaticalCategories.Add(new RightBracket());
                        break;
                    default:
                        // Otherwise throw an exception
                        throw new FormatException("Unkown character in expression: " + c);
                }
            }
            // return tokens
            return _grammaticalCategories;
        }
    }
}
