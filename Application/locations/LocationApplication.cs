using Application.locations.Dto;
using Data.Locations;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.locations
{
    public class LocationApplication : ILocationApplications
    {
            
    private readonly ILocationRepostary _customerRepository;
        public LocationApplication(ILocationRepostary categaryRepositary)
        {
            _customerRepository = categaryRepositary;
        }

        public async Task<string> categary(CreateLocationDto dto)
        {
            var categary = new Location();
            categary.Name = dto.Name;
            categary .code = dto.Code;
            categary.parantId = dto.ParentId;
            categary.LocationType = dto .locationType;

            await _customerRepository.categary(categary);
            return "Created Successfully";
        }

        public async Task delete(int id)
        {

            await _customerRepository.DeleteUser(id);

        }
        public async Task<List<Location>> GetAll()
        {
            var get = await _customerRepository.GetAll();
            return get;
        }

        public async Task<Location> GetById(int id)
        {
            return await _customerRepository.GetId(id);
        }

        public async Task Update(int LocationId, CreateLocationDto update)
        {
            var customer = await _customerRepository.GetId(LocationId);

            if (customer == null)
                throw new Exception("Customer not found");

            await _customerRepository.Update(customer);
        }
    }
}
