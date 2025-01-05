﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public static class WaitHelper
{
    public static IWebElement WaitForElement(IWebDriver driver, By locator, int timeout = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }
}
