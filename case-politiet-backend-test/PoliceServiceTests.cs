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
            var mockHttpClient = new Mock<HttpClient>();
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
        // Test if retrieves the correct PoliceCar based on the provided ID.
        public async Task GetPoliceCar_ReturnsCorrectCar()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var service = new PoliceService(mockHttpClient.Object);

            // Using reflection to add a sample car to the policeCars static list
            var policeCarsField = typeof(PoliceService).GetField("policeCars", BindingFlags.Static | BindingFlags.NonPublic);
            var policeCarsList = policeCarsField.GetValue(null) as List<PoliceCar>;
            var sampleCar = new PoliceCar { Id = 1 };
            policeCarsList.Add(sampleCar);

            // Act
            var retrievedCar = await service.GetPoliceCar(1);

            // Assert
            Xunit.Assert.Equal(sampleCar.Id, retrievedCar.Id);
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
        // Test if updates status for a specific PoliceCar by its ID.
        public void UpdatePoliceCarStatus_UpdatesCorrectly()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var service = new PoliceService(mockHttpClient.Object);

            // Act
            var updatedCar = service.UpdatePoliceCarStatus(1, "In Repair");

            // Assert
            Xunit.Assert.Equal("In Repair", updatedCar.Status);
        }

        [TestMethod]
        // Test if updates status for a specific PoliceCar by its ID.
        public void UpdatePoliceCarMission_UpdatesCorrectly()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var service = new PoliceService(mockHttpClient.Object);

            // Act
            var updatedCar = service.UpdatePoliceCarMission(1, "New Mission");

            // Assert
            Xunit.Assert.Equal("New Mission", updatedCar.Mission);
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