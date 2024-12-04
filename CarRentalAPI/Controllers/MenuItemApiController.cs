using AutoMapper;
using CarRentalCore.Models;
using CarRentalService.DTOs;
using CarRentalService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemApiController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        private readonly IMapper _mapper;

        public MenuItemApiController(IMenuItemService menuItemService, IMapper mapper)
        {
            _menuItemService = menuItemService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDto>> GetById(int id)
        {
            var menuItem = await _menuItemService.GetByIdAsync(id);
            if (menuItem == null) return NotFound();

            var MenuItemDto = _mapper.Map<MenuItemDto>(menuItem);
            return Ok(MenuItemDto);
        }
        [HttpGet("user={id}")]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetUserMenuItemsAsync(int id)
        {
            var menuItems = await _menuItemService.GetUserMenuItemsAsync(id);
            var menuItemDtos = _mapper.Map<IEnumerable<MenuItemDto>>(menuItems);
            return Ok(menuItemDtos);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetAll()
        {
            var menuItems = await _menuItemService.GetAllAsync();
            var MenuItemDtos = _mapper.Map<IEnumerable<MenuItemDto>>(menuItems);
            return Ok(MenuItemDtos);
        }

        [HttpPost]
        public async Task<ActionResult<MenuItemDto>> Create(MenuItemDto MenuItemDto)
        {
            var menuItem = _mapper.Map<MenuItem>(MenuItemDto);
            var createdmenuItem = await _menuItemService.CreateAsync(menuItem);
            var createdMenuItemDto = _mapper.Map<MenuItemDto>(createdmenuItem);
            return CreatedAtAction(nameof(GetById), new { id = createdMenuItemDto.Id }, createdMenuItemDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MenuItemDto MenuItemDto)
        {
            if (id != MenuItemDto.Id) return BadRequest();

            var menuItem = _mapper.Map<MenuItem>(MenuItemDto);
            var updatedmenuItem = await _menuItemService.UpdateAsync(menuItem);
            if (updatedmenuItem == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _menuItemService.DeleteAsync(id);
            if (!success) return NotFound();

            return Ok();
        }
    }
}
