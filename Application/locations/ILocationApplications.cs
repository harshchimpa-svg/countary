using Application.locations.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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
