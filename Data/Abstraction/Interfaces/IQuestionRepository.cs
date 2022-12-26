using Models.Implementation;

namespace DataAccessLayer.Abstraction.Interfaces;

public interface IQuestionRepository
{
    public Task CreateAsync(QuestionDto questionDto);
    public Task UpdateAsync(QuestionDto questionDto);
}