
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Linq;

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

        loginPage.Login(TestData.Login.Username, TestData.Login.Password);

        // Step 2: Add five different products to the basket and assert cart number changes
       
        for (int i = 1; i <= 5; i++)
        {
            Common.WaitAndClickElement(Driver, By.XPath($"//mat-grid-tile[contains(@class, 'ng-star-inserted')][{i}]//button[@aria-label='Add to Basket']"));

            // Wait for the success popup to appear
            var successMessage = Common.WaitAndGetText(Driver,Locators.BasketPageLocators.SuccessPopupCssSelector);
                //new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-simple-snack-bar-content")));
            ClassicAssert.IsTrue(!string.IsNullOrEmpty(successMessage), "Success popup did not appear after adding product to basket.");

            //wait for closure of popup
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".mat-simple-snack-bar-content")));

            // Wait for cart number to update
            var cartNumber = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='fa-layers-counter fa-layers-top-right fa-3x warn-notification']")));
            var cartText = cartNumber.Text;
            Common.WaitAndGetText(Driver, Locators.CartPageLocators.CartNumberXPath);
            ClassicAssert.AreEqual(i.ToString(), cartText, $"Cart number did not update correctly after adding {i} product(s).");

        }

        // Step 3: Navigate to the basket and modify product quantity


        // Assert that the total price has been updated after modifying the cart
        ClassicAssert.False(basketPage.HandleBasketOperations());

        // Step 4: Checkout and add address information
        Common.WaitAndClickElement(Driver, Locators.BasketPageLocators.CheckoutButton);
        Common.WaitForElementVisible(Driver, Locators.BasketPageLocators.AddressPageHeader);
        Common.WaitAndClickElement(Driver, Locators.BasketPageLocators.AddAddressButton);
        Common.WaitForElementVisible(Driver, Locators.BasketPageLocators.AddNewAddressHeader);

        // Add address information
        add.AddAddress(
             country: TestData.Address.Country,
             name: TestData.Address.Name,
             mobile: TestData.Address.Mobile,
             zipcode: TestData.Address.Zipcode,
             address: TestData.Address.AddressLine1,
             city: TestData.Address.City,
             state: TestData.Address.State
         );

        //select the address
        Common.CloseSnackbarIfPresent(Driver);
        Common.WaitAndClickElement(Driver, Locators.CheckoutPageLocators.SelectAddressRadioButton);
        Common.CloseSnackbarIfPresent(Driver);
        Common.WaitAndClickElement(Driver, Locators.CheckoutPageLocators.ProceedToPaymentButton);
        Common.WaitForElementVisible(Driver, Locators.CheckoutPageLocators.DeliveryPageHeader);





        // If there is a close button inside the Snackbar
        Common.CloseSnackbarIfPresent(Driver);

        Common.WaitAndClickElement(Driver, Locators.CheckoutPageLocators.DeliverySpeedRadioButton);
        // ... (wait for snackbar to close) ...

        // Click on the continue button on slecting the delivery Speed
        Common.WaitAndClickElement(Driver, Locators.CheckoutPageLocators.ContinueButtonOnDeliveryPage);


        // Wait for payment page to load
        Common.WaitForElementVisible(Driver, Locators.CheckoutPageLocators.PaymentPageHeader);

        // Assert that wallet balance is zero (you can use specific wallet element on the page)
        string amount =Common.WaitAndGetText(Driver, By.XPath("//h1[contains(text(),'My Payment Options')]"));

        //ClassicAssert.AreEqual("0.00", amount);

        //Select Credit card
        Common.WaitAndClickElement(Driver, Locators.CheckoutPageLocators.AddCreditCardOption);
        // ... (Add credit card details) ...

        //Add details in credit card:
        string name = "John Doe";
        // Add credit card details
        _paymentPage.AddCreditCardDetails(name);
        Common.CloseSnackbarIfPresent(Driver);

        //select the added credit card details
        ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, 0)");
        Common.WaitAndClickElement(Driver, Locators.CheckoutPageLocators.SelectCreditCardRadioButton);

        /*// Find the element using WebDriverWait with ElementToBeClickable
        var radioButtons = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(@class, 'mat-ripple mat-radio-ripple mat-focus-indicator')]")));

        // Select the first radio button (adjust index as needed)
        radioButtons.Click();*/

        Common.WaitAndClickElement(Driver, Locators.CheckoutPageLocators.ContinueButtonOnDeliveryPage); 

    }
}







