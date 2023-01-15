using Microsoft.AspNetCore.Mvc;
using Models.Implementation;

namespace Core.Abstraction.Interfaces;

public interface IUserService
{
    public Task<UserDto> GetByIdAsync(Guid id);
    public Task<List<UserDto>> GetChunkAsync(int size, int number);
    public Task SignUpAsync(UserDto userDto);
    public Task ChangePasswordAsync(Guid userId, string password, string oldPassword);
    public Task<IActionResult> EditAsync(Guid userId, string userName, string email);
    public Task DeleteAsync(Guid id);
}