using AutoMapper;
using CarRentalCore.Models;
using CarRentalService.DTOs;
using CarRentalService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleApiController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleApiController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> GetById(int id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null) return NotFound();

            var vehicleDto = _mapper.Map<VehicleDto>(vehicle);
            return Ok(vehicleDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetAll()
        {
            var vehicles = await _vehicleService.GetAllAsync();
            var vehicleDtos = _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
            return Ok(vehicleDtos);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleDto>> Create(VehicleDto vehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            var createdVehicle = await _vehicleService.CreateAsync(vehicle);
            var createdVehicleDto = _mapper.Map<VehicleDto>(createdVehicle);
            return CreatedAtAction(nameof(GetById), new { id = createdVehicleDto.Id }, createdVehicleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VehicleDto vehicleDto)
        {
            if (id != vehicleDto.Id) return BadRequest();

            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            var updatedVehicle = await _vehicleService.UpdateAsync(vehicle);
            if (updatedVehicle == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _vehicleService.DeleteAsync(id);
            if (!success) return NotFound();

            return Ok();
        }
    }
}
