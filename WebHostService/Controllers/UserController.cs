using Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Implementation;

namespace WebHostService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IIdentityService _identityService;

    public UserController(IUserService userService,
        IIdentityService identityService)
    {
        _userService = userService;
        _identityService = identityService;
    }

    [HttpGet("id")]
    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        return await _userService.GetByIdAsync(id);
    }
    [Authorize]
    [HttpGet]
    public async Task<UserDto> GetAsync()
    {
        var userId = _identityService.GetUserIdentity();

        return await _userService.GetByIdAsync(Guid.Parse(userId));
    }
    [HttpGet("leaders")]
    public async Task<List<UserDto>> GetChunkAsync(int size, int number)
    {
        return await _userService.GetChunkAsync(size, number);
    }
    [HttpPost("register")]
    public async Task SignUpAsync(UserDto userDto)
    {
        await _userService.SignUpAsync(userDto);
    }
    [Authorize]
    [HttpPut("changePassword")]
    public async Task ChangePasswordAsync(UserDto userDto)
    {
        var userId = _identityService.GetUserIdentity();
        if (userId == userDto.Id.ToString())
        {

            await _userService.ChangePasswordAsync(userDto);
        }
    }
    [Authorize]
    [HttpPut("edit")]
    public async Task EditAsync(UserDto userDto)
    {
        var userId = _identityService.GetUserIdentity();
        if (userId == userDto.Id.ToString())
        {
            await _userService.EditAsync(userDto);
        }
    }
    [Authorize(Roles = "admin")]
    [HttpPut("editUser")]
    public async Task EditUserAsync(UserDto userDto)
    {
        await _userService.EditAsync(userDto);
    }
    [Authorize]
    [HttpDelete("delete")]
    public async Task DeleteAsync()
    {
        var userId = _identityService.GetUserIdentity();
        if (userId != string.Empty)
        {
            await _userService.DeleteAsync(Guid.Parse(userId));
        }
    }
    [Authorize(Roles = "admin")]
    [HttpDelete("deleteUser")]
    public async Task DeleteAsync(Guid id)
    {
        var userId = _identityService.GetUserIdentity();
        if (userId == id.ToString())
        {
            await _userService.DeleteAsync(id);
        }
    }
}