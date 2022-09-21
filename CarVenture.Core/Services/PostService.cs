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
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _repository;
        private readonly ILogger _logger;

        public PostService(IMapper mapper, IPostRepository repository, ILogger<PostService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task AddAsync(PostRequestDto postRequestDto)
        {
            var post = _mapper.Map<Post>(postRequestDto);

            if (post == null)
            {
                _logger.LogInformation("Post request DTO did not map to Post: Invalid input provided");
                throw new Exception("One or more of your inputs are incorrect");
            }

            try
            {
                if (await _repository.AddAsync(post) > 0)
                {
                    _logger.LogInformation($"Successfully added post {post.Id} to database");
                }
                else
                {
                    _logger.LogInformation($"Could not add post {post.Id} to database: zero rows affected");
                    throw new Exception($"Could not add post {post.Id} to database: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not add car {post.Id} to database: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                if (await _repository.DeleteAsync(id) > 0)
                {
                    _logger.LogInformation($"Deleted post {id} from database");
                }
                else
                {
                    _logger.LogInformation($"Could not delete post {id} from database: zero rows affected");
                    throw new Exception($"Could not delete post {id} from database: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete post {id} from database: {ex.Message}");
                throw;
            }
        }

        public async Task<PostResponseDto> GetAsync(string id)
        {
            var post = await _repository.GetAsync(id);
            return _mapper.Map<PostResponseDto>(post);
        }

        public async Task<List<PostResponseDto>> GetAllAsync()
        {
            var posts = await _repository.GetAllAsync();
            return _mapper.Map<List<PostResponseDto>>(posts);
        }

        public async Task UpdateAsync(string id, PostRequestDto postRequestDto)
        {
            var post = await _repository.GetAsync(id);
            post.Title = postRequestDto.Title;
            post.Body = postRequestDto.Body;
            post.FeatureImagePath = postRequestDto.FeatureImagePath;
            post.Tag = postRequestDto.Tag;
            post.UpdatedAt = DateTime.Now;

            try
            {
                if (await _repository.UpdateAsync(post) > 0)
                {
                    _logger.LogInformation($"Updated post {id} information successfully");
                }
                else
                {
                    _logger.LogInformation($"Could not update post {id} information: zero rows affected");
                    throw new Exception($"Could not update post {id} information: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update post {id} information: {ex.Message}");
                throw;
            }
        }
    }
}
