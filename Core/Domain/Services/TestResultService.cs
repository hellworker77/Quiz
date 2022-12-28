using Core.Abstraction.Interfaces;
using DataAccessLayer.Abstraction.Interfaces;
using FluentValidation;
using Models.Implementation;
using Validation.Validators;

namespace Core.Domain.Services;

public class TestResultService : ITestResultService
{
    private readonly IValidator<AnswerTest> _testAnswerValidator;
    private readonly ITestResultRepository _testResultRepository;
    private readonly IQuestionResultRepository _questionResultRepository;
    private readonly ITestRepository _testRepository;

    public TestResultService(ITestResultRepository testResultRepository, 
        IQuestionResultRepository questionResultRepository,
        ITestRepository testRepository,
        IValidator<AnswerTest> testAnswerValidator)
    {
        _testResultRepository = testResultRepository;
        _questionResultRepository = questionResultRepository;
        _testRepository = testRepository;
        _testAnswerValidator = testAnswerValidator;
    }


    public async Task<TestResultDto> GetTestResultsAsync(Guid userId, Guid id)
    {
        return await _testResultRepository.GetByIdAsync(userId, id);
    }
    public async Task<List<TestResultDto>> GetChunkAsync(Guid userId, int size, int number)
    {
        return await _testResultRepository.GetChunkAsync(userId, size, number);
    }
    public async Task ReplyAsync(AnswerTest answerTest, Guid userId)
    {
        var testDto = await _testRepository.GetByIdAsync(answerTest.Id);
        
        var validationResult = await _testAnswerValidator.ValidateAsync(answerTest);

        if (validationResult.IsValid)
        {
            var testResultDto = GenerateTestResultDto(answerTest, testDto);

            testResultDto.UserId = userId;

            await _testResultRepository.CreateAsync(testResultDto);

#pragma warning disable CS8602 
            foreach (var questionResultDto in testResultDto.QuestionResultsDto)
            {
                await _questionResultRepository.CreateAsync(questionResultDto);
            }
#pragma warning restore CS8602 
        }
        
    }
    private TestResultDto GenerateTestResultDto(AnswerTest answerTest, TestDto testDto)

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
        }

        return testResultDto;
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