using System;
using System.Linq;
using System.Threading.Tasks;
using LOR.Repositories;
using LOR.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LOR.ServicesTests
{
    [TestClass]
    public class PizzaServiceTests
    {
        private Mock<IPizzaRepository> _mockPizzaRepository;
        private IPizzaService _pizzaService;

        [TestInitialize]
        public void Initialize()
        {
            _mockPizzaRepository = new Mock<IPizzaRepository>();
            _pizzaService = new PizzaService(_mockPizzaRepository.Object);
        }

        [TestMethod]
        public async Task GetLocationsAsync_Test()
        {
            // Arrange
            _mockPizzaRepository.Setup(x => x.GetLocationsAsync()).ReturnsAsync(MockDatabase.Locations);

            // Act
            var locations = await _pizzaService.GetLocationsAsync();

            // Assert
            _mockPizzaRepository.Verify(x => x.GetLocationsAsync(), Times.Once());
            Assert.AreEqual(locations.Count(), MockDatabase.Locations.Count());
        }

        [TestMethod]
        public async Task GetMenuAsync_Test()
        {
            // Arrange
            _mockPizzaRepository.Setup(x => x.GetMenuAsync()).ReturnsAsync(MockDatabase.Menu);

            // Act
            var menu = await _pizzaService.GetMenuAsync(2);

            // Assert
            _mockPizzaRepository.Verify(x => x.GetMenuAsync(), Times.Once());
            Assert.AreEqual(3, menu.Count());
            Assert.AreEqual( 21.00, menu.FirstOrDefault(x => x.PizzaTypeId == 2).Price);
        }

        [TestMethod]
        public void GetOrderPrice_Returns_Price_Test()
        {
            // Arrange
            var menu = MockDatabase.Menu;

            // Act
            var price = _pizzaService.GetOrderPrice(menu, 2, 2, 3);

            // Assert
            Assert.AreEqual(63, price);
        }

        [TestMethod]
        public void GetOrderPrice_Returns_Zero_Test()
        {
            // Arrange
            var menu = MockDatabase.Menu;

            // Act
            var price = _pizzaService.GetOrderPrice(menu, 2, 3, 0);

            // Assert
            Assert.AreEqual(0, price);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetOrderPrice_Returns_Error_Test()
        {
            // Arrange
            var menu = MockDatabase.Menu;

            // Act
            var price = _pizzaService.GetOrderPrice(menu, 1, 2, 3);

            // Assert
            Assert.AreEqual(63, price);
        }
    }
}