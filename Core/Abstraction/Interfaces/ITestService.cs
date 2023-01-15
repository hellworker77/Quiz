using Models.Implementation;

namespace Core.Abstraction.Interfaces;

public interface ITestService
{
    public Task<List<TestDto>> GetChunkAsync(int size, int number);
    public Task<int> GetCountAsync();
    public Task<TestDto> GetByIdAsync(Guid id);
    public Task CreateAsync(TestDto testDto);
    public Task UpdateAsync(TestDto testDto);
    public Task DeleteAsync(Guid id);
}