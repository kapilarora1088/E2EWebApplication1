using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Utilities;

namespace YourProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        // Constructor to initialize the WebDriver
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Method to log in
        public void Login(string email, string password)
        {
            // Wait for the email field and input the email
            var emailField = _driver.WaitForElementClickable(By.Id("email"), 10);
            emailField.SendKeys(email);

            // Wait for the password field and input the password
            var passwordField = _driver.WaitForElementClickable(By.Id("password"), 10);
            passwordField.SendKeys(password);

            // Wait for the Login button and click it
            var loginButton = _driver.WaitForElementClickable(By.Id("loginButton"), 10);
            loginButton.Click();
        }
    }
}
