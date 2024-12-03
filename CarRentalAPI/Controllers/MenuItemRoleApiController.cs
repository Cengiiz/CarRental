using AutoMapper;
using CarRentalCore.Models;
using CarRentalService.DTOs;
using CarRentalService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemRoleApiController : ControllerBase
    {
        private readonly IMenuItemRoleService _menuItemRoleService;
        private readonly IMapper _mapper;

        public MenuItemRoleApiController(IMenuItemRoleService menuItemRoleService, IMapper mapper)
        {
            _menuItemRoleService = menuItemRoleService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemRoleDto>> GetById(int id)
        {
            var menuItem = await _menuItemRoleService.GetByIdAsync(id);
            if (menuItem == null) return NotFound();

            var menuItemRoleDto = _mapper.Map<MenuItemRoleDto>(menuItem);
            return Ok(menuItemRoleDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemRoleDto>>> GetAll()
        {
            var menuItems = await _menuItemRoleService.GetAllAsync();
            var menuItemRoleDtos = _mapper.Map<IEnumerable<MenuItemRoleDto>>(menuItems);
            return Ok(menuItemRoleDtos);
        }

        [HttpPost]
        public async Task<ActionResult<MenuItemRoleDto>> Create(MenuItemRoleDto menuItemRoleDto)
        {
            var menuItem = _mapper.Map<MenuItemRole>(menuItemRoleDto);
            var createdmenuItem = await _menuItemRoleService.CreateAsync(menuItem);
            var createdMenuItemRoleDto = _mapper.Map<MenuItemRoleDto>(createdmenuItem);
            return CreatedAtAction(nameof(GetById), new { id = createdMenuItemRoleDto.Id }, createdMenuItemRoleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MenuItemRoleDto menuItemRoleDto)
        {
            if (id != menuItemRoleDto.Id) return BadRequest();

            var menuItemRole = _mapper.Map<MenuItemRole>(menuItemRoleDto);
            var updatedmenuItem = await _menuItemRoleService.UpdateAsync(menuItemRole);
            if (updatedmenuItem == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _menuItemRoleService.DeleteAsync(id);
            if (!success) return NotFound();

            return Ok();
        }
    }
}
