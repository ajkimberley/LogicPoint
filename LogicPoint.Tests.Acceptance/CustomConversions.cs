using LogicPoint.PropositionalSyntax;
using TechTalk.SpecFlow;

namespace Logicpoint.Tests.Acceptance
{
    [Binding]
    class CustomConversions
    {
        [StepArgumentTransformation]
        public IGrammaticalCategory TransformGrammaticalCategory(string grammaticalCategory)
        {
            return new PropositionalVariable();
        }
    }
}
