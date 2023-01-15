using AutoMapper;
using DataAccessLayer.Abstraction.Interfaces;
using DataAccessLayer.Data;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Implementation;

namespace DataAccessLayer.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly DbSet<User> _dbSet;

    public UserRepository(ApplicationContext applicationContext,
        UserManager<User> userManager,
        IMapper mapper,
        IPasswordHasher<User> passwordHasher)
    {
        _userManager = userManager;
        _mapper = mapper;
        _dbSet = applicationContext.Set<User>();
        _passwordHasher = passwordHasher;
    }
    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var user = await _dbSet.AsNoTracking()
            .Include(x => x.TestResults)
            .Include(x => x.Photo)
            .FirstOrDefaultAsync(x => x.Id == id);

        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }

    public async Task<List<UserDto>> GetChunkAsync(int size, int number)
    {
        var users = await _dbSet.AsNoTracking()
            .Include(x => x.TestResults)
            .Include(x=>x.Photo)
            .OrderByDescending(x=>x.Rating)
            .Skip(size * number)
            .Take(size)
            .ToListAsync();

        var usersDto = _mapper.Map<List<UserDto>>(users);

        return usersDto;
    }

    public async Task CreateAsync(UserDto userDto)
    {
        var userAlreadyExisted = await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(x => x.NormalizedEmail == userDto.Email ||
                                      x.NormalizedUserName == userDto.UserName);

        if (userAlreadyExisted == null)
        {
            var user = _mapper.Map<User>(userDto);

            user.SecurityStamp = Guid.NewGuid().ToString("D");

            var result = await _userManager.CreateAsync(user, userDto.Password);
        }
    }

    public async Task UpdatePasswordAsync(Guid id, string password, string oldPassword)
    {
        var userAlreadyExisted = await _dbSet.FindAsync(id);

        if (userAlreadyExisted != null)
        {
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(userAlreadyExisted,userAlreadyExisted.PasswordHash, oldPassword);
            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                userAlreadyExisted.PasswordHash = _passwordHasher.HashPassword(userAlreadyExisted, password);
                var result = await _userManager.UpdateAsync(userAlreadyExisted);
            }
        }
    }

    public async Task UpdateRatingAsync(Guid userId, int value)
    {
        var user = await _dbSet.FindAsync(userId);
        if (user != null)
        {
            user.Rating += value;
            if (user.Rating < 0)
            {
                user.Rating = 0;
            }
            var result = await _userManager.UpdateAsync(user);
        }
    }

    public async Task UpdateAsync(UserDto userDto)
    {
        var userAlreadyExisted = await _dbSet.FindAsync(userDto.Id);

        if (userAlreadyExisted != null)
        {
            userAlreadyExisted.Email = userDto.Email;
            userAlreadyExisted.UserName = userDto.UserName;

            var result = await _userManager.UpdateAsync(userAlreadyExisted);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _dbSet.FindAsync(id);
        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
        }
    }
}