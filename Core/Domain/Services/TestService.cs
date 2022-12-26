using Core.Abstraction.Interfaces;
using DataAccessLayer.Abstraction.Interfaces;
using Models.Implementation;

namespace Core.Domain.Services;

public class TestService : ITestService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly ITestRepository _testRepository;
    private readonly IQuestionResultRepository _questionResultRepository;
    private readonly ITestResultRepository _testResultRepository;

    public TestService(IQuestionRepository questionRepository,
        ITestRepository testRepository,
        IQuestionResultRepository questionResultRepository,
        ITestResultRepository testResultRepository)
    {
        _questionRepository = questionRepository;
        _testRepository = testRepository;
        _questionResultRepository = questionResultRepository;
        _testResultRepository = testResultRepository;
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
        if (testDto.QuestionsDto != null)
        {
            await _testRepository.CreateAsync(testDto);

            foreach (var question in testDto.QuestionsDto)
            {
                await _questionRepository.CreateAsync(question);
            }

        }
    }
    public async Task ReplyAsync(AnswerTest answerTest, Guid userId)
    {
        var testDto = await _testRepository.GetByIdAsync(answerTest.Id);

        var testResultDto = GenerateTestResultDto(answerTest, testDto);
        
        if (testResultDto != null && testResultDto?.QuestionResultsDto != null)
        {
            testResultDto.UserId = userId;

            await _testResultRepository.CreateAsync(testResultDto); 

            foreach (var questionResultDto in testResultDto.QuestionResultsDto)
            {
                await _questionResultRepository.CreateAsync(questionResultDto);
            }
        }
    }
    public async Task UpdateAsync(TestDto testDto)
    {
        if (testDto.QuestionsDto != null)
        {
            foreach (var question in testDto.QuestionsDto)
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
    private TestResultDto? GenerateTestResultDto(AnswerTest answerTest, TestDto testDto)
    {
        var testResultDto = new TestResultDto
        {
            Description = testDto.Description,
            Id = Guid.NewGuid(),
            Name = testDto.Name,
            QuestionResultsDto = new List<QuestionResultDto>()
        };
        if (testDto.QuestionsDto != null && answerTest.AnswerQuestionsDto != null)
        {
            FillTestResultWithQuestionResults(testResultDto, answerTest, testDto);

            return testResultDto;
        }

        return null;
    }
    private void FillTestResultWithQuestionResults(TestResultDto testResultDto, AnswerTest answerTest, TestDto testDto)
    {
#pragma warning disable CS8602
        foreach (var questionDto in testDto.QuestionsDto)
        {
#pragma warning disable CS8604
            var answerQuestion = answerTest.AnswerQuestionsDto.FirstOrDefault(x => x.Id == questionDto.Id);
#pragma warning restore CS8604

            var questionResultDto = new QuestionResultDto
            {
                Id = Guid.NewGuid(),
                ActualAnswer = null,
                CorrectAnswer = questionDto.CorrectAnswer,
                AnswersAsJson = questionDto.AnswersAsJson,
                TestResultId = testResultDto.Id,
                Title = questionDto.Title,
            };

            if (answerQuestion != null)
            {
                var isCorrect = questionDto.CorrectAnswer.Equals(answerQuestion.ActualAnswer);

                questionResultDto.IsCorrect = isCorrect;
                questionResultDto.ActualAnswer = answerQuestion.ActualAnswer;
            }

            testResultDto.QuestionResultsDto.Add(questionResultDto);

#pragma warning restore CS8602
        }

    }

}