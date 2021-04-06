using System.Collections.Generic;
using LOR.Pizzeria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LOR.PizzeriaTests
{
    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void CommaSeparatedList_Correct_Response_Test()
        {
            // Arrange
            var list = new List<string> { "x", "y", "z" };
            
            // Act
            var output = Utility.CommaSeparatedList(list);

            // Assert
            Assert.AreEqual(output, "x, y, z");
        }

        [TestMethod]
        public void CommaSeparatedList_Incorrect_Response_Test1()
        {
            // Arrange
            var list = new List<string> { "x", "y", "z" };

            // Act
            var output = Utility.CommaSeparatedList(list);

            // Assert
            Assert.AreNotEqual(output, "x,y,z");
        }

        [TestMethod]
        public void CommaSeparatedList_Incorrect_Response_Test2()
        {
            // Arrange
            var list = new List<string> { "x", "y", "z" };

            // Act
            var output = Utility.CommaSeparatedList(list);

            // Assert
            Assert.AreNotEqual(output, "xyz");
        }

        [TestMethod]
        public void Baking_Instructions_Test()
        {
            // Arrange
            var input = "I'm testing baking notes";

            // Act
            var output = Utility.Bake(input);

            // Assert
            Assert.AreEqual(output, input);
        }

        [TestMethod]
        public void Baking_Default_Instructions_Test()
        {
            // Arrange
            var input = "I'm testing baking notes";

            // Act
            var output = Utility.Bake();

            // Assert
            Assert.AreEqual(output, "Baking pizza for 30 minutes at 200 degrees...");
        }

        [TestMethod]
        public void Cutting_Instructions_Test()
        {
            // Arrange
            var input = "I'm testing cutting notes";

            // Act
            var output = Utility.Cut(input);

            // Assert
            Assert.AreEqual(output, input);
        }

        [TestMethod]
        public void Cutting_Default_Instructions_Test()
        {
            // Arrange
            var input = "I'm testing cutting notes";

            // Act
            var output = Utility.Cut();

            // Assert
            Assert.AreEqual(output, "Cutting pizza into 8 slices...");
        }
    }
}