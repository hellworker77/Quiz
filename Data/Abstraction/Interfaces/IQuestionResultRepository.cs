using Entities.Entity;
using Models.Implementation;

namespace DataAccessLayer.Abstraction.Interfaces;

public interface IQuestionResultRepository
{
    public Task CreateAsync(QuestionResultDto questionResultDto);
    public Task UpdateAsync(QuestionResultDto questionResultDto);
}