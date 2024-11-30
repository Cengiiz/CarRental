using CarRentalCore.DTOs;
using CarRentalCore.Mappers;
using CarRentalCore.Models;
using CarRentalCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper<Role,RoleDto> _mapper;

        public RoleController(IRoleService roleService, IMapper<Role, RoleDto> mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetById(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null) return NotFound();

            var roleDto = _mapper.MapToDto(role);
            return Ok(roleDto);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        //{
        //    var roles = await _roleService.GetAllAsync();
        //    var roleDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);
        //    return Ok(roleDtos);
        //}

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Create(RoleDto roleDto)
        {
            var role = _mapper.MapToEntity(roleDto);
            var createdRole = await _roleService.CreateAsync(role);
            var createdRoleDto = _mapper.MapToDto(createdRole);
            return CreatedAtAction(nameof(GetById), new { id = createdRoleDto.Id }, createdRoleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoleDto roleDto)
        {
            if (id != roleDto.Id) return BadRequest();

            var role = _mapper.MapToEntity(roleDto);
            var updatedRole = await _roleService.UpdateAsync(role);
            if (updatedRole == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _roleService.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
