using Microsoft.AspNetCore.Mvc;
using UnitTestDemoWebAPI.Controllers;
using UnitTestDemoWebAPI.Models;
using UnitTestDemoWebAPI.Models.Services;

namespace WebAPIUnitTesting
{
    public class HardwareComponentUnitTesting
    {
        // Add the resources I'll need for executing the tests
        private readonly HardwareComponentController _controller;
        private readonly IHardwareComponentServices _service;

        // Constructor
        public HardwareComponentUnitTesting()
        {
            _service = new HardwareComponentServices();
            _controller = new HardwareComponentController(_service);
        }

        // Evaluation #1 for Get()
        [Fact]
        public void Get_Ok()
        {
            // 1. Prepare: Set the scenario
            // Example: When data is sent in post.
            // Nothing is prepared in this case.

            // 2. Execute: Action to evaluate
            var result = _controller.Get();

            // 3. Assert: Evaluation
            Assert.IsType<OkObjectResult>(result);
        }

        // Evaluation #2 for Get()
        [Fact]
        public void Get_Quantity()
        {
            var result = _controller.Get() as OkObjectResult;
            var hardwareComponent = Assert.IsType<List<HardwareComponent>>(result?.Value);
            Assert.True(hardwareComponent.Count > 0);
        }

        // Evaluation #1 for GetById()
        [Fact]
        public void GetById_Ok()
        {
            // 1. Prepare: Set the scenario
            // This one example requires some previous preparation.
            int id = 1;

            // 2. Execut: Action to evaluate
            var result = _controller.GetById(id);

            // 3. Assert: Evaluation
            Assert.IsType<OkObjectResult>(result);
        }

        // Evaluation #2 for GetById(), if Id even exists
        [Fact]
        public void GetById_Exists()
        {
            // 1. Prepare: Set the scenario
            // This one example requires some previous preparation.
            int id = 1;

            // 2. Execute: Action to evaluate
            var result = (OkObjectResult)_controller.GetById(id);

            // 3. Assert: Evaluation
            // Assert #1
            var hardwareComponent = Assert.IsType<HardwareComponent>(result?.Value);
            // Assert #2
            Assert.True(hardwareComponent != null);
            // Assert #3
            Assert.Equal(hardwareComponent?.Id, id);
        }

        [Fact]
        public void GetById_NotFound()
        {
            int id = 11;
            var result = _controller.GetById(id);
            var hardwareComponent = Assert.IsType<NotFoundResult>(result);
        }
    }
}
