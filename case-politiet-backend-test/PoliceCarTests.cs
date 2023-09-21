using System.Text.Json;
using Domain;
using Xunit;

namespace case_politiet_backend_test
{
    [TestClass]
    public class PoliceCarTests
    {
      
        [TestMethod]
        public void Serialization_Deserialization_WorksCorrectly()
        {
            // Arrange
            var policeCar = new PoliceCar
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Camry",
                ModelYear = 2022,
                RegistrationNumber = "ABC-123",
                Status = "Available",
                Mission = "Patrol"
            };

            // Act
            var jsonString = JsonSerializer.Serialize(policeCar);
            var deserializedCar = JsonSerializer.Deserialize<PoliceCar>(jsonString);

            // Assert
            Xunit.Assert.Equal(policeCar.Id, deserializedCar.Id);
            Xunit.Assert.Equal(policeCar.Brand, deserializedCar.Brand);
            Xunit.Assert.Equal(policeCar.Model, deserializedCar.Model);
            Xunit.Assert.Equal(policeCar.ModelYear, deserializedCar.ModelYear);
            Xunit.Assert.Equal(policeCar.RegistrationNumber, deserializedCar.RegistrationNumber);
            Xunit.Assert.Equal(policeCar.Status, deserializedCar.Status);
            Xunit.Assert.Equal(policeCar.Mission, deserializedCar.Mission);
        }
    }
}