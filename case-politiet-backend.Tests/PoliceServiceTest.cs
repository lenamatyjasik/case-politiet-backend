using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using Services;

using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass]
    public class PoliceServiceTests
    {
        [TestMethod]
        public async Task GetPoliceCar_ReturnsValidPoliceCar()
        {
            // Arrange
            var service = new PoliceService();

            // Act
            var policeCarId = 1;
            var result = await service.GetPoliceCar(policeCarId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(policeCarId, result.Id);
        }
    }
}
