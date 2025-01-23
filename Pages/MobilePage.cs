using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Waiters;
using EaAutomationFramework.Driver;
using EaAutomationFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FlipkartApp.Pages
{
    public class MobilePage : Wait
    {
        
        public MobilePage(IDriverFixture driverFixture):base(driverFixture)
        {
         this._driverFixture = driverFixture;
        }
         
        private string title = "Mobiles";
        //WebDriverWait wait = new WebDriverWait(_driverFixture.Driver, TimeSpan.FromSeconds(10));
        WebElementExtention webElementExtention = new WebElementExtention();
        private IWebElement lowToHigh => _driverFixture.Driver.FindElement(By.XPath("//*[(text()='Price -- Low to High')]"));
        private IWebElement moblieNameClick => _driverFixture.Driver.FindElement(By.XPath("//div[contains(@class, 'tUxRFH')]//*[contains(text(),'H17')]"));
        
        private IWebElement addCart => _driverFixture.Driver.FindElement(By.XPath("//*[text()='Add to cart']"));

        private IWebElement addItem => _driverFixture.Driver.FindElement(By.XPath("//*[@class='AGzJZR']/child::*"));

        private IWebElement saveItem => _driverFixture.Driver.FindElement(By.XPath("//*[text()='Save for later']"));
        
        public void ValidatePageTitle()
        {
            if (title == "Mobiles")
            {
                Console.WriteLine("You are in Mobiles page");
            }
            else
            {
                Console.WriteLine(" You are not in Moblies Page ");
            }
        }
        public void PriceClick()
        {
            lowToHigh.Click();
        }
        public void MobileNameClick()
        {
            WebdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'tUxRFH')]//*[contains(text(),'H17')]")));
            webElementExtention.PerfromMouseHover(moblieNameClick,_driverFixture.Driver);
            WebdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(moblieNameClick));
            webElementExtention.ElementToClick(moblieNameClick);
            WebdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(moblieNameClick));
            string mainWindow = _driverFixture.Driver.CurrentWindowHandle;
            Console.WriteLine(mainWindow);
            IReadOnlyCollection<string> windowHandle = _driverFixture.Driver.WindowHandles; 
            foreach(string handle in windowHandle)
            {
                if(!(mainWindow==handle))
                {
                    _driverFixture.Driver.SwitchTo().Window(handle);
                    Console.WriteLine(handle);
                    Console.WriteLine("You are in child Window");
                }
                else
                {
                    _driverFixture.Driver.Close();
                }
            }
        }   
          public void AddCartPage()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driverFixture.Driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", addCart);
            // jsExecutor.ExecuteScript("window.scrollBy(0, 70);");
            // Then click the element
            WebdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addCart));
            addCart.Click();
        }
        public void AddItem()
        {

            try
            {
                WebdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='AGzJZR']/child::*")));
                addItem.Click();
                Console.WriteLine("Item Added Successfully");
            }
            catch (ElementClickInterceptedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _driverFixture.Driver.Quit();
            }



        }
        
       

    }
}
