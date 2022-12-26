using Models.Implementation;
using Models.Implementation.Answers;

namespace Core.Abstraction.Interfaces;

public interface ITestService
{
    public Task<List<TestDto>> GetChunkAsync(int size, int number);
    public Task<TestDto> GetByIdAsync(Guid id);
    public Task CreateAsync(TestDto testDto);
    public Task ReceiveAnswerAsync(TestAnswer testAnswer);
    public Task UpdateAsync(TestDto testDto);
    public Task DeleteAsync(Guid id);
}