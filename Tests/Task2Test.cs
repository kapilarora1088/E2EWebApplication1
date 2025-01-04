using NUnit.Framework.Legacy;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

[TestFixture]
public class Task2Tests : BaseTest
{
    [Test]
    public void VerifyPopupAndImageForProduct()
    {
        var homePage = new HomePage(Driver);
        Driver.Navigate().GoToUrl(TestData.BaseUrl);
        homePage.DismissWelcomeBannerIfPresent();

        //script click on the first product ‘Apple Juice’ then assert that there is an popup appeared and image
        //of product exists.
        var productElement = Driver.FindElement(Locators.ProductPage.FirstItem);
        productElement.Click();

        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        var popup = wait.Until(ExpectedConditions.ElementExists(By.Id("mat-dialog-1")));
        ClassicAssert.IsTrue(popup.Displayed, "Popup did not appear.");

        var image = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("mat-dialog-container#mat-dialog-1 img")));
        ClassicAssert.IsNotNull(image, "Product image not found.");

        try
        {
            var reviewButton = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='mat-expansion-panel-header-0']")));
            if (reviewButton.Displayed)
            {
                reviewButton.Click();
            }
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine("Review button not found: " + ex.Message);
        }

        var closebutton = Driver.FindElement(By.XPath("//button[@aria-label='Close Dialog']"));
        System.Threading.Thread.Sleep(2000);
        closebutton.Click();
    }
}