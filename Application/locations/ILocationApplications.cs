using Application.locations.Dto;
using Data.Migrations;
using Domain;

namespace Application.locations
{
    public interface ILocationApplications
    {
        Task<string> categary(CreateLocationDto dto);
        Task delete(int id);
        Task<List<Location>> GetAll();
        Task<Location> GetById(int id);
        Task Update(int LocationId, CreateLocationDto update);
    }
}
