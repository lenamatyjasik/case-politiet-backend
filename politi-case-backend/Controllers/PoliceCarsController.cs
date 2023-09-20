using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace politi_case_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]     
    public class PoliceCarsController : ControllerBase
    {
        private readonly PoliceService politiService;

        public PoliceCarsController(PoliceService politiService)
        {
            this.politiService = politiService;
        }

        [HttpGet]
        public async Task<IEnumerable<PoliceCar>> Get([FromQuery] string? status)
        {

            return await politiService.GetPoliceCars(status: status);
        }
    }
}
