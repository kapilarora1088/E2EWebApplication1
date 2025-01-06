using OpenQA.Selenium;

public class Locators
{

    public static class HomePageLocators
    {
        public static By WelcomeBanner { get; } = By.XPath("//*[@id='mat-dialog-0']");
        public static By WelcomeBannerCloseButton { get; } = By.XPath("//*[@id='mat-dialog-0']/app-welcome-banner/div/div[2]/button[2]/span[1]/span");
        public static By ScrollElement { get; } = By.XPath("//*[ text() = ' Items per page: ']");
        public static By ItemsOnPage { get; } = By.CssSelector(".mat-grid-tile");
        public static By ItemsPerPageDropdown { get; } = By.XPath("//*[@id='mat-select-value-1']"); // Assuming this is the correct locator for the dropdown

        public static By ItemsPerPageOption48 { get; } = By.XPath("//*[@class='mat-option-text' and contains(text(),'48')]"); // Assuming this is the correct locator for the dropdown 
        public static By PaginatorRangeLabel = By.XPath("//*[@class='mat-paginator-range-label']");
    }
        public static class CommonSnackBar
    {
        public static By SuccessPopup = By.CssSelector(".mat-simple-snack-bar-content");
    }

    public static class ProductPageLocators
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
    public static class CartPageLocators
    {
        public static readonly By CartNumberXPath = By.XPath("//span[@class='fa-layers-counter fa-layers-top-right fa-3x warn-notification']");
    }

    public static class BasketPageLocators
    {
        public static By BasketIcon = By.XPath("//span[contains(text(), 'Your Basket')]");
        public static By BasketContainer = By.XPath("//app-purchase-basket");
        public static By IncreaseQuantityButton = By.XPath("//mat-cell[3]/button[2]/span[1]");
        public static By TotalPrice = By.XPath("//*[@id='price']");
        public static By DeleteProductButton = By.XPath("//mat-table/mat-row[1]/mat-cell[5]/button");
       // public static By CheckoutButton = By.XPath("//*[@id='checkoutButton']");


        public static readonly By SuccessPopupCssSelector = By.CssSelector(".mat-simple-snack-bar-content");
        public static readonly By CheckoutButton = By.XPath("//*[@id='checkoutButton']");
        public static readonly By AddressPageHeader = By.XPath("//h1[contains(text(),'address')]");
        public static readonly By AddAddressButton = By.XPath("//button[contains(@class, 'btn-new-address')]");
        public static readonly By AddNewAddressHeader = By.XPath("//h1[contains(text(),'Add New Address')]");
    }


    public static class CheckoutPageLocators
    {
        public static readonly By SelectAddressRadioButton = By.XPath("//mat-radio-button[@id='mat-radio-42']"); // Replace with a more dynamic locator if possible
        public static readonly By ProceedToPaymentButton = By.XPath("//button[contains(@aria-label, 'Proceed to payment selection')]");
        public static readonly By DeliveryPageHeader = By.XPath("//h1[contains(text(),'Delivery')]");

        public static readonly By DeliverySpeedRadioButton = By.XPath("//mat-radio-button[@class='mat-radio-button mat-accent']");
        public static readonly By ContinueButtonOnDeliveryPage = By.XPath("//span[text()='Continue']");

        public static readonly By PaymentPageHeader = By.XPath("//h1[contains(text(),'My Payment Options')]");
        public static readonly By AddCreditCardOption = By.XPath("//mat-panel-description[contains(text(), 'Add a credit or debit card')]");
        public static readonly By SelectCreditCardRadioButton = By.XPath("//*[@class='mat-ripple mat-radio-ripple mat-focus-indicator']");
    }

    public static class PaymentPageLocators
    {
        public static By DeliveryMethod = By.XPath("//h1[contains(text(),'Delivery')]");
        public static By DeliveryMethodRadioButton = By.XPath("//mat-radio-button[@class='mat-radio-button mat-accent']");
        public static By ProceedToDeliveryMethod = By.XPath("//button[contains(@aria-label, 'Proceed to delivery method selection')]");
        public static By PaymentOptions = By.XPath("//h1[contains(text(),'My Payment Options')]");
        public static By AddCreditCardButton = By.XPath("//mat-panel-description[contains(text(), 'Add a credit or debit card')]");
    }
    public static class RegistrationPageLocators
    {
        public static readonly By EmailField = By.Id("emailControl");
        public static readonly By PasswordField = By.Id("passwordControl");
        public static readonly By RepeatPasswordField = By.Id("repeatPasswordControl");
        public static readonly By SecurityQuestionDropdown = By.XPath("//*[@id='mat-select-0']"); // Adjust XPath if needed
        public static readonly By SecurityAnswerField = By.Id("securityAnswerControl");
        public static readonly By TermsCheckbox = By.XPath("//*[@id='mat-slide-toggle-1-input']"); // Assuming a checkbox for terms
        public static readonly By RegisterButton = By.XPath("//*[@id='registerButton']/span[1]"); // Consistent XPath
        public static readonly By Snackbar = By.ClassName("mat-simple-snack-bar-content"); // Wait for snackbar invisibility
    }
}
