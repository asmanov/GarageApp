using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("garage")]
    public class Garage : BaseModelApp
    {
        [Column("registration_number")]
        public string RegistrationNumber { get; set; } = default!;

        [Column("description")]
        public string? Description { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("volume_fuel_tank")]
        public int VolumeFuelTank { get; set; }

        [Column("vin")]
        public string Vin { get; set; } = default!;

        [Column("image")]
        public string? Image { get; set; }

        [Column("model_id")]
        public int ModelId { get; set; }

        [Column("site_id")]
        public int? SiteId { get; set; }
    }
}
