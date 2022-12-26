using Core.Abstraction.Interfaces;
using DataAccessLayer.Abstraction.Interfaces;
using Models.Implementation;
using Models.Implementation.Answers;

namespace Core.Domain.Services;

public class TestService : ITestService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly ITestRepository _testRepository;

    public TestService(IQuestionRepository questionRepository,
        ITestRepository testRepository)
    {
        _questionRepository = questionRepository;
        _testRepository = testRepository;
    }
    public async Task<List<TestDto>> GetChunkAsync(int size, int number)
    {
        return await _testRepository.GetChunkAsync(size, number);
    }
    public async Task<TestDto> GetByIdAsync(Guid id)
    {
        return await _testRepository.GetByIdAsync(id);
    }
    public async Task CreateAsync(TestDto testDto)
    {
        if (testDto.Questions != null)
        {
            await _testRepository.CreateAsync(testDto);

            foreach (var question in testDto.Questions)
            {
                await _questionRepository.CreateAsync(question);
            }

        }
    }

    public async Task ReceiveAnswerAsync(TestAnswer testAnswer)
    {
        var testDto = await _testRepository.GetByIdAsync(testAnswer.TestId);

        

    }

    public async Task UpdateAsync(TestDto testDto)
    {
        if (testDto.Questions != null)
        {
            foreach (var question in testDto.Questions)
            {
                await _questionRepository.UpdateAsync(question);
            }

            await _testRepository.UpdateAsync(testDto);
        }
    }
    public async Task DeleteAsync(Guid id)
    {
        await _testRepository.DeleteAsync(id);
    }


}