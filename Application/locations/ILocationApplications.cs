using Application.locations.Dto;
using Domain;

namespace Application.locations
{
    public interface ILocationApplications
    {
        Task<string> Create(CreateLocationDto dto);
        Task Delete(int id);
        Task<List<Location>> GetAll();
        Task<Location> GetById(int id);
        Task Update(int LocationId, CreateLocationDto update);
    }
}
