using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleLib.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void IsRightTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 8, 10));
        }

        [TestMethod]
        public void AllSidesIsZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void AllSidesIsNegative()
        {
            Assert.IsFalse(Triangle.IsTriangle(-5, -8, -10));
        }

        [TestMethod]
        public void IsTrianglePossible()
        {
            Assert.IsFalse(Triangle.IsTriangle(19, 10, 5));
        }

        [TestMethod]
        public void OneSideIsZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 3, 7));
        }

        [TestMethod]
        public void OneSideIsNegative()
        {
            Assert.IsFalse(Triangle.IsTriangle(3, -4, 5));
        }

        [TestMethod]
        public void IsTriangleIsoscelesTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 5, 7));
        }

        [TestMethod]
        public void IsTriangleEquilateralTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 5, 5));
        }

        [TestMethod]
        public void IsAnotherRightTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(4, 7, 10));
        }

        [TestMethod]
        public void IsAndAnotherRightTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(2, 4, 6));
        }
    }
}
