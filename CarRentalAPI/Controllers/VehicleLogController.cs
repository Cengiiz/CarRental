using CarRentalCore.DTOs;
using CarRentalCore.Mappers;
using CarRentalCore.Models;
using CarRentalCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleLogController : ControllerBase
    {
        private readonly IVehicleLogService _vehicleLogService;
        private readonly IMapper<VehicleLog, VehicleLogDto> _mapper;

        public VehicleLogController(IVehicleLogService vehicleLogService, IMapper<VehicleLog, VehicleLogDto> mapper)
        {
            _vehicleLogService = vehicleLogService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleLogDto>> GetById(int id)
        {
            var vehicleLog = await _vehicleLogService.GetByIdAsync(id);
            if (vehicleLog == null) return NotFound();

            var vehicleLogDto = _mapper.MapToDto(vehicleLog);
            return Ok(vehicleLogDto);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VehicleLogDto>>> GetAll()
        //{
        //    var vehicleLogs = await _vehicleLogService.GetAllAsync();
        //    var vehicleLogDtos = _mapper.MapToDto(vehicleLogs);
        //    return Ok(vehicleLogDtos);
        //}

        [HttpPost]
        public async Task<ActionResult<VehicleLogDto>> Create(VehicleLogDto vehicleLogDto)
        {
            var vehicleLog = _mapper.MapToEntity(vehicleLogDto);
            var createdVehicleLog = await _vehicleLogService.CreateAsync(vehicleLog);
            var createdVehicleLogDto = _mapper.MapToDto(createdVehicleLog);
            return CreatedAtAction(nameof(GetById), new { id = createdVehicleLogDto.Id }, createdVehicleLogDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VehicleLogDto vehicleLogDto)
        {
            if (id != vehicleLogDto.Id) return BadRequest();

            var vehicleLog = _mapper.MapToEntity(vehicleLogDto);
            var updatedVehicleLog = await _vehicleLogService.UpdateAsync(vehicleLog);
            if (updatedVehicleLog == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _vehicleLogService.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
