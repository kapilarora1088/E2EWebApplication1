using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V129.Autofill;
using OpenQA.Selenium.Support.UI;
using YourProject.Pages;

public class BaseTest
{
    protected IWebDriver Driver;
    protected WebDriverWait _wait;
    protected RegistrationPage registrationPage;
    protected HomePage homePage;
    protected Address add;
    protected PaymentPage _paymentPage;
    protected LoginPage loginPage;  
    protected BasketPage basketPage;

    [SetUp]
    public void Setup()
    {
        Driver = DriverFactory.GetDriver();

        // Initialize Page Objects
        registrationPage = new RegistrationPage(Driver);
        homePage = new HomePage(Driver);
        add=new Address(Driver);
        _paymentPage =new PaymentPage(Driver);
        loginPage = new LoginPage(Driver);
        basketPage = new BasketPage(Driver);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}
