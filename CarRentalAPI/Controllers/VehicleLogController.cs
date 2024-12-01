using AutoMapper;
using CarRentalCore.DTOs;
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
        private readonly IMapper _mapper;

        public VehicleLogController(IVehicleLogService vehicleLogService, IMapper mapper)
        {
            _vehicleLogService = vehicleLogService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleLogDto>> GetById(int id)
        {
            var vehicleLog = await _vehicleLogService.GetByIdAsync(id);
            if (vehicleLog == null) return NotFound();

            var vehicleLogDto = _mapper.Map<VehicleLogDto>(vehicleLog);
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
            var vehicleLog = _mapper.Map<VehicleLog>(vehicleLogDto);
            var createdVehicleLog = await _vehicleLogService.CreateAsync(vehicleLog);
            var createdVehicleLogDto = _mapper.Map<VehicleLogDto>(createdVehicleLog);
            return CreatedAtAction(nameof(GetById), new { id = createdVehicleLogDto.Id }, createdVehicleLogDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VehicleLogDto vehicleLogDto)
        {
            if (id != vehicleLogDto.Id) return BadRequest();

            var vehicleLog = _mapper.Map<VehicleLog>(vehicleLogDto);
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
