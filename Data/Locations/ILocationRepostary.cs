using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Locations
{
    public interface ILocationRepostary
    {
        Task DeleteUser(int id);
        Task<Location> GetId(int id);
        Task Update(Location categary);
        Task<List<Location>> GetAll();
        Task<Location> categary(Location categary);
    }
}
