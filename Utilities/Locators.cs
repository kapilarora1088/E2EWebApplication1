using OpenQA.Selenium;

public class Locators
{
    public static class CommonSnackBar
    {
        public static By SuccessPopup = By.CssSelector(".mat-simple-snack-bar-content");
    }

    public static class ProductPage
    {
        public static By AddToBasket(int index) => By.XPath($"//mat-grid-tile[contains(@class, 'ng-star-inserted')][{index}]//button[@aria-label='Add to Basket']");
        public static By CartNumber = By.XPath("//span[@class='fa-layers-counter fa-layers-top-right fa-3x warn-notification']");
        public static By FirstItem = By.XPath("//div[text()=' Apple Juice (1000ml) ']");
    }

    public static class Popup
    {
        public static readonly By Container = By.CssSelector("mat-dialog-container#mat-dialog-1");
        public static readonly By Image = By.CssSelector("mat-dialog-container#mat-dialog-1 img");
        public static readonly By CloseButton = By.XPath("//button[@aria-label='Close Dialog']"); // Consistent XPath
    }

    public static class Review
    {
        public static readonly By ReviewButton = By.XPath("//*[@id='mat-expansion-panel-header-0']"); // Consistent XPath
    }

    public static class BasketPage
    {
        public static By BasketIcon = By.XPath("//span[contains(text(), 'Your Basket')]");
        public static By BasketContainer = By.XPath("//app-purchase-basket");
        public static By IncreaseQuantityButton = By.XPath("//mat-cell[3]/button[2]/span[1]");
        public static By TotalPrice = By.XPath("//*[@id='price']");
        public static By DeleteProductButton = By.XPath("//mat-table/mat-row[1]/mat-cell[5]/button");
        public static By CheckoutButton = By.XPath("//*[@id='checkoutButton']");
    }

    public static class CheckoutPage
    {
        public static By AddressPage = By.XPath("//h1[contains(text(),'address')]");
        public static By AddNewAddressButton = By.XPath("//button[contains(@class, 'btn-new-address')]");
        public static By SelectAddressRadioButton = By.XPath("//mat-radio-button[@id='mat-radio-42']");
        public static By ProceedToPayment = By.XPath("//button[contains(@aria-label, 'Proceed to payment selection')]");
    }

    public static class PaymentPage
    {
        public static By DeliveryMethod = By.XPath("//h1[contains(text(),'Delivery')]");
        public static By DeliveryMethodRadioButton = By.XPath("//mat-radio-button[@class='mat-radio-button mat-accent']");
        public static By ProceedToDeliveryMethod = By.XPath("//button[contains(@aria-label, 'Proceed to delivery method selection')]");
        public static By PaymentOptions = By.XPath("//h1[contains(text(),'My Payment Options')]");
        public static By AddCreditCardButton = By.XPath("//mat-panel-description[contains(text(), 'Add a credit or debit card')]");
    }
}
