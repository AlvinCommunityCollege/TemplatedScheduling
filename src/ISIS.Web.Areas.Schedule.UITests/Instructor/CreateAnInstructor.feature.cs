// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.7.0.0
//      SpecFlow Generator Version:1.7.0.0
//      Runtime Version:4.0.30319.235
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace ISIS.Web.Areas.Schedule.UITests.Instructor
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("In order to have instructors available to teach\nAs a department chair\nI want to e" +
        "nter new instructors")]
    public partial class CreateAnInstructorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreateAnInstructor.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Create an instructor", "In order to have instructors available to teach\nAs a department chair\nI want to e" +
                    "nter new instructors", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create Instructor dialog displays")]
        [NUnit.Framework.CategoryAttribute("selenium")]
        public virtual void CreateInstructorDialogDisplays()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Instructor dialog displays", new string[] {
                        "selenium"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I navigate to ~/Schedule/Instructor");
#line 9
 testRunner.When("I click Create an instructor");
#line 10
 testRunner.Then("the Create Instructor dialog is displayed");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Enter instructor name and click cancel")]
        [NUnit.Framework.CategoryAttribute("selenium")]
        public virtual void EnterInstructorNameAndClickCancel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Enter instructor name and click cancel", new string[] {
                        "selenium"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I navigate to ~/Schedule/Instructor");
#line 15
 testRunner.When("I click Create an instructor");
#line 16
 testRunner.And("I enter the first name \"John\"");
#line 17
 testRunner.And("I enter the last name \"Smith\"");
#line 18
 testRunner.And("I click \"Cancel\"");
#line 19
 testRunner.Then("the Create Instructor dialog is not displayed");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Enter instructor name and click Create Instructor")]
        [NUnit.Framework.CategoryAttribute("selenium")]
        public virtual void EnterInstructorNameAndClickCreateInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Enter instructor name and click Create Instructor", new string[] {
                        "selenium"});
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given("I navigate to ~/Schedule/Instructor");
#line 24
 testRunner.When("I click Create an instructor");
#line 25
 testRunner.And("I enter the first name \"John\"");
#line 26
 testRunner.And("I enter the last name \"Smith\"");
#line 27
 testRunner.And("I click \"Create Instructor\"");
#line 28
 testRunner.Then("I navigate to an instructor detail page");
#line 29
 testRunner.And("the instructor is \"John Smith\"");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#endregion
