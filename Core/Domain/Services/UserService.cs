using Core.Abstraction.Interfaces;
using DataAccessLayer.Abstraction.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Models.Implementation;

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

    public async Task ChangePasswordAsync(Guid userId, string password, string oldPassword)
    {
        
        await _userRepository.UpdatePasswordAsync(userId, password, oldPassword);
    }

    public async Task<IActionResult> EditAsync(Guid userId, string userName, string email)
    {
        var userDto = await _userRepository.GetByIdAsync(userId);

        IActionResult result = new NotFoundResult();

        if (userDto != null)
        {
            userDto.Email = email;
            userDto.UserName = userName;

            var validateResult = await _userValidator.ValidateAsync(userDto);

            result = new BadRequestResult();

            if (validateResult.IsValid)
            {
                await _userRepository.UpdateAsync(userDto);
                result = new OkResult();
            }
        }

        return result;
    }


    public async Task DeleteAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }
}