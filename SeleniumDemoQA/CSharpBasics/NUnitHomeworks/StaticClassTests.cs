using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics.NUnitHomeworks
{
   public static class MathUtils
    {
        // Static method to add two numbers
        public static int Add(int a, int b)
        {
            return a + b;
        }

        // Static method to find maximum of two numbers
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        // Static field for storing a constant value
        public static readonly double Pi = 3.14159;
    }

    public class Student
    {
        // Static field to count the number of instances
        public static int InstanceCount = 0;

        // Instance property
        public string Name { get; set; }

        // Constructor increments the instance count each time a new object is created
        public Student(string name)
        {
            Name = name;
            InstanceCount++;
        }

        // Static method to validate a student's name
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 2;
        }
    }
    public class ConfigurationManager
    {
        private int i;
        public ConfigurationManager(int index)
        {
            i = index;
        }
        // Static field to hold configuration
        public static string ConfigValue;

        // Static constructor to initialize the static field
        static ConfigurationManager()
        {
            // Assume this value is retrieved from an external source
            ConfigValue = "Default Configuration Value";
            Console.WriteLine("Static constructor called. Configuration initialized.");
        }
    }

    public class Singleton
    {
        // Static field to hold the single instance of the class
        private static readonly Singleton _instance;

        // Public property to get the instance
        public static Singleton Instance => _instance;

        // Private constructor to prevent instantiation
        private Singleton()
        {
            Console.WriteLine("Singleton instance created.");
        }

        // Static constructor to initialize the singleton instance
        static Singleton()
        {
            _instance = new Singleton();
            Console.WriteLine("Static constructor called. Singleton initialized.");
        }
    }

    public class AppSettings
    {
        // Static dictionary to hold settings
        public static readonly Dictionary<string, string> Settings = new Dictionary<string, string>() { { "AppName", "asd" } };

        // Static constructor to load settings
        static AppSettings()
        {
            Settings = new Dictionary<string, string>
            {
                { "AppName", "MyApplication" },
                { "Version", "1.0.0" }
            };
            Console.WriteLine("Static constructor called. Settings loaded.");
        }
        public void Print()
        {
            Console.WriteLine("qwe");
        }
    }

    internal class StaticClassTests
    {
        [Test] // Test case for the Add method
        public void Add_ShouldReturnSumOfTwoNumbers()
        {
            // Act
            int result = MathUtils.Add(3, 5);

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        [Test] // Test case for the Max method
        public void Max_ShouldReturnTheLargerNumber()
        {
            // Act
            int result1 = MathUtils.Max(4, 7);
            int result2 = MathUtils.Max(10, 2);

            // Assert
            Assert.That(result1, Is.EqualTo(7));
            Assert.That(result2, Is.EqualTo(10));
        }

        [Test] // Test case for the static field Pi
        public void Pi_ShouldBeEqualToExpectedValue()
        {
            // Assert
            Assert.That(MathUtils.Pi, Is.EqualTo(3.14159));
        }


        [Test]
        public void InstanceCount_ShouldIncrease_WhenNewStudentsAreCreated()
        {
            // Arrange
            int initialCount = Student.InstanceCount;

            // Act
            var student1 = new Student("Alice");
            var student2 = new Student("Bob");

            // Assert
            Assert.That(Student.InstanceCount, Is.EqualTo(initialCount + 2));
        }

        [Test]
        public void IsValidName_ShouldReturnTrue_WhenNameIsValid()
        {
            // Act
            bool result = Student.IsValidName("Alice");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidName_ShouldReturnFalse_WhenNameIsEmpty()
        {
            // Act
            bool result = Student.IsValidName("");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ConfigValue_ShouldBeInitialized_WhenClassIsFirstAccessed()
        {
            // Act
            var instance1 = new ConfigurationManager(12);
            var instance2 = new ConfigurationManager(12);
            string value = ConfigurationManager.ConfigValue;

            // Assert
            Assert.That(value, Is.EqualTo("Default Configuration Value"));
        }

        [Test]
        public void SingletonInstance_ShouldBeSameAcrossCalls()
        {
            // Act
            var instance1 = Singleton.Instance;
            var instance2 = Singleton.Instance;

            // Assert
            Assert.That(instance2, Is.SameAs(instance1));
        }

        [Test]
        public void Settings_ShouldContainPredefinedValues_WhenClassIsFirstAccessed()
        {
            // Act
            string appName = AppSettings.Settings["AppName"];
            string version = AppSettings.Settings["Version"];

            // Assert
            Assert.That(appName, Is.EqualTo("MyApplication"));
            Assert.That(version, Is.EqualTo("1.0.0"));
        }
    }
}
