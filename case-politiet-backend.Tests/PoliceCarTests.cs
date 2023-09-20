using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;



namespace case_politiet_backend.Tests
{
    namespace Domain.Tests
    {
        public class PoliceCarTests
        {
            public void SerializeToJson()
            {
                // Arrange
                // Create a PoliceCar object with sample data
                var policeCar = new PoliceCar
                {
                    Id = 1,
                    Brand = "Ford",
                    Model = "Interceptor",
                    ModelYear = 2022,
                    RegistrationNumber = "ABC123",
                    Status = "On Duty",
                    Mission = "Patrol"
                };

                // Act
                // Serialize the PoliceCar object to JSON format
                string json = JsonSerializer.Serialize(policeCar);

                // Assert
                // Verify that the JSON serialization contains expected properties and values
                Assert.IsNotNull(json); // Check if the JSON string is not null
                Assert.IsTrue(json.Contains("\"Id\":1")); // Check if JSON contains Id property with value 1
                Assert.IsTrue(json.Contains("\"merke\":\"Ford\"")); // Check if JSON contains Brand property with value "Ford"
                Assert.IsTrue(json.Contains("\"modell\":\"Interceptor\"")); // Check if JSON contains Model property with value "Interceptor"
                Assert.IsTrue(json.Contains("\"årsmodell\":2022")); // Check if JSON contains ModelYear property with value 2022
                Assert.IsTrue(json.Contains("\"regNr\":\"ABC123\"")); // Check if JSON contains RegistrationNumber property with value "ABC123"
                Assert.IsTrue(json.Contains("\"status\":\"On Duty\"")); // Check if JSON contains Status property with value "On Duty"
                Assert.IsTrue(json.Contains("\"oppdrag\":\"Patrol\"")); // Check if JSON contains Mission property with value "Patrol"
            }
        }
    }

}

