using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Core.Interfaces
{
    public interface IService<TRequestDto, TResponseDto>
    {
        public Task AddAsync(TRequestDto item);
        public TResponseDto Get(string id);
        public List<TResponseDto> GetAll();
        public Task UpdateAsync(string id, TRequestDto item);
        public Task DeleteAsync(string id);
    }
}
