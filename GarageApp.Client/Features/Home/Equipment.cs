using GarageApp.Shared.Features.ManageEquipment;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Client.Features.Home
{
    [Table("equipmens_view")]
    public class Equipment : BaseModelApp
    {
        [Column("registration_number")]
        public string RegistrationNumber { get; set; } = default!;

        [Column("name")]
        public string ModelName { get; set; } = default!;

        [Column("brand_name")]
        public string BrandName { get; set; } = default!;

        [Column("image")]
        public string Image { get; set; } = default!;

        [Column("year")]
        public int Year { get; set; }

        [Column("euro")]
        public int Euro { get; set; }
    }
}
