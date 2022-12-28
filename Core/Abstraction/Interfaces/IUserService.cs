using Models.Implementation;

namespace Core.Abstraction.Interfaces;

public interface IUserService
{
    public Task<UserDto> GetByIdAsync(Guid id);
    public Task<List<UserDto>> GetChunkAsync(int size, int number);
    public Task SignUpAsync(UserDto userDto);
    public Task ChangePasswordAsync(UserDto userDto);
    public Task EditAsync(UserDto userDto);
    public Task DeleteAsync(Guid id);
}