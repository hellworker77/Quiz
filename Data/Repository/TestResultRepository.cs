﻿using AutoMapper;
using DataAccessLayer.Abstraction.Interfaces;
using DataAccessLayer.Data;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Models.Implementation;

namespace DataAccessLayer.Repository;

public class TestResultRepository : ITestResultRepository
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;
    private readonly DbSet<TestResult> _dbSet;

    public TestResultRepository(ApplicationContext applicationContext,
        IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
        _dbSet = applicationContext.Set<TestResult>();
    }

    public async Task<List<TestResultDto>> GetChunkAsync(int size, int number)
    {
        var testResults = await _dbSet.AsNoTracking()
            .Include(x => x.QuestionResults)
            .Include(x => x.User)
            .Skip(size * number)
            .Take(size)
            .ToListAsync();

        var testResultsDto = _mapper.Map<List<TestResultDto>>(testResults);

        return testResultsDto;
    }

    public async Task<TestResultDto> GetByIdAsync(Guid id)
    {
        var testResult = await _dbSet.AsNoTracking()
            .Include(x => x.QuestionResults)
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);

        var testResultDto = _mapper.Map<TestResultDto>(testResult);

        return testResultDto;
    }

    public async Task CreateAsync(TestResultDto testResultDto)
    {
        var testResult = _mapper.Map<TestResult>(testResultDto);

        testResult.QuestionResults?.Clear();
        testResult.Date = DateTimeOffset.Now;

        await _dbSet.AddAsync(testResult);

        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TestResultDto testResultDto)
    {
        var testResult = _mapper.Map<Test>(testResultDto);

        _applicationContext.Entry(testResult).State = EntityState.Modified;

        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var testResult = await _dbSet.FindAsync(id);

        if (testResult != null)
        {
            _dbSet.Remove(testResult);
            await _applicationContext.SaveChangesAsync();
        }
    }
}