using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("inspection")]
    public class Inspection : BaseModelApp
    {
        [Column("start")]
        public DateOnly Start { get; set; }

        [Column("end")]
        public DateOnly End { get; set; }

        [Reference(typeof(Garage))]
        public Garage Garage { get; set; } = default!;
    }
}
