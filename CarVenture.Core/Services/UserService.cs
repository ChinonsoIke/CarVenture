using AutoMapper;
using CarVenture.Core.Interfaces;
using CarVenture.Data.Interfaces;
using CarVenture.Dtos;
using CarVenture.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        private readonly ILogger _logger;

        public UserService(IMapper mapper, IUserRepository repository, ILogger<UserService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task AddAsync(UserRequestDto userRequestDto)
        {
            var user = _mapper.Map<User>(userRequestDto);

            if(user == null)
            {
                _logger.LogInformation("User DTO did not map to User: Invalid credentials provided for user registeration");
                throw new Exception("One or more of your inputs are incorrect");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            try
            {
                if (await _repository.AddAsync(user) > 0)
                {
                    _logger.LogInformation($"User registration for {user.Email} was successful");
                }
                else
                {
                    _logger.LogInformation($"Could not add user {user.Id} to database: zero rows affected");
                    throw new Exception($"Could not add user {user.Id} to database: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not add user: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                if (await _repository.DeleteAsync(id) > 0)
                {
                    _logger.LogInformation($"Deleted user {id} from database");
                }
                else
                {
                    _logger.LogInformation($"Could not delete user {id} from database: zero rows affected");
                    throw new Exception($"Could not delete user {id} from database: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete user: {ex.Message}");
                throw;
            }
        }

        public async Task<UserResponseDto> GetAsync(string id)
        {
            var user = await _repository.GetAsync(id);
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public async Task UpdateAsync(string id, UserRequestDto userRequestDto)
        {
            var user =await  _repository.GetAsync(id);
            user.FirstName = userRequestDto.FirstName;
            user.LastName = userRequestDto.LastName;
            user.Email = userRequestDto.Email;
            user.Password = BCrypt.Net.BCrypt.HashPassword(userRequestDto.Password);
            user.PhoneNumber = userRequestDto.PhoneNumber;

            try
            {
                if (await _repository.UpdateAsync(user) > 0)
                {
                    _logger.LogInformation($"Updated user {id} information successfully");
                }
                else
                {
                    _logger.LogInformation($"Could not update user {id} information: zero rows affected");
                    throw new Exception($"Could not update user {id} information: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update user information: {ex.Message}");
                throw;
            }
        }
    }
}
