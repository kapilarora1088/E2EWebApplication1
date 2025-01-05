using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using Utilities;
using static Locators;

namespace YourProject.Pages
{
    public class PaymentPage
    {
        private IWebDriver _driver;

        public PaymentPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddCreditCardDetails(string name)
        {

            // Enter Name
            Common.EnterText(_driver, By.XPath("//*[@id='mat-input-10']"),name); ;
    

            // Generate random 16-digit card number
            var cardNumber = GenerateRandomCardNumber();
            Common.EnterText(_driver, By.XPath("//*[@id='mat-input-11']"), cardNumber); ;


            // Select Month
            //Common.WaitForElementClickable(_driver, By.XPath("//*[@id='mat-input-12']");
            var monthDropdown = _driver.WaitForElementClickable(By.XPath("//*[@id='mat-input-12']"));
            var selectMonth = new SelectElement(monthDropdown);
            selectMonth.SelectByValue("5");

            // Select Year
            var yearDropdown = _driver.WaitForElementClickable(By.XPath("//*[@id='mat-input-13']"));
            var selectYear = new SelectElement(yearDropdown);
            selectYear.SelectByValue("2080");

            // Click Submit Button
            WaitAndClickElement(_driver, By.XPath("//button[contains(., 'Submit')]"));
        }

        private string GenerateRandomCardNumber()
        {
            var random = new Random();
            var cardNumber = string.Empty;
            for (int i = 0; i < 16; i++)
            {
                cardNumber += random.Next(0, 10).ToString();
            }
            return cardNumber;
        }

        // Reusing the static WaitAndClickElement method
        private void WaitAndClickElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            Common.WaitAndClickElement(driver, locator, timeoutInSeconds);
        }
    }
}
