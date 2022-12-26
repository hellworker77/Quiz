using Models.Implementation;

namespace DataAccessLayer.Abstraction.Interfaces;

public interface ITestResultRepository
{
    public Task<List<TestResultDto>> GetChunkAsync(int size, int number);
    public Task<TestResultDto> GetByIdAsync(Guid id);
    public Task CreateAsync(TestResultDto testResultDto);
    public Task UpdateAsync(TestResultDto testResultDto);
    public Task DeleteAsync(Guid id);
}