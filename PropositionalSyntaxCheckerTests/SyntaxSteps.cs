using System;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class StepDefinitions
    {
        [Given(@"a logic parser")]
        public void GivenALogicParser()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter '(.*)'")]
        public void WhenIEnter(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I have a well-formed formula")]
        public void ThenIHaveAWell_FormedFormula()
        {
            ScenarioContext.Current.Pending();
        }
    }
}