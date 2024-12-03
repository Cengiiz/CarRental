using AutoMapper;
using CarRentalService.DTOs;
using CarRentalService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginApiController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("validate/{username}/{password}")]
        public async Task<ActionResult<UserDto>> ValidateUser(string username, string password)
        {
            var user = await _userService.ValidateUser(username, password);
            if (user == null) return NotFound();

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
    }
}
