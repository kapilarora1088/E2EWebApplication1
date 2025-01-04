
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
        Driver.Navigate().GoToUrl("https://juice-shop.herokuapp.com");
        

        // Dismiss any alerts that might appear
        homePage.DismissWelcomeBannerIfPresent();

        registrationPage.NavigateToLoginPage();

        loginPage.Login("test11@gmail.com", "Dubai@123");

        // Step 2: Add five different products to the basket and assert cart number changes
        /*for (int i = 1; i <= 5; i++)
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

        }*/

        // Step 3: Navigate to the basket and modify product quantity
        var basketIcon = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'Your Basket')]")));
            basketIcon.Click();

            // Wait for the basket page to load
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//app-purchase-basket")));

        // Increase quantity of the first product
        var increaseQuantityButton = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//mat-cell[3]/button[2]/span[1]")));
        increaseQuantityButton.Click();

        // Wait for the total price to change
        var totalPriceElement = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='price']")));
        string initialTotalPrice = totalPriceElement.Text;

        // Delete the product from the basket
        var deleteProductButton = Driver.FindElement(By.XPath("//mat-table/mat-row[1]/mat-cell[5]/button"));
        deleteProductButton.Click();

        Thread.Sleep(1000);
        // Once the price has changed, you can get the updated value
        string updatedPrice = totalPriceElement.Text;

        // Assert that the total price has been updated after modifying the cart
        ClassicAssert.AreNotEqual(initialTotalPrice, updatedPrice, "Total price did not change after modifying the cart.");

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
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[contains(@class,'mat-simple-snackbar')]")));

        Common.WaitAndClickElement(Driver, By.XPath("//mat-radio-button[@id='mat-radio-42']"));

        // Click on the continue button
        Common.WaitAndClickElement(Driver, By.XPath("//button[contains(@aria-label, 'Proceed to payment selection')]"));

        Common.WaitForElementVisible(Driver,By.XPath("//h1[contains(text(),'Delivery')]"));


        // Select delivery method
        //var snackBar = Driver.WaitForElementClickable(By.CssSelector(".mat-snack-bar-container"));

        // If there is a close button inside the Snackbar
        var closeButton = Driver.FindElement(By.CssSelector(".mat-snack-bar-container button")); // Adjust if the close button exists
        closeButton.Click();

        Common.WaitAndClickElement(Driver, By.XPath("//mat-radio-button[@class='mat-radio-button mat-accent']"));

        // Click on the continue button
        Common.WaitAndClickElement(Driver, By.XPath("//button[contains(@aria-label, 'Proceed to delivery method selection')]"));


        // Wait for payment page to load
        Common.WaitForElementVisible(Driver, By.XPath("//h1[contains(text(),'My Payment Options')]"));

        // Assert that wallet balance is zero (you can use specific wallet element on the page)
        IWebElement amountSpan = Driver.FindElement(By.XPath("//span[@class='confirmation card-title']"));
        string amount = amountSpan.Text;
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







