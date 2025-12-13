using Domain;

namespace Application.locations.Dto
{
    public class LocationDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int ParentId { get; set; }
        public LocationType locationType { get; set; }
    }
}
