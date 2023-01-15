using Models.Implementation;

namespace DataAccessLayer.Abstraction.Interfaces;

public interface IUserRepository
{
    public Task<UserDto> GetByIdAsync(Guid id);
    public Task<List<UserDto>> GetChunkAsync(int size, int number);
    public Task CreateAsync(UserDto userDto);
    public Task UpdatePasswordAsync(Guid id, string password, string oldPassword);
    public Task UpdateRatingAsync(Guid userId, int value);
    public Task UpdateAsync(UserDto userDto);
    public Task DeleteAsync(Guid id);
    
}