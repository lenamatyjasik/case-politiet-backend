using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using politi_case_backend.Controllers;
using Services;

namespace case_politiet_backend.Tests
{
    internal class PoliceCarControllerTest
    {
        

namespace politi_case_backend.Tests
    {
        [TestClass]
        public class PoliceCarsControllerTests
        {
            [TestMethod]
            public async Task Get_PoliceCarsWithStatus_ReturnsOkResult()
            {
                // Arrange
                var status = "On Duty";
                var expectedCars = new List<PoliceCar>
            {
                new PoliceCar { Id = 1, Status = "On Duty" },
                new PoliceCar { Id = 2, Status = "On Duty" },
            };

                var policeService = new PoliceService();
                var controller = new PoliceCarsController(policeService);

                // Act
                var actionResult = await controller.Get(status);
                var okResult = actionResult as OkObjectResult;
                var returnedCars = okResult?.Value as IEnumerable<PoliceCar>;

                // Assert
                Assert.IsNotNull(okResult);
                Assert.AreEqual(200, okResult.StatusCode);
                Assert.IsNotNull(returnedCars);
                CollectionAssert.AreEqual(expectedCars, returnedCars, new PoliceCarComparer());
            }

            // Define a custom comparer for PoliceCar objects to compare without reference equality
            private class PoliceCarComparer : IEqualityComparer<PoliceCar>
            {
                public bool Equals(PoliceCar x, PoliceCar y)
                {
                    if (x == null && y == null)
                        return true;
                    if (x == null || y == null)
                        return false;
                    return x.Id == y.Id && x.Status == y.Status;
                }

                public int GetHashCode(PoliceCar obj)
                {
                    return obj.Id.GetHashCode() ^ obj.Status.GetHashCode();
                }
            }
        }
    }

}

