using AutoMapper;
using CarRentalCore.DTOs;
using CarRentalCore.Models;
using CarRentalCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRoleService userRoleService, IMapper mapper)
        {
            _userRoleService = userRoleService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleDto>> GetById(int id)
        {
            var user = await _userRoleService.GetByIdAsync(id);
            if (user == null) return NotFound();

            var UserRoleDto = _mapper.Map<UserRoleDto>(user);
            return Ok(UserRoleDto);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll()
        //{
        //    var users = await _userRoleService.GetAllAsync();
        //    var UserRoleDtos = _mapper.MapToEntity(users);
        //    return Ok(UserRoleDtos);
        //}

        [HttpPost]
        public async Task<ActionResult<UserRoleDto>> Create(UserRoleDto UserRoleDto)
        {
            var user = _mapper.Map<UserRole>(UserRoleDto);
            var createdUser = await _userRoleService.CreateAsync(user);
            var createdUserRoleDto = _mapper.Map<UserRoleDto>(createdUser);
            return CreatedAtAction(nameof(GetById), new { id = createdUserRoleDto.Id }, createdUserRoleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserRoleDto UserRoleDto)
        {
            if (id != UserRoleDto.Id) return BadRequest();

            var user = _mapper.Map<UserRole>(UserRoleDto);
            var updatedUser = await _userRoleService.UpdateAsync(user);
            if (updatedUser == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _userRoleService.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
