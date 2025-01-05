using NUnit.Framework;

[TestFixture]
public class TestData
{
    public const string BaseUrl = "https://juice-shop.herokuapp.com";
    public const string Username = "test7@gmail.com";
    public const string Password = "Dubai@123";
    public const string Country = "USA";
    public const string Name = "John Doe";
    public const string Mobile = "1234567890";
    public const string Zipcode = "10001";
    public const string Address = "123 Main Street";
    public const string City = "New York";
    public const string State = "NY";
    public const string CardHolderName = "John Doe";

    public static class Registration
    {
        public static string GenerateUniqueEmail()
        {
            return $"testuser{DateTime.Now.Ticks}@example.com";
        }

        public static string ValidPassword = "TestPassword123!";
        public static string InvalidPassword = "weakpassword"; // Example invalid password
        public static string SecurityAnswer = "MyAnswer"; // Example security answer
    }
}

