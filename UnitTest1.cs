using EaAutomationFramework.Confg;
using EaAutomationFramework.Driver;
using FlipkartApp.FlipkartHomepage;
using FlipkartApp.Pages;


namespace FlipkartApp
{
    public class UnitTest1
    {
        public IDriverFixture _driverFixture;
        public UnitTest1()
        {

            var testSettings = new TestSettings()
            {
                BrowserType = DriverFixture.BrowserType.Chrome,
                ApllicationUrl = new Uri("https://www.flipkart.com/"),
                TimeoutInterval = 30
            };
            _driverFixture = new DriverFixture(testSettings);
        }
        [Fact]
             public void Test1()
             {
               var homepage = new HomePage(_driverFixture);
                 homepage.ValidateHome();
                 homepage.TextToSearchBar();
               var mobiles = new MobilePage(_driverFixture);
                mobiles.ValidatePageTitle();
                mobiles.PriceClick();
                mobiles.MobileNameClick();
                mobiles.AddCartPage();
                mobiles.AddItem();   
               
             }
        }
    }