// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.5.0.0
//      Runtime Version:4.0.30319.225
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace ISIS.Domain.Tests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Term Rename")]
    public partial class TermRenameFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TermRename.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Term Rename", "As a scheduler\nI want to rename terms", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Rename a term")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void RenameATerm()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Rename a term", new string[] {
                        "domain"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I created a term 211FA \"2011 Fall 16-week\" from 9/1/2011 to 12/1/2011");
#line 8
 testRunner.When("I rename the term to \"Fall 2011 16-week\"");
#line 9
 testRunner.Then("the term is renamed from \"2011 Fall 16-week\" to \"Fall 2011 16-week\"");
#line 10
 testRunner.And("it does nothing else");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Rename a term to the same")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void RenameATermToTheSame()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Rename a term to the same", new string[] {
                        "domain"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I created a term 211FA \"2011 Fall 16-week\" from 9/1/2011 to 12/1/2011");
#line 15
 testRunner.When("I rename the term to \"2011 Fall 16-week\"");
#line 16
 testRunner.Then("it does nothing");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
