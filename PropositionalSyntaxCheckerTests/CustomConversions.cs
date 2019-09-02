using PropositionalSyntaxChecker;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Acceptance.Tests
{
    [Binding]
    class CustomConversions
    {
        [StepArgumentTransformation]
        public IGrammaticalCategory TransformGrammaticalCategory(string grammaticalCategory)
        {
            return new GrammaticalCategory();
        }
    }
}
