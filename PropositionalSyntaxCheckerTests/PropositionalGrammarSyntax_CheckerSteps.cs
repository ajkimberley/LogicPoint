using PropositionalSyntaxChecker;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acceptance.Tests
{
    [Binding]
    public class PropositionalGrammarSyntax_CheckerSteps
    {
        private IParser _propositionalParser;
        private IGrammaticalCategory _returnCategory;

        [Given]
        public void GivenAPropositionalGrammarParser()
        {
            _propositionalParser = new PropositionalParser();
        }
        
        // Should probably merge this step with the one above
        [When]
        public void WhenIEnterTheExpression_P0(string p0)
        {
            _returnCategory = _propositionalParser.Parse(p0);
        }
        
        [Then]
        public void ThenIShouldHaveA_P0(IGrammaticalCategory p0)
        {
            Assert.AreEqual(_returnCategory, p0);
        }
        
        [Then]
        public void ThenIHaveAWellFormedFormula()
        {
            IGrammaticalCategory wff = new WellFormedFormula();
            Assert.IsInstanceOfType(_returnCategory, wff.GetType()) ;
        }
        
        [Then]
        [Scope(Scenario = "Ungrammatical Characters")]
        public void ThenIShouldHaveAnInvalidCharacter()
        {
            InvalidCharacter invalidCharacter = new InvalidCharacter();
            Assert.IsInstanceOfType(_returnCategory, invalidCharacter.GetType());
        }
        
        [Then]
        [Scope(Scenario = "Ill-Formed Formulas")]
        public void ThenIShouldHaveAnIllFormedFormula()
        {
            IllFormedFormula illFormedFormula = new IllFormedFormula();
            Assert.IsInstanceOfType(_returnCategory, illFormedFormula.GetType());
        }
    }
}
