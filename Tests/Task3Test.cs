
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Utilities;


[TestFixture]
public class Task3Test : BaseTest
{
    [Test]
    public void Test_NavigateToRegistrationPage()
    {
        //navigates to user registration page
        Driver.Navigate().GoToUrl(TestData.BaseUrl);
        homePage.DismissWelcomeBannerIfPresent();
        Common.CloseSnackbarIfPresent(Driver);
        Common.DisMissCookieButtonPresent(Driver);
        registrationPage.NavigateToRegistrationPage();
        ClassicAssert.IsTrue(Driver.Url.Contains("register"));
    }

    [Test]
    public void TestInputValidationMessages()
    {
        /*assert that frontend team added an input validation by clicking on all fields without
        adding any values on it this must trigger a validation message.*/
        Driver.Navigate().GoToUrl(TestData.BaseUrl + "/#/register");
        homePage.DismissWelcomeBannerIfPresent();
        Common.CloseSnackbarIfPresent(Driver);
        Common.DisMissCookieButtonPresent(Driver);
        registrationPage.FillEmptyForm();
        //validate the error messages
        registrationPage.AreValidationMessagesDisplayed();
    }



    [Test]
    public void TestRegistrationAndShowPasswordAdvice()
    {
        // Step 1: Navigate to the registration page
        Driver.Navigate().GoToUrl(TestData.BaseUrl + "/#/register");
        homePage.DismissWelcomeBannerIfPresent();
        Common.CloseSnackbarIfPresent(Driver);
        Common.DisMissCookieButtonPresent(Driver);

        // Step 2: Fill the registration form with test data
        string email = TestData.Registration.GenerateUniqueEmail();
        string password = TestData.Registration.ValidPassword;
        string securityAnswer = TestData.Registration.SecurityAnswer;

        //Step 3: Fill the form field with valid details and open toggle for password
        registrationPage.FillRegistrationForm(email, password, securityAnswer);

        Common.CloseSnackbarIfPresent(Driver);

        
        // Step 4: Submit the registration form (assuming there is a 'Register' button with an id of 'registerButton'
     
        Common.WaitAndClickElement(Driver, By.XPath("//*[@id='registerButton']/span[1]"));

        

        // Step 5: Assert the successful registration

        //Wait for successful registration message or redirection (You may need to adjust the success message element)

        string successMessage= Common.WaitAndGetText(Driver, By.XPath("//*[contains(text(),'Registration completed successfully')]"));

        // Assert that the success message is displayed
        ClassicAssert.IsTrue(!string.IsNullOrEmpty(successMessage), "Registration successful message was not displayed.");

        // Optional: Assert that the URL is now the login page (you may need to adjust the URL or validation criteria)
        ClassicAssert.IsTrue(Driver.Url.Contains("login"), "After registration, user was not redirected to the login page.");
    }
}