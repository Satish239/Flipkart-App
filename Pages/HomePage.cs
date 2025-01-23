using EaAutomationFramework.Driver;
using EaAutomationFramework.Extensions;
using OpenQA.Selenium;

namespace FlipkartApp.FlipkartHomepage
{
    public class HomePage
    {

        private readonly IDriverFixture _driverFixture;
        public HomePage(IDriverFixture driverFixture)
        {
            _driverFixture = driverFixture;
        }
            WebElementExtention extension = new WebElementExtention();
        private IWebElement logoTitle => _driverFixture.Driver.FindElement(By.XPath("//img[@title=\"Flipkart\"]"));
        private IWebElement searchBar => _driverFixture.Driver.FindElement(By.XPath("//*[@name='q']"));
        

        public void ValidateHome()
        {
           try
            {
                Assert.True(logoTitle.Displayed, "Logo is not Displayed");
                Console.WriteLine("Logo is Displyed");
            }
            catch(NoSuchElementException ex){ 
                Assert.Fail($"Test falied beacause the logo is not displayed {ex.Message}");
            }
        }
        public void TextToSearchBar()
        {
            extension.SendKeysToText(searchBar,"Mobiles");     
            searchBar.Submit();
             
        }
        

    }
}
