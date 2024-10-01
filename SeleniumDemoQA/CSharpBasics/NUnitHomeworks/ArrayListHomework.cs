using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics.NUnitHomeworks
{
    internal class ArrayListHomework
    {
        
        [Test]
        public void TestSumOfArray()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            int sum = 0; // Replace 0 with the code to calculate sum

            // Assert
            Assert.That(sum, Is.EqualTo(55)); // 1+2+...+10 = 55
        }

        [Test]
        public void TestReverseArray()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] expectedReversed = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Act
            int[] reversedArray = null; // Replace null with code to reverse

            // Assert
            Assert.That(reversedArray, Is.EqualTo(expectedReversed));
        }

        [Test]
        public void TestReplaceStudentName()
        {
            // Arrange
            string[] students = new string[] { "John", "Jane", "Bill", "Sue", "Anna" };
            string newName = "Bob";

            // Act
            // Implement replacement

            // Assert
            Assert.That(students[1], Is.EqualTo(newName)); // Second student's name should be "Bob"
        }

        [TestCase("Sue", true)]
        [TestCase("Alex", false)]
        public void TestStudentNameExists(string nameToCheck, bool existsExpected)
        {
            // Arrange
            string[] students = new string[] { "John", "Jane", "Bill", "Sue", "Anna" };

            // Act
            bool exists = false; // Replace false with code to get to know if nameToCheck exists in students []

            // Assert
            Assert.That(exists, Is.EqualTo(existsExpected));
        }

        [Test]
        public void TestDoubleValues()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expectedDoubled = new List<int> { 2, 4, 6, 8, 10 };

            // Act
            List<int> doubledNumbers = new();
            // Implement code to fill doubledNumbers with values

            // Assert
            Assert.That(doubledNumbers, Is.EqualTo(expectedDoubled));
        }

        [Test]
        public void TestRemoveEvenNumbers()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expectedList = new List<int> { 1, 3, 5 };

            // Act
            // Implement code to remove extra items

            // Assert
            Assert.That(numbers, Is.EqualTo(expectedList));
        }

        [Test]
        public void TestAddAnimal()
        {
            // Arrange
            List<string> animals = new List<string> { "Lion", "Tiger", "Elephant", "Giraffe", "Zebra" };
            string newAnimal = "Penguin";
            List<string> expectedList = new List<string> { "Lion", "Tiger", "Penguin", "Elephant", "Giraffe", "Zebra" };

            // Act
            // Implement code to add new value

            // Assert
            Assert.That(animals, Is.EqualTo(expectedList));
        }

        [Test]
        public void TestSortAnimals()
        {
            // Arrange
            List<string> animals = new List<string> { "Lion", "Tiger", "Elephant", "Giraffe", "Zebra" };
            List<string> expectedList = new List<string> { "Elephant", "Giraffe", "Lion", "Tiger", "Zebra" };

            // Act
            // Implement code to sort list

            // Assert
            Assert.That(animals, Is.EqualTo(expectedList));
        }
    }
}



    

