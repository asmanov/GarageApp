using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("inspections")]
    public class Inspection : BaseModelApp
    {
        [Column("start")]
        public DateOnly Start { get; set; }

        [Column("end")]
        public DateOnly End { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(1));

        [Column("track")]
        public int Track { get; set; }
    }
}
