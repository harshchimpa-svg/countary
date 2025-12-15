using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Locations
{
    public class LocationRepastary : ILocationRepostary
    {
        private readonly ProjectContext _context;

        public LocationRepastary(ProjectContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            var locatin = await _context.locations.FindAsync(id);
            _context.locations.Remove(locatin);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Location>> GetAll()
        {

            var locatin = await _context.locations.ToListAsync();
            return locatin;
        }
        public async Task<Location> GetId(int id)
        {
            return await _context.locations.FindAsync(id);
        }
        public async Task<Location> location(Location locatin)
        {

            await _context.locations.AddAsync(locatin);
            await _context.SaveChangesAsync();

            return locatin;
        }

        public async Task Update(Location locatin)
        {
            _context.locations.Update(locatin);
            await _context.SaveChangesAsync(); ;
        }
    }
}
