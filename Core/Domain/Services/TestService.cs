using Core.Abstraction.Interfaces;
using DataAccessLayer.Abstraction.Interfaces;
using FluentValidation;
using Models.Implementation;

namespace Core.Domain.Services;

public class TestService : ITestService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly ITestRepository _testRepository;
    private readonly IValidator<TestDto> _testValidator;

    public TestService(IQuestionRepository questionRepository,
        ITestRepository testRepository,
        IValidator<TestDto> testValidator)
    {
        _questionRepository = questionRepository;
        _testRepository = testRepository;
        _testValidator = testValidator;
    }
    public async Task<List<TestDto>> GetChunkAsync(int size, int number)
    {
        return await _testRepository.GetChunkAsync(size, number);
    }

    public async Task<int> GetCountAsync()
    {
        var count = await _testRepository.GetCountAsync();
        return count;
    }

    public async Task<TestDto> GetByIdAsync(Guid id)
    {
        return await _testRepository.GetByIdAsync(id);
    }
    public async Task CreateAsync(TestDto testDto)
    {
        var result = await _testValidator.ValidateAsync(testDto);
        if (result.IsValid)
        {
            testDto.Stamp = GenerateStamp();
            await _testRepository.CreateAsync(testDto);

#pragma warning disable CS8602 
            foreach (var question in testDto.QuestionsDto)
            {
                await _questionRepository.CreateAsync(question);
            }
#pragma warning restore CS8602

        }
    }
    public async Task UpdateAsync(TestDto testDto)
    {
        var testContext = new ValidationContext<TestDto>(testDto);
        var result = await _testValidator.ValidateAsync(testContext);
        if (result.IsValid)
        {
#pragma warning disable CS8602
            foreach (var question in testDto.QuestionsDto)
            {
                await _questionRepository.UpdateAsync(question);
            }

            await _testRepository.UpdateAsync(testDto);
#pragma warning restore CS8602
        }
    }
    public async Task DeleteAsync(Guid id)
    {
        await _testRepository.DeleteAsync(id);
    }

    private string GenerateStamp()
    {
        var guid = Guid.NewGuid();
        var stamp = Convert.ToBase64String(guid.ToByteArray());
        stamp = stamp.Replace("=", "");
        stamp = stamp.Replace("+", "");

        return stamp;
    }
}