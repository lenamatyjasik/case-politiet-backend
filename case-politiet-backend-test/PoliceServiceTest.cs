using Domain;
using Moq;
using Services;
using System.Reflection;
using Xunit;

namespace case_politiet_backend_test
{
    [TestClass]
    public class PoliceCarServiceTest
    {
        [TestMethod]
        // Test the constructor to ensure that it initializes the _client field and fetches the list of PoliceCar objects correctly.
        public void Constructor_InitializesCorrectly()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();

            // Act
            var service = new PoliceService(mockHttpClient.Object);

            // Use reflection to get the value of the _client field
            var clientField = service.GetType().GetField("_client", BindingFlags.Instance | BindingFlags.NonPublic);
            var clientValue = clientField.GetValue(service);

            // Use reflection to get the value of the policeCars static field
            var policeCarsField = typeof(PoliceService).GetField("policeCars", BindingFlags.Static | BindingFlags.NonPublic);
            var policeCarsValue = policeCarsField.GetValue(null) as List<PoliceCar>;

            // Assert
            Xunit.Assert.NotNull(clientValue);
            Xunit.Assert.NotNull(policeCarsValue);
            Xunit.Assert.True(policeCarsValue.Count > 0);  // Assuming the external service always returns some cars
        }

       

        [TestMethod]
        // Test if retrieves the correct list of PoliceCar objects based on the provided criteria.
        public async Task GetPoliceCars_ReturnsCorrectList()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var service = new PoliceService(mockHttpClient.Object);

            // Act
            var cars = await service.GetPoliceCars(status: "Available");

            // Assert
            Xunit.Assert.All(cars, car => Xunit.Assert.Equal("Available", car.Status));
        }
              

        [TestMethod]
        // Test if new PoliceCar is added correctly and is assigned new ID.
        public async Task AddPoliceCar_AddsCorrectly()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var service = new PoliceService(mockHttpClient.Object);
            var newCar = new PoliceCar { Brand = "Toyota", Model = "Corolla" };

            // Act
            var addedCar = await service.AddPoliceCar(newCar);

            // Assert
            Xunit.Assert.True(addedCar.Id > 0);
            Xunit.Assert.Equal("Toyota", addedCar.Brand);
            Xunit.Assert.Equal("Corolla", addedCar.Model);
        }

        [TestMethod]
        // Test if PoliceCar is deleted correctly based on its ID.
        public async Task DeletePoliceCar_DeletesCorrectly()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var service = new PoliceService(mockHttpClient.Object);
            var newCar = new PoliceCar { Brand = "Toyota", Model = "Corolla" };

            // Act
            await service.DeletePoliceCar(1);

            // Assert
            var retrievedCar = await service.GetPoliceCar(1);
            Xunit.Assert.Null(retrievedCar);
        }



    }
}