using AutoMapper;
using CarRentalCore.Models;
using CarRentalService.DTOs;
using CarRentalService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserApiController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var createdUser = await _userService.CreateAsync(user);
            var createdUserDto = _mapper.Map<UserDto>(createdUser);
            return CreatedAtAction(nameof(GetById), new { id = createdUserDto.Id }, createdUserDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDto userDto)
        {
            if (id != userDto.Id) return BadRequest();

            var user = _mapper.Map<User>(userDto);
            var updatedUser = await _userService.UpdateAsync(user);
            if (updatedUser == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _userService.DeleteAsync(id);
            if (!success) return NotFound();

            return Ok();
        }
    }
}
