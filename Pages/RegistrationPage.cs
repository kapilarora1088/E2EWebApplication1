using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class RegistrationPage
{
    private IWebDriver Driver;
    private WebDriverWait wait;

    // Constructor to initialize the driver
    public RegistrationPage(IWebDriver driver)
    {
        Driver = driver;
    }

    // Method to navigate to the registration page
    public void NavigateToRegistrationPage()
    {
        // Click on account element to open the account menu
        NavigateToLoginPage();

        // Click on the new customer link to go to the registration page
        var newCustomer = Driver.FindElement(By.XPath("//*[@id='newCustomerLink']/a"));
        newCustomer.Click();
    }

    public void NavigateToLoginPage()
    {
        // Click on account element to open the account menu
        var account = Driver.FindElement(By.XPath("//*[@id='navbarAccount']"));
        account.Click();

        // Click on login button to go to the login page
        var login = Driver.FindElement(By.XPath("//*[@id='navbarLoginButton']"));
        login.Click();

    }
    public void AreValidationMessagesDisplayed()
    {
        // Assert that each field has a validation error message
        var emailErrorMessage = Driver.FindElement(By.XPath("//*[@id='mat-error-0']"));
        ClassicAssert.IsTrue(emailErrorMessage.Displayed, "Email field validation error message did not appear.");

        var passwordErrorMessage = Driver.FindElement(By.XPath("//*[@id='mat-error-1']"));
        ClassicAssert.IsTrue(passwordErrorMessage.Displayed, "Password field validation error message did not appear.");

        var repeatPasswordErrorMessage = Driver.FindElement(By.XPath("//*[@id='mat-error-2']"));
        ClassicAssert.IsTrue(repeatPasswordErrorMessage.Displayed, "Repeat Password field validation error message did not appear.");

        var securityQuestionErrorMessage = Driver.FindElement(By.XPath("//*[@id='mat-error-3']"));
        ClassicAssert.IsTrue(securityQuestionErrorMessage.Displayed, "Security Question field validation error message did not appear.");

        var securityAnswerErrorMessage = Driver.FindElement(By.XPath("//*[@id='mat-error-4']"));
        ClassicAssert.IsTrue(securityAnswerErrorMessage.Displayed, "Security Answer field validation error message did not appear.");
    }

    public void ClickAndSendKeys(By locator, string value)
    {
        var field = Driver.FindElement(locator);
        field.Click();  // Click the field
        field.SendKeys(value);  // Send keys to the field
        field.SendKeys(Keys.Tab);  // Move focus away to trigger validation
    }

    public void ClickAndKeys(By locator, string value)
    {
        var element = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
         .Until(ExpectedConditions.ElementToBeClickable(locator)); // Wait until the element is clickable

        // Check if element is not null or hidden
        if (element != null && element.Displayed && element.Enabled)
        {
            element.Click();
            element.SendKeys(value); // or any other keys if required
        }
        else
        {
            Console.WriteLine("Element is either not visible or not interactable.");
        }

    }

    public void ClickAndSendKeysTab(By locator, string value, bool sendTab = true)
    {
        var element = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementToBeClickable(locator));

        if (element != null && element.Displayed && element.Enabled)
        {
            element.Click();
            element.SendKeys(value);

            if (sendTab)
            {
                element.SendKeys(Keys.Tab); // Move focus away to trigger validation (optional)
            }
        }
        else
        {
            Console.WriteLine($"Element with locator '{locator.ToString()}' is either not visible or not interactable.");
        }
    }


    public void ClickToggleWithWait(By toggleLocator)
    {
        // Wait for the toggle to be clickable
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        var passwordAdviceToggle = wait.Until(ExpectedConditions.ElementToBeClickable(toggleLocator));

        // Ensure the toggle is visible before interacting
        ClassicAssert.IsTrue(passwordAdviceToggle.Displayed, "Password advice toggle is not visible");

        // Get the initial state of the toggle (whether it is already "on" or "off")
        string initialToggleState = passwordAdviceToggle.GetAttribute("aria-checked");

        // Use Actions to move to the element and perform the click
        Actions actions = new Actions(Driver);
        actions.MoveToElement(passwordAdviceToggle).Click().Perform();

        // Wait for the action to complete and verify the toggle's new state
        WebDriverWait toggleWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        toggleWait.Until(ExpectedConditions.ElementToBeClickable(toggleLocator));

        // After clicking, verify if the toggle state has changed
        string finalToggleState = passwordAdviceToggle.GetAttribute("aria-checked");

        // Assert that the toggle state has changed from false to true (or vice versa)
        ClassicAssert.AreNotEqual(initialToggleState, finalToggleState, "Toggle state did not change after click.");

        // Optionally, assert the final state if you know what the correct value should be
        ClassicAssert.AreEqual(finalToggleState, "true", "Toggle was not switched on successfully.");
    }

    public void FillEmptyForm()
    {
        Driver.FindElement(By.Id("emailControl")).SendKeys("");
        Driver.FindElement(By.Id("passwordControl")).SendKeys("");
        Driver.FindElement(By.Id("repeatPasswordControl")).SendKeys("");
        Driver.FindElement(By.XPath("//*[@id='mat-select-0']")).SendKeys(Keys.Escape);
        Driver.FindElement(By.Id("securityAnswerControl")).SendKeys("");
        Driver.FindElement(By.Id("securityAnswerControl")).SendKeys(Keys.Tab);
    }

    public void FillRegistrationForm(string email, string password, string securityAnswer)
    {
        ClickAndSendKeysTab(Locators.RegistrationPage.EmailField, email);
        ClickAndSendKeysTab(Locators.RegistrationPage.PasswordField, password);
        ClickAndSendKeysTab(Locators.RegistrationPage.RepeatPasswordField, password);
        ClickToggleWithWait(Locators.RegistrationPage.TermsCheckbox); // Assuming terms checkbox

        // Select security question (adjust XPath if needed)
        ClickAndKeys(Locators.RegistrationPage.SecurityQuestionDropdown, Keys.Tab);

        ClickAndSendKeysTab(Locators.RegistrationPage.SecurityAnswerField, securityAnswer);
    }

    public void FillRegistrationForm1(string email = "", string password = "", string securityAnswer = "")
    {
        ClickAndSendKeysTab(Locators.RegistrationPage.EmailField, email);
        ClickAndSendKeysTab(Locators.RegistrationPage.PasswordField, password);
        ClickAndSendKeysTab(Locators.RegistrationPage.RepeatPasswordField, password);
        ClickToggleWithWait(Locators.RegistrationPage.TermsCheckbox); // Assuming terms checkbox

        // Select security question (adjust XPath if needed) - Assuming Escape key works for clearing the dropdown
        ClickAndKeys(Locators.RegistrationPage.SecurityQuestionDropdown, Keys.Escape);

        ClickAndSendKeysTab(Locators.RegistrationPage.SecurityAnswerField, securityAnswer);
    }


}
