namespace xUnitTests
{
    public class UserTests
    {
        [Fact]
        public void User_ToString()
        {
            var fullName = "Mile Jovanović";
            var u = new User { FullName = fullName, Username = "jmile" };
            Assert.Contains(fullName, u.ToString());
        }
    }
}