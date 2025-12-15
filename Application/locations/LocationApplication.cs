using Application.locations.Dto;
using Data.Locations;
using Domain;

namespace Application.locations
{
    public class LocationApplication : ILocationApplications
    {

        private readonly ILocationRepostary _locationRepository;
        public LocationApplication(ILocationRepostary locationRepositary)
        {
            _locationRepository = locationRepositary;
        }

        public async Task<string> categary(CreateLocationDto dto)
        {
            var locatin = new Location();
            locatin.Name = dto.Name;
            locatin.code = dto.Code;
            locatin.ParentId = dto.ParentId;
            locatin.LocationType = dto.locationType;

            await _locationRepository.location(locatin);
            return "Created Successfully";
        }

        public async Task delete(int id)
        {

            await _locationRepository.Delete(id);

        }
        public async Task<List<Location>> GetAll()
        {
            var locatin = await _locationRepository.GetAll();
            return locatin;
        }

        public async Task<Location> GetById(int id)
        {
            return await _locationRepository.GetId(id);
        }

        public async Task Update(int LocationId, CreateLocationDto update)
        {
            var locatin = await _locationRepository.GetId(LocationId);

            if (locatin == null)
                throw new Exception("locatin not found");

            await _locationRepository.Update(locatin);
        }
    }
}
