using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Locations
{
    public class LocationRepastary : ILocationRepostary
    {
        private readonly ProjectContext _context;

        public LocationRepastary(ProjectContext context)
        {
            _context = context;
        }
        public async Task DeleteUser(int id)
        {
            var user = await _context.locations.FindAsync(id);
            _context.locations.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Location>> GetAll()
        {

            var get = await _context.locations.ToListAsync();
            return get;
        }
        public async Task<Location> GetId(int id)
        {
            return await _context.locations.FindAsync(id);
        }
        public async Task<Location> categary(Location categary)
        {

            await _context.locations.AddAsync(categary);
            await _context.SaveChangesAsync();

            return categary;
        }

        public async Task Update(Location categary)
        {
            _context.locations.Update(categary);
            await _context.SaveChangesAsync(); ;
        }
    }
}
