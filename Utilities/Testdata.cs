using NUnit.Framework;

[TestFixture]
public class TestData
{
    public const string BaseUrl = "https://juice-shop.herokuapp.com";

 
    public const string CardHolderName = "John Doe";
    public static class Login
    {
        public static readonly string Username = "test14@gmail.com";
        public static readonly string Password = "Dubai@123";
    }

    public static class Address
    {
        public static readonly string Country = "USA";
        public static readonly string Name = "John Doe";
        public static readonly string Mobile = "1234567890";
        public static readonly string Zipcode = "10001";
        public static readonly string AddressLine1 = "123 Main Street";
        public static readonly string City = "New York";
        public static readonly string State = "NY";
    }

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

