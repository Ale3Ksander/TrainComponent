using Microsoft.AspNetCore.Mvc;
using TrainComponent.Services;

namespace TrainComponent.Controllers
{
    [Route("train-component")]
    [ApiController]
    public class TrainComponentController : ControllerBase
    {
        private readonly TrainComponentService _service;

        public TrainComponentController(TrainComponentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] string? search = null)
        {
            return Ok(await _service.GetAllAsync(page, search));
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainComponent([FromBody] Models.TrainComponent component)
        {
            if (await _service.AddAsync(component))
                return Ok("Component created successfully");

            return BadRequest("Failed to create component");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainComponent(int id, [FromBody] Models.TrainComponent component)
        {
            if (await _service.UpdateAsync(id, component))
                return Ok("Component updated successfully");

            return BadRequest("Failed to update component");
        }

        [HttpPatch("{id}/quantity")]
        public async Task<IActionResult> UpdateQuantity(int id, [FromBody] int newQuantity)
        {
            if (await _service.UpdateQuantityAsync(id, newQuantity))
                return Ok("Quantity updated successfully");

            return BadRequest("Failed to update quantity");
        }
    }
}
