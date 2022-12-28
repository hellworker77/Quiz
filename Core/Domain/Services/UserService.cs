using Core.Abstraction.Interfaces;
using DataAccessLayer.Abstraction.Interfaces;
using FluentValidation;
using Models.Implementation;
using Validation.Validators;

namespace Core.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<UserDto> _userValidator;

    public UserService(IUserRepository userRepository,
        IValidator<UserDto> userValidator)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
    }

    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<List<UserDto>> GetChunkAsync(int size, int number)
    {
        return await _userRepository.GetChunkAsync(size, number);
    }

    public async Task SignUpAsync(UserDto userDto)
    {
        var result = await _userValidator.ValidateAsync(userDto);
        if (result.IsValid)
        {
            await _userRepository.CreateAsync(userDto);
        }
    }

    public async Task ChangePasswordAsync(UserDto userDto)
    {
        var result = await _userValidator.ValidateAsync(userDto);
        if (result.IsValid)
        {
            await _userRepository.UpdatePasswordAsync(userDto.Id, userDto.Password ?? string.Empty);
        }
    }

    public async Task EditAsync(UserDto userDto)
    {
        var result = await _userValidator.ValidateAsync(userDto);
        if (result.IsValid)
        {
            await _userRepository.UpdateAsync(userDto);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }
}