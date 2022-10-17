using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTestDemoWebAPI.Models.Services;

namespace UnitTestDemoWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HardwareComponentController : ControllerBase
    {
        private readonly IHardwareComponentServices _hardwareComponentServices;

        public HardwareComponentController(IHardwareComponentServices hardwareComponentServices)
        {
            _hardwareComponentServices = hardwareComponentServices;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_hardwareComponentServices.Get());
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var component = _hardwareComponentServices.Get(Id);
            if(component == null)
                return NotFound();
            return Ok(component);
        }

    }
}
