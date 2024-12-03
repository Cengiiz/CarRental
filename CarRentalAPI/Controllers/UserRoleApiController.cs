using AutoMapper;
using CarRentalCore.Models;
using CarRentalService.DTOs;
using CarRentalService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleApiController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleApiController(IUserRoleService userRoleService, IMapper mapper)
        {
            _userRoleService = userRoleService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleDto>> GetById(int id)
        {
            var userRole = await _userRoleService.GetByIdAsync(id);
            if (userRole == null) return NotFound();

            var UserRoleDto = _mapper.Map<UserRoleDto>(userRole);
            return Ok(UserRoleDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll()
        {
            var userRoles = await _userRoleService.GetAllAsync();
            var UserRoleDtos = _mapper.Map<IEnumerable<UserRoleDto>>(userRoles);
            return Ok(UserRoleDtos);
        }

        [HttpPost]
        public async Task<ActionResult<UserRoleDto>> Create(UserRoleDto UserRoleDto)
        {
            var userRole = _mapper.Map<UserRole>(UserRoleDto);
            var createdUserRole = await _userRoleService.CreateAsync(userRole);
            var createdUserRoleDto = _mapper.Map<UserRoleDto>(createdUserRole);
            return CreatedAtAction(nameof(GetById), new { id = createdUserRoleDto.Id }, createdUserRoleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserRoleDto UserRoleDto)
        {
            if (id != UserRoleDto.Id) return BadRequest();

            var userRole = _mapper.Map<UserRole>(UserRoleDto);
            var updatedUser = await _userRoleService.UpdateAsync(userRole);
            if (updatedUser == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _userRoleService.DeleteAsync(id);
            if (!success) return NotFound();

            return Ok();
        }
    }
}
