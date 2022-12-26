using AutoMapper;
using DataAccessLayer.Abstraction.Interfaces;
using DataAccessLayer.Data;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Models.Implementation;

namespace DataAccessLayer.Repository;

public class QuestionRepository : IQuestionRepository
{
    private readonly ApplicationContext _applicationContext;
    private readonly DbSet<Question> _dbSet;
    private readonly IMapper _mapper;

    public QuestionRepository(ApplicationContext applicationContext,
        IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
        _dbSet = applicationContext.Set<Question>();
    }
    public async Task CreateAsync(QuestionDto questionDto)
    {
        var question = _mapper.Map<Question>(questionDto);

        await _dbSet.AddAsync(question);

        await  _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(QuestionDto questionDto)
    {
        var question = _mapper.Map<Question>(questionDto);

        _applicationContext.Entry(question).State = EntityState.Modified;

        await _applicationContext.SaveChangesAsync();
    }
}