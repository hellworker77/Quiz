using Models.Implementation;

namespace DataAccessLayer.Abstraction.Interfaces;

public interface ITestRepository
{
    public Task<List<TestDto>> GetChunkAsync(int size, int number);
    public Task<TestDto> GetByIdAsync(Guid id);
    public Task<int> GetCountAsync();
    public Task CreateAsync(TestDto testDto);
    public Task UpdateAsync(TestDto testDto);
    public Task DeleteAsync(Guid id);
}