using Domain;

namespace Data.Locations;

public interface ILocationRepostary
{
    Task Delete(int id);
    Task<Location> GetId(int id);
    Task Update(Location categary);
    Task<List<Location>> GetAll();
    Task<Location> location(Location categary);
}
