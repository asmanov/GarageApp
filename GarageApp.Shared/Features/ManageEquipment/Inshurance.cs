using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Shared.Features.ManageEquipment
{
    public class Inshurance : BaseModelApp
    {
        [Column("type")]
        public string Type { get; set; }

        [Column("nomber")]
        public int Nomber { get; set; }

        [Column("start")]
        public DateOnly Start { get; set; }

        [Column("end")]
        public DateOnly End { get; set; }

        [Column("cost")]
        public double Cost { get; set; }

        [Reference(typeof(Garage))]
        public Garage Garage { get; set; } = default!;
    }
}
