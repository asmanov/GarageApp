namespace GarageApp.Client.Features.Home
{
    public class Equipment
    {
        public required string Id { get; set; }
        public required string ModelName { get; set; }
        public required string BrandName { get; set; }
        public required string Image { get; set; }
        public required string Description { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
    }
}
