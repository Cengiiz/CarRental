﻿using CarRentalCore.DTOs;
using CarRentalCore.Mappers;
using CarRentalCore.Models;
using CarRentalCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper<Vehicle, VehicleDto> _mapper;

        public VehicleController(IVehicleService vehicleService, IMapper<Vehicle, VehicleDto> mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> GetById(int id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null) return NotFound();

            var vehicleDto = _mapper.MapToDto(vehicle);
            return Ok(vehicleDto);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VehicleDto>>> GetAll()
        //{
        //    var vehicles = await _vehicleService.GetAllAsync();
        //    var vehicleDtos = _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        //    return Ok(vehicleDtos);
        //}

        [HttpPost]
        public async Task<ActionResult<VehicleDto>> Create(VehicleDto vehicleDto)
        {
            var vehicle = _mapper.MapToEntity(vehicleDto);
            var createdVehicle = await _vehicleService.CreateAsync(vehicle);
            var createdVehicleDto = _mapper.MapToDto(createdVehicle);
            return CreatedAtAction(nameof(GetById), new { id = createdVehicleDto.Id }, createdVehicleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VehicleDto vehicleDto)
        {
            if (id != vehicleDto.Id) return BadRequest();

            var vehicle = _mapper.MapToEntity(vehicleDto);
            var updatedVehicle = await _vehicleService.UpdateAsync(vehicle);
            if (updatedVehicle == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _vehicleService.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}