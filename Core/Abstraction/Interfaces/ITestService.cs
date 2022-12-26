using Models.Implementation;

namespace Core.Abstraction.Interfaces;

public interface ITestService
{
    public Task<List<TestDto>> GetChunkAsync(int size, int number);
    public Task<TestDto> GetByIdAsync(Guid id);
    public Task CreateAsync(TestDto testDto);
    public Task ReplyAsync(AnswerTest answerTest, Guid userId);
    public Task UpdateAsync(TestDto testDto);
    public Task DeleteAsync(Guid id);
}