﻿using AutoMapper;
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
                await _repository.AddAsync(user);
                _logger.LogInformation($"User registration for {user.Email} was successful");
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
                await _repository.DeleteAsync(id);
                _logger.LogInformation($"Deleted user account for user {id}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete user: {ex.Message}");
                throw;
            }
        }

        public UserResponseDto Get(string id)
        {
            var user = _repository.Get(id);
            return _mapper.Map<UserResponseDto>(user);
        }

        public List<UserResponseDto> GetAll()
        {
            var users = _repository.GetAll();
            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public async Task UpdateAsync(string id, UserRequestDto userRequestDto)
        {
            var user = _repository.Get(id);
            user.FirstName = userRequestDto.FirstName;
            user.LastName = userRequestDto.LastName;
            user.Email = userRequestDto.Email;
            user.Password = userRequestDto.Password;
            user.PhoneNumber = userRequestDto.PhoneNumber;

            try
            {
                await _repository.UpdateAsync(user);
                _logger.LogInformation($"Updated account information for user {id}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update user information: {ex.Message}");
                throw;
            }
        }
    }
}
