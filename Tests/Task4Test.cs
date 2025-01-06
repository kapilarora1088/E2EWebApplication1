
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;

[TestFixture]
public class Task4Test : BaseTest
{

    [Test]
    public void Test_AddProductsToCartAndCheckout()
    {
        Driver.Navigate().GoToUrl(TestData.BaseUrl);
        // Dismiss any alerts that might appear
        homePage.DismissWelcomeBannerIfPresent();
        Common.DisMissCookieButtonPresent(Driver);
        registrationPage.NavigateToLoginPage();

        loginPage.Login("test13@gmail.com", "Dubai@123");

        // Step 2: Add five different products to the basket and assert cart number changes
        for (int i = 1; i <= 5; i++)
        {
            // Use aria-label to find the "Add to Basket" button for each product
            var addToBasketButton = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath($"//mat-grid-tile[contains(@class, 'ng-star-inserted')][{i}]//button[@aria-label='Add to Basket']")));

            // Click the "Add to Basket" button
            addToBasketButton.Click();

            // Wait for the success popup to appear
            var successPopup = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-simple-snack-bar-content")));
            ClassicAssert.IsTrue(successPopup.Displayed, "Success popup did not appear after adding product to basket.");

            //wait for closure of popup
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".mat-simple-snack-bar-content")));

            // Wait for cart number to update
            var cartNumber = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='fa-layers-counter fa-layers-top-right fa-3x warn-notification']")));
            var cartText = cartNumber.Text;
            ClassicAssert.AreEqual(i.ToString(), cartText, $"Cart number did not update correctly after adding {i} product(s).");

        }

        // Step 3: Navigate to the basket and modify product quantity
 

        // Assert that the total price has been updated after modifying the cart
        ClassicAssert.False(basketPage.HandleBasketOperations());

        // Step 4: Checkout and add address information
        Common.WaitAndClickElement(Driver, By.XPath("//*[@id='checkoutButton']"));

        // Wait for the address page to load
        Common.WaitForElementVisible(Driver, By.XPath("//h1[contains(text(),'address')]"));

        // Click Add address information
        Common.WaitAndClickElement(Driver, By.XPath("//button[contains(@class, 'btn-new-address')]"));

        Common.WaitForElementVisible(Driver, By.XPath("//h1[contains(text(),'Add New Address')]"));

        // Add address information
        add.AddAddress(
                country: "USA",
                name: "John Doe",
                mobile: "1234567890",
                zipcode: "10001",
                address: "123 Main Street",
                city: "New York",
                state: "NY"
                 );

        //select the address
        Common.CloseSnackbarIfPresent(Driver);

        Common.WaitAndClickElement(Driver, By.XPath("//mat-radio-button[@id='mat-radio-42']"));

        Common.CloseSnackbarIfPresent(Driver);

        // Click on the continue button
        Common.WaitAndClickElement(Driver, By.XPath("//button[contains(@aria-label, 'Proceed to payment selection')]"));

        Common.WaitForElementVisible(Driver,By.XPath("//h1[contains(text(),'Delivery')]"));


 

        // If there is a close button inside the Snackbar
        Common.CloseSnackbarIfPresent(Driver);

        Common.WaitAndClickElement(Driver, By.XPath("//mat-radio-button[@class='mat-radio-button mat-accent']"));

        //wat for snackbar to close

        

        // Click on the continue button on slecting the delivery Speed
        Common.WaitAndClickElement(Driver, By.XPath("//span[text()='Continue']"));


        // Wait for payment page to load
        Common.WaitForElementVisible(Driver, By.XPath("//h1[contains(text(),'My Payment Options')]"));

        // Assert that wallet balance is zero (you can use specific wallet element on the page)
        string amount =Common.WaitAndGetText(Driver, By.XPath("//h1[contains(text(),'My Payment Options')]"));

        //ClassicAssert.AreEqual("0.00", amount);

        //Select Credit card
        Common.WaitAndClickElement(Driver, By.XPath("//mat-panel-description[contains(text(), 'Add a credit or debit card')]"));

        //Add details:

        string name = "John Doe";

        // Add credit card details
        _paymentPage.AddCreditCardDetails(name);

        //select the added credit card details
        Common.WaitAndClickElement(Driver, By.XPath("//*[@class='mat-radio-outer-circle']"));
        Common.WaitAndClickElement(Driver, By.XPath("//span[text()='Continue']"));

    }
}







