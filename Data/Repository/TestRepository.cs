using System.Net;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using DataAccessLayer.Abstraction.Interfaces;
using DataAccessLayer.Data;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Models.Implementation;

namespace DataAccessLayer.Repository;

public class TestRepository : ITestRepository
{
    private readonly ApplicationContext _applicationContext;
    private readonly DbSet<Test> _dbSet;
    private readonly IMapper _mapper;

    public TestRepository(ApplicationContext applicationContext,
        IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
        _dbSet = applicationContext.Set<Test>();
    }
    public async Task<List<TestDto>> GetChunkAsync(int size, int number)
    {
        var tests = await _dbSet.AsNoTracking()
            .Include(x=>x.Questions!)
            .ThenInclude(x=>x.Photo)
            .Include(x=>x.Photo)
            .Skip(size * number).Take(size)
            .ToListAsync();

        var testsDto = _mapper.Map<List<TestDto>>(tests);

        return testsDto;
    }

    public async Task<TestDto> GetByIdAsync(Guid id)
    {
        var test = await _dbSet.AsNoTracking()
            .Include(x=>x.Questions!)
            .ThenInclude(x => x.Photo)
            .Include(x => x.Photo)
            .FirstOrDefaultAsync(x => x.Id == id);

        var testDto = _mapper.Map<TestDto>(test);

        return testDto;
    }

    public async Task<int> GetCountAsync()
    {
        var count = _dbSet.AsNoTracking().Count();
        return await Task.FromResult(count);
    }

    public async Task CreateAsync(TestDto testDto)
    {
        var test = _mapper.Map<Test>(testDto);

        test.Questions?.Clear();

        await _dbSet.AddAsync(test);

        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TestDto testDto)
    {
        var test = _mapper.Map<Test>(testDto);

        _applicationContext.Entry(test).State = EntityState.Modified;

        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var test = await _dbSet.FindAsync(id);

        if (test != null)
        {
            _dbSet.Remove(test);
            await _applicationContext.SaveChangesAsync();
        }
    }
}