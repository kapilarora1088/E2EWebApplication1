using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

public static class DriverFactory
{
    public static IWebDriver GetDriver()
    {

        ChromeOptions options = new ChromeOptions();

        // Block location requests

        options.AddArgument("start-maximized");
        options.AddArgument("test-type");
        options.AddArgument("disable-notifications");
        options.AddUserProfilePreference("autofill.profile_enabled", false);


        // Get the path to the Drivers folder
        var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        var driverPath = Path.Combine(projectRoot, "Drivers");

        // Initialize ChromeDriver
        
        options.AddArgument("--start-maximized"); // Optional: Open browser maximized

        // Return WebDriver instance pointing to the driverPath
        return new ChromeDriver(driverPath, options, TimeSpan.FromSeconds(240));
    }
}
