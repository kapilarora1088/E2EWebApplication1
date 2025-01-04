using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using Utilities;

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
            var nameField = _driver.WaitForElementClickable(By.XPath("//mat-label[text()='Name']"));
            nameField.SendKeys(name);

            // Generate random 16-digit card number
            var cardNumber = GenerateRandomCardNumber();
            var cardNumberField = _driver.WaitForElementClickable(By.XPath("//mat-label[text()='Card Number']"));
            cardNumberField.SendKeys(cardNumber);

            // Select Month
            var monthDropdown = _driver.WaitForElementClickable(By.XPath("//mat-label[text()='Expiry Month']"));
            var selectMonth = new SelectElement(monthDropdown);
            selectMonth.SelectByValue("5");

            // Select Year
            var yearDropdown = _driver.WaitForElementClickable(By.XPath("//mat-label[text()='Expiry Year']"));
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
