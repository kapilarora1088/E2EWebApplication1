
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Utilities;

[TestFixture]
public class Task1Test : BaseTest
{
    [Test]
    public void VerifyItemsPerPageChange()
    {
        Driver.Navigate().GoToUrl(TestData.BaseUrl);
        var homePage = new HomePage(Driver);
       
        homePage.DismissWelcomeBannerIfPresent();
        Common.CloseSnackbarIfPresent(Driver);
        Common.DisMissCookieButtonPresent(Driver);
        homePage.ScrollToBottom();
        
        homePage.ChangeItemsPerPage();

        int numberOfItems = homePage.GetNumberOfItemsOnPage();
        int totalItems = homePage.GetTextAfterOf();

        Console.WriteLine(numberOfItems + "  " + totalItems);
        ClassicAssert.AreEqual(totalItems, numberOfItems, "The expected number of items was not found");
    }
}







