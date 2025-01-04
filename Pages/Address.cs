using OpenQA.Selenium;

public class Address
{
    private readonly IWebDriver _driver;

    // Constructor
    public Address(IWebDriver driver)
    {
        _driver = driver;
    }

    // Web Elements
    private IWebElement CountryField => _driver.FindElement(By.XPath("//*[@id='mat-input-3']"));
    private IWebElement NameField => _driver.FindElement(By.XPath("//*[@id='mat-input-4']"));
    private IWebElement MobileField => _driver.FindElement(By.XPath("//*[@id='mat-input-5']"));
    private IWebElement ZipcodeField => _driver.FindElement(By.XPath("//*[@id='mat-input-6']"));
    private IWebElement AddressField => _driver.FindElement(By.XPath("//*[@id='address']"));
    private IWebElement CityField => _driver.FindElement(By.XPath("//*[@id='mat-input-8']"));
    private IWebElement StateField => _driver.FindElement(By.XPath("//*[@id='mat-input-9']"));
    private IWebElement SubmitButton => _driver.FindElement(By.XPath("//*[@id='submitButton']/span[1]")); // Update selector as per your DOM

    // Method to Add Address
    public void AddAddress(string country, string name, string mobile, string zipcode, string address, string city, string state)
    {
        CountryField.SendKeys(country);
        NameField.SendKeys(name);
        MobileField.SendKeys(mobile);
        ZipcodeField.SendKeys(zipcode);
        AddressField.SendKeys(address);
        CityField.SendKeys(city);
        StateField.SendKeys(state);

        // Click the submit button to save the address
        SubmitButton.Click();
    }
}
