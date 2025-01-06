using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Linq;
using Utilities;

public class HomePage
{
    private readonly IWebDriver _driver;

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    

    // Locator for the option with text '48' inside the dropdown
   // private IWebElement Option48 => _driver.FindElement(By.XPath("//*[@class='mat-option-text' and contains(text(),'48')]"));
    private IWebElement ScrollElement => _driver.FindElement(By.XPath("//*[ text() = ' Items per page: ']"));

    // Locator for the items displayed on the page (replace with the correct selector for case)
    private ReadOnlyCollection<IWebElement> ItemsOnPage => _driver.FindElements(By.CssSelector(".mat-grid-tile"));


    // Locator for the paginator range label
    private IWebElement PaginatorRangeLabel => _driver.FindElement(By.XPath("//*[@class='mat-paginator-range-label']"));


    // Method to dismiss any alert present
    public void DismissWelcomeBannerIfPresent()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Wait for the welcome banner to be visible
            IWebElement banner = wait.Until(drv => drv.FindElement(By.XPath("//*[@id='mat-dialog-0']")));  // Locator for banner

            // Wait for the close button to be clickable
            IWebElement closeButton = wait.Until(drv => drv.FindElement(By.XPath("//*[@id='mat-dialog-0']/app-welcome-banner/div/div[2]/button[2]/span[1]/span")));  // Locator for close button

            // Click the close button to dismiss the banner
            closeButton.Click();
            Console.WriteLine("Welcome banner dismissed.");
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("No welcome banner found or banner did not appear within timeout.");
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Close button not found in the welcome banner.");
        }
    }

    public void ScrollToBottom()
    {
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", ScrollElement);
    }

    public void ChangeItemsPerPage()
    {
       
        Common.WaitAndClickElement(_driver, By.XPath("//*[@id='mat-select-value-1']"));
        // Wait for the dropdown options to appear (wait for the <mat-option> to be visible)
     
        Common.WaitAndClickElement(_driver, By.XPath("//*[@class='mat-option-text' and contains(text(),'48')]"));

        // Click on the option with text '48'
     
    }
    public int GetNumberOfItemsOnPage()
    {
        // Wait for the items to be loaded on the page after selecting 48 items per page
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".mat-grid-tile")));

        // Return the number of items visible on the page
        return ItemsOnPage.Count;
    }

    public int GetTextAfterOf()
    {
        // Wait for the paginator range label to be visible
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='mat-paginator-range-label']")));

        // Get the full text (e.g., "1 - 48 of 100 items")
        string text = PaginatorRangeLabel.Text;

        // Split the text by "of" and get the number after it
        string[] parts = text.Split(new string[] { "of" }, StringSplitOptions.None);

        if (parts.Length > 1)
        {
            string numberString = parts[1].Trim().Split(' ')[0];

            // Convert the number to integer
            if (int.TryParse(numberString, out int number))
            {
                return number;
            }
        }

        return 0; // Return empty string if the text does not match the expected format
    }
}
