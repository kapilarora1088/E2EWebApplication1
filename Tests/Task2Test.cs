using NUnit.Framework.Legacy;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;

[TestFixture]
public class Task2Tests : BaseTest
{
    [Test]
    public void VerifyPopupAndImageForProduct()
    {
        Driver.Navigate().GoToUrl(TestData.BaseUrl);
        homePage.DismissWelcomeBannerIfPresent();
        Common.CloseSnackbarIfPresent(Driver);
        Common.DisMissCookieButtonPresent(Driver);

        //script click on the first product ‘Apple Juice’ then assert that there is an popup appeared and image
        //of product exists.
        // Click on the first product 'Apple Juice'
        var productElement = Driver.FindElement(Locators.ProductPage.FirstItem);
        productElement.Click();

        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        // Verify popup
        var popup = wait.Until(ExpectedConditions.ElementExists(Locators.Popup.Container));
        ClassicAssert.IsTrue(popup.Displayed, "Popup did not appear.");

        // Verify product image
        var image = wait.Until(ExpectedConditions.ElementExists(Locators.Popup.Image));
        ClassicAssert.IsNotNull(image, "Product image not found.");

        // Handle review button (optional)
        try
        {
            var reviewButton = wait.Until(ExpectedConditions.ElementExists(Locators.Review.ReviewButton));
            if (reviewButton.Displayed)
            {
                reviewButton.Click();
            }
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine("Review button not found: " + ex.Message);
        }

        // Close popup
        var closeButton = Driver.FindElement(Locators.Popup.CloseButton);
        System.Threading.Thread.Sleep(2000); // Consider using explicit wait instead of Thread.Sleep
        closeButton.Click();
    }
}