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

        [HttpGet("{Id}")]
        public async Task<PoliceCar?> GetPoliceCar(int Id)
        {

            return await politiService.GetPoliceCar(Id);
        }

        [HttpPut("{Id}/Status")]
        public PoliceCar PutPoliceCar(int Id, [FromBody] string status)
        {
            return politiService.UpdatePoliceCarStatus(Id, status);
        }

        [HttpPut("{Id}/Mission")]
        public PoliceCar PutPoliceCarMission(int Id, [FromBody] string mission)
        {
            return politiService.UpdatePoliceCarMission(Id, mission);
        }

        [HttpPost] public async Task<ActionResult<PoliceCar>> PostPoliceCar([FromBody] PoliceCar policeCar)
        {
            try
            {
                var createdPoliceCar = await politiService.AddPoliceCar(policeCar);
                return CreatedAtAction(nameof(GetPoliceCar), new { Id = createdPoliceCar.Id }, createdPoliceCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")] public async Task<ActionResult> DeletePoliceCar(int Id)
        {
            try
            {
                await politiService.DeletePoliceCar(Id);
                return Ok("Police car deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
