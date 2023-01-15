using Models.Implementation;

namespace Core.Abstraction.Interfaces;

public interface ITestResultService
{
    public Task<TestResultDto> GetTestResultsAsync(Guid userId, Guid id);
    public Task<List<TestResultDto>> GetChunkAsync(Guid userId, int size, int number);
    public Task<int> GetCountAsync(Guid userId);
    public Task ReplyAsync(AnswerTest answerTest, Guid userId);
}