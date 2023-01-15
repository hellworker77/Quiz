using AutoMapper;
using DataAccessLayer.Abstraction.Interfaces;
using DataAccessLayer.Data;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Models.Implementation;

namespace DataAccessLayer.Repository;

public class QuestionResultRepository : IQuestionResultRepository
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;
    private readonly DbSet<QuestionResult> _dbSet;

    public QuestionResultRepository(ApplicationContext applicationContext,
        IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
        _dbSet = applicationContext.Set<QuestionResult>();
    }

    public async Task CreateAsync(QuestionResultDto questionResultDto)
    {
        var questionResult = _mapper.Map<QuestionResult>(questionResultDto);

        questionResult.Photo = null;

        await _dbSet.AddAsync(questionResult);

        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(QuestionResultDto questionResultDto)
    {
        var questionResult = _mapper.Map<QuestionResult>(questionResultDto);

        _applicationContext.Entry(questionResult).State = EntityState.Modified;

        await _applicationContext.SaveChangesAsync();
    }
}