using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Utilities;


public class BasketPage
{
    private IWebDriver Driver;

    // Constructor to initialize the driver
    public BasketPage(IWebDriver driver)
    {
        Driver = driver;
    }

    public bool HandleBasketOperations()
    {
        // Click the basket icon
        Common.WaitAndClickElement(Driver,By.XPath("//span[contains(text(), 'Your Basket')]"));


        // Wait for the basket page to load
        Common.WaitForElementToBeVisible(Driver,By.XPath("//app-purchase-basket"));

        // Increase quantity of the first product
        Common.WaitAndClickElement(Driver, By.XPath("//mat-cell[3]/button[2]/span[1]"));


        // Wait for the total price to change
        var totalPriceElement = Common.WaitAndGetText(Driver,By.XPath("//*[@id='price']"));
        string initialTotalPrice = totalPriceElement;

        // Delete the product from the basket
        var deleteProductButton = Driver.FindElement(By.XPath("//mat-table/mat-row[1]/mat-cell[5]/button"));
        deleteProductButton.Click();

        Thread.Sleep(1000);

        // Once the price has changed, you can get the updated value
        string updatedPrice = Common.WaitAndGetText(Driver, By.XPath("//*[@id='price']"));

        // Return both initial and updated price for comparison
        return initialTotalPrice==updatedPrice;
    }


}