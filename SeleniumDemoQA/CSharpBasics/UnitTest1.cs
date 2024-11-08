namespace CSharpBasics
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Car myCar1 = new Car("Red", "Toyota");
            Car myCar2 = new Car("Blue", "BMW");

            Console.WriteLine(myCar1.Color);
            Console.WriteLine(myCar2.Model);
            myCar1.Drive();
            myCar2.Drive();

            //Assert.That(c, Is.EqualTo(30));
     
        }

        [Test]
        public void Should_CheckLoginStatus()
        {
            // Variable
            bool isLoggedIn = false;

            // Simulate a login process
            string username = "testUser";
            string password = "testPassword";

            // If condition
            if (username == "testUser" && password == "testPassword")
            {
                isLoggedIn = true;
            }

            // Assert
            Assert.That(isLoggedIn, Is.True, "The user should be logged in.");
        }

        [Test]
        public void Should_Verify_MultiplePageTitles()
        {
            // Array of expected page titles
            string[] expectedTitles = { "Home", "About Us", "Contact", "Services" };

            // Simulate an array of actual titles fetched during testing
            string[] actualTitles = { "Home", "About Us", "Contact", "Services" };

            // For loop to compare titles
            for (int i = 0; i < expectedTitles.Length; i++)
            {
                Assert.That(actualTitles[i], Is.EqualTo(expectedTitles[i]), $"The title at index {i} should be {expectedTitles[i]}.");
            }
        }

        [Test]
        public void Should_VerifyEachElementIsValid()
        {
            // List of user data
            List<string> userData = new List<string> { "Alice", "Bob", "Charlie" };
            //string[] expectedTitles = { "Home", "About Us", "Contact", "Services" };
            
            userData.Add("New name");
           
            // Foreach loop to check if all names are non-empty
            foreach (var user in userData)
            {
                Assert.That(user, Is.Not.Null, "User name should not be null.");
                Assert.That(user, Is.Not.Empty, "User name should not be empty.");
            }
        }

    }


    public class Car
    {
        public string Color;
        public string Model;

        public Car(string color, string model)
        {
            Color = color;
            Model = model;
        }

        public void Drive()
        {
            Console.WriteLine(Model + " The car is driving.");
        }
    }





}