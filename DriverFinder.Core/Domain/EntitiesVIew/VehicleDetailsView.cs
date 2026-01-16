namespace DriverFinder.Core.Domain.EntitiesVIew
{
    public class VehicleDetailsView
    {
        public Guid VehicleID { get; set; }
        public Guid SchoolID { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? BodyType { get; set; }
        public string? Transmission { get; set; }
        public string? VehicleImageUrl { get; set; }
    }
}
