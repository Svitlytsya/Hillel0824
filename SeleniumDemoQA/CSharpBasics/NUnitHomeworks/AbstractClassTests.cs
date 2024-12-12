using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics.NUnitHomeworks
{
    public abstract class Shape
    {
        // Abstract method
        public abstract double Area();

        // Regular method with implementation
        public void DisplayShape()
        {
            Console.WriteLine("This is a shape.");
        }
    }

    public class Circle2 : Shape
    {
        private double _radius;

        public Circle2(double radius)
        {
            _radius = radius;
        }

        // Implementing the abstract method
        public override double Area()
        {
            return Math.PI * _radius * _radius;
        }
    }

    public class Rectangle2 : Shape
    {
        private double _width;
        private double _height;

        public Rectangle2(double width, double height)
        {
            _width = width;
            _height = height;
        }

        // Implementing the abstract method
        public override double Area()
        {
            return _width * _height;
        }
    }


    internal class AbstractClassTests
    {
        [Test]
        public void Circle_Area_ShouldReturnCorrectResult()
        {
            // Arrange
            Circle2 circle = new Circle2(5);  // Radius = 5

            // Act
            double area = circle.Area();

            // Assert
            Assert.AreEqual(Math.PI * 25, area);
        }

        [Test]
        public void Rectangle_Area_ShouldReturnCorrectResult()
        {
            // Arrange
            Rectangle2 rectangle = new Rectangle2(4, 6);  // Width = 4, Height = 6

            // Act
            double area = rectangle.Area();

            // Assert
            Assert.AreEqual(24, area);
        }

        [Test]
        public void DisplayShape_Method_ShouldWork()
        {
            // Arrange
            Circle2 circle = new Circle2(3);
            Rectangle2 rectangle = new Rectangle2(2, 5);

            // Act and Assert
            // Calling DisplayShape, which is not abstract but is defined in the base class
            circle.DisplayShape();
            rectangle.DisplayShape();

            // Normally, we'd check output in the console, 
            // but since it's not possible to assert console output directly in NUnit,
            // this is just for illustration.
        }
    }
}
