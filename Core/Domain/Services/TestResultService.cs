using Core.Abstraction.Interfaces;
using DataAccessLayer.Abstraction.Interfaces;
using Entities.Identity;
using FluentValidation;
using Models.Implementation;

namespace Core.Domain.Services;

public class TestResultService : ITestResultService
{
    private readonly IValidator<AnswerTest> _testAnswerValidator;
    private readonly ITestResultRepository _testResultRepository;
    private readonly IQuestionResultRepository _questionResultRepository;
    private readonly ITestRepository _testRepository;
    private readonly IUserRepository _userRepository;

    public TestResultService(ITestResultRepository testResultRepository, 
        IQuestionResultRepository questionResultRepository,
        ITestRepository testRepository,
        IValidator<AnswerTest> testAnswerValidator,
        IUserRepository userRepository)
    {
        _testResultRepository = testResultRepository;
        _questionResultRepository = questionResultRepository;
        _testRepository = testRepository;
        _testAnswerValidator = testAnswerValidator;
        _userRepository = userRepository;
    }

    public async Task<TestResultDto> GetTestResultsAsync(Guid userId, Guid id)
    {
        return await _testResultRepository.GetByIdAsync(userId, id);
    }
    public async Task<List<TestResultDto>> GetChunkAsync(Guid userId, int size, int number)
    {
        return await _testResultRepository.GetChunkAsync(userId, size, number);
    }
    public async Task<int> GetCountAsync(Guid userId)
    {
        return await _testResultRepository.GetCountAsync(userId);
    }
    public async Task ReplyAsync(AnswerTest answerTest, Guid userId)
    {
        int baseRatingIncrementValue = 50;
        var testDto = await _testRepository.GetByIdAsync(answerTest.Id);
        
        var validationResult = await _testAnswerValidator.ValidateAsync(answerTest);

        if (validationResult.IsValid)
        {
            var testResultDto = GenerateTestResultDto(answerTest, testDto, userId);

            var rating = (int)((testResultDto.Accuracy - 0.5) * baseRatingIncrementValue);
            await _userRepository.UpdateRatingAsync(userId, rating);

            await _testResultRepository.CreateAsync(testResultDto);

#pragma warning disable CS8602 
            foreach (var questionResultDto in testResultDto.QuestionResultsDto)
            {
                await _questionResultRepository.CreateAsync(questionResultDto);
            }
#pragma warning restore CS8602 
        }
        
    }
    private TestResultDto GenerateTestResultDto(AnswerTest answerTest, TestDto testDto, Guid userId)
    {
        var testResultDto = new TestResultDto
        {
            Description = testDto.Description,
            Id = Guid.NewGuid(),
            Name = testDto.Name,
            QuestionResultsDto = new List<QuestionResultDto>(),
            UserId = userId,
            Stamp = answerTest.Stamp,
            Photo = testDto.Photo
        };
        
        if (testDto.QuestionsDto != null && answerTest.AnswerQuestionsDto != null)
        {
            FillTestResultWithQuestionResults(testResultDto, answerTest, testDto);
            CalculateAccuracy(testResultDto);

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
                Answers = questionDto.Answers,
                TestResultId = testResultDto.Id,
                Title = questionDto.Title,
                Photo = questionDto.Photo

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

    private void CalculateAccuracy(TestResultDto testResultDto)
    {
        var correctCount = testResultDto.QuestionResultsDto?.Where(x => x.IsCorrect).Count() ?? 1;
        var totalCount = testResultDto.QuestionResultsDto?.Count ?? 1;
        testResultDto.Accuracy = (double)correctCount / totalCount;
    }
}