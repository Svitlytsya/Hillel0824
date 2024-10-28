using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics.NUnitHomeworks
{
    // Value type (struct)
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // Reference type (class)
    public class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Override Equals to compare properties instead of references
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Person2 other = (Person2)obj;
            return Name == other.Name && Age == other.Age;
        }

        public override int GetHashCode()
        {
            return (Name, Age).GetHashCode();
        }
    }


    internal class EqualsTests
    {
        // Test for value type (Point is a struct)
        [Test]
        public void ValueType_Equals_ReturnsTrueForSameValues()
        {
            var s1 = "qwe";
            var s2 = "qwe";
            Assert.That(5, Is.EqualTo(5));
            Assert.That(s1.Equals(s2));
            Assert.That(s1 == s2);

            var a = 5.Equals(5);

            Point p1 = new Point { X = 5, Y = 10 };
            Point p2 = new Point { X = 5, Y = 10 };

            // Value types compare based on value
            Assert.That(p1.Equals(p2), Is.True);
            Assert.That(p2, Is.EqualTo(p1));  // This uses the Equals method internally
        }

        [Test]
        public void ValueType_Equals_ReturnsFalseForDifferentValues()
        {
            Point p1 = new Point { X = 5, Y = 10 };
            Point p2 = new Point { X = 10, Y = 20 };

            Assert.That(p1.Equals(p2), Is.False);
            Assert.That(p2, Is.Not.EqualTo(p1));
        }

        // Test for reference type (Person2 is a class)
        [Test]
        public void ReferenceType_DefaultEquals_ReturnsFalseForDifferentInstances()
        {
            Person2 p1 = new Person2 { Name = "John", Age = 30 };
            Person2 p2 = new Person2 { Name = "John", Age = 30 };

            // Without overriding Equals, this would check for reference equality (false)
            Assert.That(object.ReferenceEquals(p1, p2), Is.False);  // Different instances
        }

        [Test]
        public void ReferenceType_OverrideEquals_ReturnsTrueForSameValues()
        {
            Person2 p1 = new Person2 { Name = "John", Age = 30 };
            Person2 p2 = new Person2 { Name = "John", Age = 30 };

            // With overridden Equals, this checks for value equality (true)
            Assert.That(p1.Equals(p2), Is.True);
            //Assert.That(p1 == p2, Is.True);
            Assert.That(p2, Is.EqualTo(p1));  // Same effect, uses Equals
        }

        [Test]
        public void ReferenceType_OverrideEquals_ReturnsFalseForDifferentValues()
        {
            Person2 p1 = new Person2 { Name = "John", Age = 30 };
            Person2 p2 = new Person2 { Name = "Jane", Age = 25 };

            Assert.That(p1.Equals(p2), Is.False);
            Assert.That(p2, Is.Not.EqualTo(p1));
        }

        // Test for List<T> equality
        [Test]
        public void ListOfT_DefaultEquals_ReturnsFalseForSameValues()
        {
            List<int> list1 = new List<int> { 1, 2, 3 };
            List<int> list2 = new List<int> { 1, 2, 3 };

            // Even though the lists contain the same values, they are different instances.
            Assert.IsFalse(list1.Equals(list2));
            Assert.AreEqual(list2, list1);
        }

        [Test]
        public void ListOfT_DefaultReferenceEquality_ReturnsTrueForSameInstance()
        {
            List<int> list1 = new List<int> { 1, 2, 3 };
            List<int> list2 = list1; // Pointing list2 to the same instance as list1

            // Reference equality: since both point to the same instance, they are considered equal.
            Assert.IsTrue(list1.Equals(list2));
            Assert.That(list2, Is.EqualTo(list1));
        }
    }
}
