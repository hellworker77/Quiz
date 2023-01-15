using Models.Implementation;

namespace DataAccessLayer.Abstraction.Interfaces;

public interface ITestResultRepository
{
    public Task<List<TestResultDto>> GetChunkAsync(Guid userId, int size, int number);
    public Task<TestResultDto> GetByIdAsync(Guid userId, Guid id);
    public Task<int> GetCountAsync(Guid userId);
    public Task CreateAsync(TestResultDto testResultDto);
    public Task UpdateAsync(TestResultDto testResultDto);
    public Task DeleteAsync(Guid id);
}