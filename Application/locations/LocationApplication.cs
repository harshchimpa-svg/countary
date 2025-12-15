using Application.locations.Dto;
using Data.Locations;
using Domain;

namespace Application.locations
{
    public class LocationApplication : ILocationApplications
    {

        private readonly ILocationRepository _locationRepository;
        public LocationApplication(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<string> Create(CreateLocationDto dto)
        {
            var location = new Location();
            location.Name = dto.Name;
            location.code = dto.Code;
            location.ParentId = dto.ParentId;
            location.LocationType = dto.locationType;

            await _locationRepository.location(location);
            return "Created Successfully";
        }

        public async Task Delete(int id)
        {
            await _locationRepository.Delete(id);
        }
        public async Task<List<Location>> GetAll()
        {
            var locations = await _locationRepository.GetAll();
            return locations;
        }
         
        public async Task<Location> GetById(int id)
        {
            return await _locationRepository.GetId(id);
        }

        public async Task Update(int LocationId, CreateLocationDto update)
        {
            var location = await _locationRepository.GetId(LocationId);

            if (location == null)
                throw new Exception("location not found");

            await _locationRepository.Update(location);
        }
    }
}
