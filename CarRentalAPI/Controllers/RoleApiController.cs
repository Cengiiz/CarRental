using AutoMapper;
using CarRentalCore.Models;
using CarRentalService.DTOs;
using CarRentalService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleApiController : ControllerBase
    {
        private readonly IRoleService _roleService;
        //private readonly IMapper<Role, RoleDto> _mapper;
        private readonly IMapper _mapper;

        public RoleApiController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetById(int id)
        {
            //var role = await _roleService.GetByIdAsync(id);
            var role = await _roleService.GetByIdWithIncludesAsync(id);
            if (role == null) return NotFound();

            var roleDto = _mapper.Map<RoleDto>(role);
            return Ok(roleDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
            var roleDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return Ok(roleDtos);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Create(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            var createdRole = await _roleService.CreateAsync(role);
            var createdRoleDto = _mapper.Map<RoleDto>(createdRole);
            return CreatedAtAction(nameof(GetById), new { id = createdRoleDto.Id }, createdRoleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoleDto roleDto)
        {
            if (id != roleDto.Id) return BadRequest();

            var role = _mapper.Map<Role>(roleDto);
            var updatedRole = await _roleService.UpdateAsync(role);
            if (updatedRole == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _roleService.DeleteAsync(id);
            if (!success) return NotFound();

            return Ok();
        }
    }
}
