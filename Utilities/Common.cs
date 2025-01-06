using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Utilities
{
    public static class Common
    {
        // Wait until the element is visible
        public static IWebElement WaitForElementToBeVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // Wait until the element is clickable and then click
        public static void WaitAndClickElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }

        public static IWebElement WaitForElementVisible(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitForElementClickable(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        // Wait and send keys
        public static void EnterText(IWebDriver driver, By locator, string text, int timeoutInSeconds = 10)
        {
            WaitForElementToBeVisible(driver, locator, timeoutInSeconds).SendKeys(text);
        }

        public static string WaitAndGetText(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
           return WaitForElementToBeVisible(driver, locator, timeoutInSeconds).Text;
        }


        public static void CloseSnackbarIfPresent(IWebDriver driver)
        {
            try
            {
                // Explicit wait for the snackbar message to appear (adjust timeout as needed)
                new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                .Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("mat-simple-snack-bar-content")));

            }
            catch (NoSuchElementException)
            {
                // Snackbar or close button not found, do nothing
            }
            catch (WebDriverTimeoutException)
            {
                // Snackbar did not appear within the timeout, do nothing
            }
        }

        public static void DisMissCookieButtonPresent(IWebDriver driver)
        {
            WaitAndClickElement(driver, By.XPath("//a[@aria-label='dismiss cookie message']"));
        }

        public static void RetryWaitAndClickElement(IWebDriver driver, By locator, int timeoutInSeconds = 10, int retryCount = 2)
        {
            int attempts = 0;
            while (attempts < retryCount)
            {
                try
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                    element.Click();
                    return; // Click successful, exit the loop
                }
                catch (StaleElementReferenceException)
                {
                    attempts++;
                    Console.WriteLine($"Stale element exception on attempt {attempts}. Retrying...");
                }
            }

            // If all retries fail, throw the exception
            throw new Exception($"Failed to click element after {retryCount} retries due to StaleElementReferenceException");
        }


    }
}
