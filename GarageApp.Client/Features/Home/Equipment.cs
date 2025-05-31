using GarageApp.Shared.Features.ManageEquipment;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Client.Features.Home
{
    [Table("garage_full_view")]
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

        [Column("description")]
        public string? Description { get; set; }

        [Column("volume_fuel_tank")]
        public int VolumeFuelTank { get; set; }

        [Column("vin")]
        public string Vin { get; set; } = default!;

        [Column("osago_start")]
        public DateOnly? OsagoStart { get; set; }

        [Column("osago_end")]
        public DateOnly? OsagoEnd { get; set; }

        [Column("kasko_start")]
        public DateOnly? KaskoStart { get; set; }

        [Column("kasko_end")]
        public DateOnly? KaskoEnd { get; set; }

        [Column("green_start")]
        public DateOnly? GreenStart { get; set; }

        [Column("green_end")]
        public DateOnly? GreenEnd { get; set; }

        [Column("tacho_start")]
        public DateOnly? TachoStart { get; set; }

        [Column("tacho_end")]
        public DateOnly? TachoEnd { get; set; }

        [Column("inspection_start")]
        public DateOnly? InspectionStart { get; set; }

        [Column("inspection_end")]
        public DateOnly? InspectionEnd { get; set; }
    }
}
